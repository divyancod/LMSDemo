import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { LeadInformation, POCRoles } from 'src/app/models/LeadsModel';
import { DataControlService } from 'src/app/service/data-control.service';
import { LeadsService } from 'src/app/service/leads.service';

@Component({
  selector: 'app-add-poc',
  templateUrl: './add-poc.component.html',
  styleUrls: ['./add-poc.component.css']
})
export class AddPocComponent implements OnInit {

  @Input("id")id: string = '';
  @Input("isNew")isNew:boolean = false
  //currentLead: LeadInformation | null = null;

  name: string = '';
  phone: string = '';
  email: string = '';
  roleId: number = 0;
  customRole: string = '';
  roles: POCRoles[] = [];
  showCustom: boolean = false
  scheduleCall: boolean = false;
  selectedTime: string = ''
  minDateTime:string = ''

  errorMessage: string = '';

  constructor(private leadsService: LeadsService, private dataService: DataControlService, private router: Router,private activeModal:NgbActiveModal) {
  }

  ngOnInit(): void {
    this.loadRoles();
    const now = new Date();
    const tomorrow = new Date(now);
    tomorrow.setDate(now.getDate() + 1);
    this.minDateTime = tomorrow.toISOString().slice(0, 16);
  }
  submitForm() {
    if (!this.showCustom) {
      this.customRole = ''
    }
    if (this.scheduleCall && this.selectedTime == '') {
      this.errorMessage = 'Select Schedule Call times.'
      return;
    }
    if(!this.scheduleCall)
    {
      this.selectedTime = ''
    }
    this.leadsService.addPOC({ companyId: this.id, name: this.name, phone: this.phone, email: this.email, roleId: this.roleId, customRole: this.customRole, isMainPOC: this.scheduleCall, time: this.selectedTime }).subscribe(data => {
      this.activeModal.close();
    }, error => {

    })
  }

  loadRoles() {
    console.log(this.id)
    this.dataService.getRoles().subscribe(data => {
      this.roles = data;
    }, error => {

    })
  }
  onRoleChange() {
    this.showCustom = this.roleId == 11;
  }
  cancel()
  {
    this.activeModal.dismiss();
  }
}
