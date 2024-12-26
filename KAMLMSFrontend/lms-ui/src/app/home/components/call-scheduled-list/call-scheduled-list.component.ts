import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CallScheduledResponse, CallStatusModel, FilterCallStatusModel } from 'src/app/models/CallsModel';
import { LeadsService } from 'src/app/service/leads.service';
import { ModifyCallCardComponent } from '../modify-call-card/modify-call-card.component';

@Component({
  selector: 'app-call-scheduled-list',
  templateUrl: './call-scheduled-list.component.html',
  styleUrls: ['./call-scheduled-list.component.css']
})
export class CallScheduledListComponent implements OnInit {

  @Input("companyId") companyId: string = ''
  callScheduledList: CallScheduledResponse[] = []
  page: number = 0;
  callStatusFilter: FilterCallStatusModel[] = []
  showFilter:boolean = false;
  constructor(private leadsService: LeadsService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.loadCallSchedule();
    this.loadCallStatuses();
  }

  loadCallSchedule() {
    var filters = this.callStatusFilter.filter(x=>x.isSelected).map(x=>x.callStatusModel.id.toString());
    if(filters.length==this.callStatusFilter.length)
    {
      filters=[];
    }
    this.leadsService.getCallScheduled(this.companyId, this.page, {statusList:filters}).subscribe(data => {
      this.callScheduledList = data;
      if(filters.length==0 && this.callStatusFilter.length!=0)
      {
        this.callStatusFilter.forEach(item=>{
          item.isSelected=true;
        })
      }
    }, error => {

    })
  }

  formatToDdMmmYyyy(dateString: string): string {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      day: '2-digit',
      month: 'short',
      year: 'numeric',
    };

    return date.toLocaleDateString('en-US', options).replace(',', '');
  }
  modifyCallSchedule(callId: string, status: string, currentDate: string,comment:string|null) {
    const modelref = this.modalService.open(ModifyCallCardComponent);
    modelref.componentInstance.callId = callId;
    modelref.componentInstance.currentScheduleAt = currentDate;
    modelref.componentInstance.currentStatus = status;
    modelref.componentInstance.currentComment = comment
    modelref.result.then((result) => {
    },
      (reason) => {
        this.loadCallSchedule();
      })
  }

  loadCallStatuses() {
    this.leadsService.getCallsStatus().subscribe(data => {
      this.callStatusFilter = data.map(status => ({ callStatusModel: status, isSelected: true }));
    })
  }

  toggleFilter()
  {
    this.showFilter = !this.showFilter
  }
  applyFilters()
  {
    this.loadCallSchedule();
  }

  pageUp()
  {
    this.page++;
    this.loadCallSchedule();
  }

  pageDown()
  {
    this.page--;
    this.loadCallSchedule();
  }
}
