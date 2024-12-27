import { Component, Input, OnInit } from '@angular/core';
import { LeadTypes, SingleLead, StatusGroup } from 'src/app/models/LeadsModel';

@Component({
  selector: 'app-leads-list',
  templateUrl: './leads-list.component.html',
  styleUrls: ['./leads-list.component.css']
})
export class LeadsListComponent implements OnInit {

  @Input() current : StatusGroup | null = null

  constructor() { }

  ngOnInit(): void {
  }

}
