import { Component, Input, OnInit } from '@angular/core';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-call-scheduled-list',
  templateUrl: './call-scheduled-list.component.html',
  styleUrls: ['./call-scheduled-list.component.css']
})
export class CallScheduledListComponent implements OnInit {

  @Input("companyId") companyId:string = ''
  constructor(private leadsService:LeadsService) { }

  ngOnInit(): void {
    this.loadCallSchedule();
  }

  loadCallSchedule()
  {
    this.leadsService.getCallScheduled(this.companyId).subscribe(data=>{
      console.log(data)
    },error=>{

    })
  }


}
