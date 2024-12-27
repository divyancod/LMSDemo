import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CallStatusModel } from 'src/app/models/CallsModel';
import { WorkingHours } from 'src/app/models/LeadsModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-modify-call-card',
  templateUrl: './modify-call-card.component.html',
  styleUrls: ['./modify-call-card.component.css']
})
export class ModifyCallCardComponent implements OnInit {

  @Input("callId") callId: string = ''
  @Input("comment") currentComment:string = ''
  @Input("currentStatus") currentStatus = '';
  @Input("currentScheduleAt")currentScheduleAt = ''
  @Input("workingHours")workingHours:WorkingHours = {end:'00:00',start:'00'}
  selectedStatus: number = 0;
  minDateTime: string = '';
  rescheduleTime: string = '';
  comment: string = '';
  errorMessage: string = ''
  outsideWorkHour:boolean = false
  showCheckBox:boolean = false;

  callStatusList: CallStatusModel[] = []

  constructor(private leadsService: LeadsService, private activatedModel: NgbActiveModal) { }

  ngOnInit(): void {
    this.loadCallStatuses();
    const now = new Date();
    const tomorrow = new Date(now);
    tomorrow.setDate(now.getDate() + 1);
    this.minDateTime = tomorrow.toISOString().slice(0, 16);
    this.comment = this.currentComment;
  }

  loadCallStatuses() {
    this.leadsService.getCallsStatus().subscribe(data => {
      this.callStatusList = data;
      this.callStatusList.forEach(data => {
        if (data.status == this.currentStatus) {
          this.selectedStatus = data.id;
        }
      });
    })
  }

  update() {
    if (this.selectedStatus == 2 && this.rescheduleTime.trim() == '') {
      this.errorMessage = "Pleae select new date time to mark this call rescheduled.";
      return;
    }
    if(this.errorMessage.trim()!='' && this.outsideWorkHour==false)
    {
      this.errorMessage = "Please mark this checkbox to reschedule call"
      return;
    }
    this.leadsService.updateCallStatus({ callId: this.callId.toString(), statusId: this.selectedStatus.toString(), comment: this.comment, reScheduleDate: this.rescheduleTime }).subscribe(data => {
      this.activatedModel.dismiss();
    }, error => { })
  }

  cancel() {
    this.activatedModel.close();
  }

  convertToMinutes(time: string): number {
    const [hours, minutes] = time.split(':').map(Number);
    return hours * 60 + minutes;
  }

  validateTime() {
    if (this.rescheduleTime) {
      const timePart = this.rescheduleTime.split('T')[1];
      if (this.workingHours.start != undefined && this.workingHours.end != undefined) {
        const selectedTimeInMinutes = this.convertToMinutes(timePart);
        const minTimeInMinutes = this.convertToMinutes(this.workingHours.start);
        const maxTimeInMinutes = this.convertToMinutes(this.workingHours.end);
        if (selectedTimeInMinutes < minTimeInMinutes || selectedTimeInMinutes > maxTimeInMinutes) {
          this.errorMessage = `Selected time is outside lead working hours.`;
          this.showCheckBox = true;
        } else {
          this.errorMessage = '';
          this.showCheckBox = false;
        }
      }
    }
  }
}
