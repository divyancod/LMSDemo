import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SingleLead, StatusGroup } from 'src/app/models/LeadsModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-lead-list-full',
  templateUrl: './lead-list-full.component.html',
  styleUrls: ['./lead-list-full.component.css']
})
export class LeadListFullComponent implements OnInit {

  page: number = 0
  type: number = 0
  singleLead: SingleLead[] = []
  status:string = ''
  disableNext:boolean = false;

  constructor(private route: ActivatedRoute, private leadService: LeadsService) {
    this.route.params.subscribe(params => {
      this.type = params['type']
      this.loadLeads();
    });
  }
  ngOnInit(): void {
  }

  loadLeads() {
    this.leadService.getLeadsByType(this.type, this.page).subscribe(data => {
      this.singleLead = data;
    }
    )
  }
  pageUp()
  {
    this.page++;
    this.loadLeads();
  }

  pageDown()
  {
    this.page--;
    this.loadLeads();
  }

}
