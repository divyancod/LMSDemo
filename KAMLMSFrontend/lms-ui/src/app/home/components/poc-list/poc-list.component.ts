import { Component, Input, OnInit } from '@angular/core';
import { POCDetails } from 'src/app/models/POCModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-poc-list',
  templateUrl: './poc-list.component.html',
  styleUrls: ['./poc-list.component.css']
})
export class PocListComponent implements OnInit {

  @Input() companyId:string = ''
  pocList: POCDetails[] = []
  constructor(private leadService:LeadsService) { }

  ngOnInit(): void {
    this.loadPOC();
  }

  loadPOC()
  {
    this.leadService.getAllPOC(this.companyId).subscribe(data=>{
      this.pocList = data;
    })
  }

}
