import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LeadInformation } from 'src/app/models/LeadsModel';
import { UpdateLeadComponent } from '../update-lead/update-lead.component';

@Component({
  selector: 'app-leads-header',
  templateUrl: './leads-header.component.html',
  styleUrls: ['./leads-header.component.css']
})
export class LeadsHeaderComponent implements OnInit {

  @Input("currentlead") currentLead: LeadInformation | null = null;
  @Input("showMinimum") showMinimum: boolean = false;
  constructor(private ngbModel:NgbModal) { }

  ngOnInit(): void {
  }
  markWon()
  {
    this.openModel(true)
  }
  marklost()
  {
    this.openModel(false)
  }
  openModel(isWon:boolean)
  {
    const modelref = this.ngbModel.open(UpdateLeadComponent)
    modelref.componentInstance.isWon = isWon;
    modelref.componentInstance.id = this.currentLead?.id
  }
}
