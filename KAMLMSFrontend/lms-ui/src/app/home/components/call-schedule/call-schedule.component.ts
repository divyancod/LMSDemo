import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
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
  minDateTime: string = '';
  pocList: PocDetailsMin[] = []

  constructor(private leadService: LeadsService,public activeModal: NgbActiveModal) { }

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

  scheduleCall()
  {
    const payload = {
      companyId : this.companyId,
      pocId : this.pocId,
      time:this.model.Time,
      comment:this.model.Time
    };
    this.leadService.scheduleCall(payload).subscribe(data=>{
      console.log("data")
      this.activeModal.close();
    },error=>{})
  }

}
