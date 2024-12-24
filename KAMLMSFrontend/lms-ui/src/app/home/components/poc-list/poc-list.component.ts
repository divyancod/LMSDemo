import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { POCDetails } from 'src/app/models/POCModel';
import { LeadsService } from 'src/app/service/leads.service';
import { CallScheduleComponent } from '../call-schedule/call-schedule.component';

@Component({
  selector: 'app-poc-list',
  templateUrl: './poc-list.component.html',
  styleUrls: ['./poc-list.component.css']
})
export class PocListComponent implements OnInit {

  @Input("companyId") companyId:string = ''
  @Input("companyName") companyName:string | undefined=''
  pocList: POCDetails[] = []
  constructor(private leadService:LeadsService,private modalService:NgbModal) { }

  ngOnInit(): void {
    this.loadPOC();
  }

  loadPOC()
  {
    this.leadService.getAllPOC(this.companyId).subscribe(data=>{
      this.pocList = data;
    })
  }

  openSchedule(pocId:string)
  {
    const modelref = this.modalService.open(CallScheduleComponent);
    modelref.componentInstance.companyId = this.companyId
    modelref.componentInstance.companyName = this.companyName
    modelref.componentInstance.pocId = pocId
  }

}
