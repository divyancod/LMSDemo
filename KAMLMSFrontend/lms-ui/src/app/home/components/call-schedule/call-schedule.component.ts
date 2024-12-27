import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { WorkingHours } from 'src/app/models/LeadsModel';
import { PocDetailsMin } from 'src/app/models/POCModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-call-schedule',
  templateUrl: './call-schedule.component.html',
  styleUrls: ['./call-schedule.component.css']
})
export class CallScheduleComponent implements OnInit {

  model = {
    Time: '',
    Comment: null
  };

  @Input("companyId") companyId: string = ''
  @Input("companyName") companyName: string = '';
  @Input("pocId") pocId: string = '';
  @Input("workingHours") workingHours: WorkingHours = { start: "00:00", end: "00:00" }
  minDateTime: string = '';
  pocList: PocDetailsMin[] = []
  errorMessage: string = ''
  outsideWorkHour:boolean = false;

  constructor(private leadService: LeadsService, public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
    const now = new Date();
    const tomorrow = new Date(now);
    tomorrow.setDate(now.getDate() + 1);
    this.minDateTime = tomorrow.toISOString().slice(0, 16);
    this.loadPOC();
  }

  loadPOC() {
    if (this.companyId != null) {
      this.leadService.getAllPOCMin(this.companyId).subscribe(data => {
        this.pocList = data
      }, error => { })
    }
  }

  scheduleCall() {
    if(this.errorMessage.trim()!='' && this.outsideWorkHour==false)
    {
      this.errorMessage = 'Check this or change scheduled call time.'
      return;
    }
    const payload = {
      companyId: this.companyId,
      pocId: this.pocId,
      time: this.model.Time,
      comment: this.model.Comment
    };
    this.leadService.scheduleCall(payload).subscribe(data => {
      this.activeModal.close();
    }, error => { })
  }

  cancel() {
    this.activeModal.close();
  }



  convertToMinutes(time: string): number {
    const [hours, minutes] = time.split(':').map(Number);
    return hours * 60 + minutes;
  }

  validateTime() {
    if (this.model.Time) {
      const timePart = this.model.Time.split('T')[1];
      if (this.workingHours.start != undefined && this.workingHours.end != undefined) {
        const selectedTimeInMinutes = this.convertToMinutes(timePart);
        const minTimeInMinutes = this.convertToMinutes(this.workingHours.start);
        const maxTimeInMinutes = this.convertToMinutes(this.workingHours.end);
        if (selectedTimeInMinutes < minTimeInMinutes || selectedTimeInMinutes > maxTimeInMinutes) {
          this.errorMessage = `Selected time is outside lead working hours.`;
        } else {
          this.errorMessage = '';
        }
      }
    }
  }

}
