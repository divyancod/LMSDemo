import { Component, OnInit } from '@angular/core';
import { FollowUpModel } from 'src/app/models/FollowUp';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  followUpCurrentMonth:FollowUpModel[] = []
  followUpToday:FollowUpModel[] = []
  atRiskLeads:FollowUpModel[] = []
  constructor(private leadsService: LeadsService) { }

  ngOnInit(): void {
    this.loadcurrentMonth();
    this.loadCurrentDate();
    this.laodAtRisk();

  }
  loadcurrentMonth() {
    const currentDate = new Date();
    const currentMonth = (currentDate.getMonth() + 1).toString().padStart(2, '0');
    this.leadsService.getFollowUpList('',currentMonth,'').subscribe(data => {
      this.followUpCurrentMonth = data;
    })
  }

  loadCurrentDate()
  {
    const currentDate = new Date();
    const today = currentDate.getDate().toString().padStart(2, '0');
    this.leadsService.getFollowUpList(today,'','').subscribe(data => {
      this.followUpToday = data;
    })
  }

  laodAtRisk()
  {
    this.leadsService.getAtRiskLeads().subscribe(data => {
      this.atRiskLeads = data;
    })
  }
  formatToDdMmmYyyy(dateString: string): string {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      day: '2-digit',
      month: 'short',
    };

    return date.toLocaleDateString('en-US', options).replace(',', '');
  }
}
