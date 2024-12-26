import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CallStatusModel } from 'src/app/models/CallsModel';
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
  selectedStatus: number = 0;
  minDateTime: string = '';
  rescheduleTime: string = '';
  comment: string = '';
  errorMessage: string = ''

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
      this.errorMessage = "Pleae Select new Date to mark this call rescheduled.";
      return;
    }
    this.leadsService.updateCallStatus({ callId: this.callId.toString(), statusId: this.selectedStatus.toString(), comment: this.comment, reScheduleDate: this.rescheduleTime }).subscribe(data => {
      this.activatedModel.dismiss();
    }, error => { })
  }
  cancel() {
    this.activatedModel.close();
  }
}
