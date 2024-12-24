import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-add-lead',
  templateUrl: './add-lead.component.html',
  styleUrls: ['./add-lead.component.css']
})
export class AddLeadComponent implements OnInit {

  constructor(private leadsService: LeadsService,private router:Router) { }

  ngOnInit(): void {
  }
  parentEnterpriseName: string = '';
  companyName: string = '';
  companyEmail: string = '';
  companyAddress: string = '';
  country: string = '';
  timeZone: string = '';
  workingHourStart: string = '';
  workingHourEnd: string = '';
  comment: string = '';
  errorMessage: string = '';

  addLead() {
    if (!this.validate()) {
      return;
    }
    this.leadsService.addLeads({
      parentEnterpriseName: this.parentEnterpriseName,
      companyName: this.companyName,
      companyEmail: this.companyEmail,
      companyAddress: this.companyAddress,
      country: this.country,
      timeZone: this.timeZone,
      workingHourStart: this.workingHourStart,
      workingHourEnd: this.workingHourEnd,
      comment: this.comment,
    }).subscribe(data => {
      if(data!=null)
      {
        this.router.navigate([`/addpoc/${data}`])
      }
    },
      error => { 
        this.errorMessage = "Something went wrong! - "+ error.error
      })
  }

  cancel() {
    console.log('Action canceled');
    // Reset form or perform other cancel actions
  }

  validate(): boolean {
    if (!this.parentEnterpriseName.trim()) {
      this.errorMessage = "Parent Enterprise Name is required";
      return false;
    }

    if (!this.companyName.trim()) {
      this.errorMessage = "Company Name is required";
      return false;
    }

    if (!this.companyEmail.trim()) {
      this.errorMessage = "Company Email is required";
      return false;
    }

    if (!this.companyAddress.trim()) {
      this.errorMessage = "Company Address is required";
      return false;
    }

    if (!this.country.trim()) {
      this.errorMessage = "Country is required";
      return false;
    }

    if (!this.timeZone.trim()) {
      this.errorMessage = "Time Zone is required";
      return false;
    }

    if (!this.workingHourStart.trim()) {
      this.errorMessage = "Working Hour Start is required";
      return false;
    }

    if (!this.workingHourEnd.trim()) {
      this.errorMessage = "Working Hour End is required";
      return false;
    }
    this.errorMessage = '';
    return true;
  }


}
