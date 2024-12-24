import { Component, Input, OnInit } from '@angular/core';
import { LeadTypes, SingleLead, StatusGroup } from 'src/app/models/LeadsModel';

@Component({
  selector: 'app-leads-list',
  templateUrl: './leads-list.component.html',
  styleUrls: ['./leads-list.component.css']
})
export class LeadsListComponent implements OnInit {

  numbers = Array(10).fill(0).map((_, i) => i + 1);
  @Input() current : StatusGroup | null = null

  constructor() { }

  ngOnInit(): void {
  }

}
