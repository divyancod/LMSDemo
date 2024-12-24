import { Component, Input, OnInit } from '@angular/core';
import { LeadInformation } from 'src/app/models/LeadsModel';

@Component({
  selector: 'app-leads-header',
  templateUrl: './leads-header.component.html',
  styleUrls: ['./leads-header.component.css']
})
export class LeadsHeaderComponent implements OnInit {

  @Input("currentlead") currentLead: LeadInformation | null = null;
  @Input("showMinimum") showMinimum: boolean = false;
  constructor() { }

  ngOnInit(): void {
  }

}
