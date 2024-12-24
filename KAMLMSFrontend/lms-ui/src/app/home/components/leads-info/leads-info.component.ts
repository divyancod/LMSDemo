import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LeadInformation } from 'src/app/models/LeadsModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-leads-info',
  templateUrl: './leads-info.component.html',
  styleUrls: ['./leads-info.component.css']
})
export class LeadsInfoComponent implements OnInit {

  id: string = ''
  currentLead: LeadInformation | null = null;
  constructor(private route: ActivatedRoute,private leadService:LeadsService) {
    this.route.params.subscribe(params => {
      this.id = params['id']
      this.loadLeadInfo();
    });
  }

  ngOnInit(): void {
  }

  loadLeadInfo()
  {
    this.leadService.getLead(this.id).subscribe(data=>{
      this.currentLead = data;
    },error=>{

    })
  }

}
