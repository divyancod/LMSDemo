import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LeadInformation, WorkingHours } from 'src/app/models/LeadsModel';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-leads-info',
  templateUrl: './leads-info.component.html',
  styleUrls: ['./leads-info.component.css']
})
export class LeadsInfoComponent implements OnInit {

  id: string = ''
  currentLead: LeadInformation | null = null;
  buttons: any[] = [{ id: 1, text: "Call Schedule History" }, { id: 2, text: "Point of contact" }, { id: 3, text: "Call Logs" }]
  showCallSchedule: boolean = true;
  showPoc: boolean = false;
  showCallLog: boolean = false;
  currentSelected: number = 1;

  constructor(private route: ActivatedRoute, private leadService: LeadsService) {
    this.route.params.subscribe(params => {
      this.id = params['id']
      this.loadLeadInfo();
    });
  }

  ngOnInit(): void {
  }

  loadLeadInfo() {
    this.leadService.getLead(this.id).subscribe(data => {
      this.currentLead = data;
    }, error => {

    })
  }

  toggleVariable(variable: number) {
    this.showCallSchedule = this.showPoc = this.showCallLog = false;
    this.currentSelected = variable

    if (variable == 1) {
      this.showCallSchedule = true;
    } else if (variable == 2) {
      this.showPoc = true;
    } else if (variable == 3) {
      this.showCallLog = true;
    }
  }
  getWorkingHours(): WorkingHours {
    return { start: this.currentLead?.workingHourStart, end: this.currentLead?.workingHourEnd }
  }
}
