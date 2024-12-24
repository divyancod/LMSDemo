import { Component, OnInit } from '@angular/core';
import { LeadManagement, LeadTypes } from 'src/app/models/LeadsModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  homeLeads: LeadManagement | null = null;

  constructor(private leadsService: LeadsService) { }

  ngOnInit(): void {
    this.loadDashboard();
  }
  loadDashboard()
  {
    this.leadsService.loadDashboard().subscribe(data=>{
      this.homeLeads = data;
    })
  }

}
