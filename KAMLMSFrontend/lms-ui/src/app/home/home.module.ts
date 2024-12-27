import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './components/home/home.component';
import { NavComponent } from './components/nav/nav.component';
import { HeaderComponent } from './components/header/header.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddLeadComponent } from './components/add-lead/add-lead.component';
import { FormsModule } from '@angular/forms';
import { AddPocComponent } from './components/add-poc/add-poc.component';
import { LeadsHeaderComponent } from './components/leads-header/leads-header.component';
import { LeadsListComponent } from './components/leads-list/leads-list.component';
import { LeadCardComponent } from './components/lead-card/lead-card.component';
import { LeadsInfoComponent } from './components/leads-info/leads-info.component';
import { PocListComponent } from './components/poc-list/poc-list.component';
import { BackBtnDirective } from '../directive/back-btn.directive';
import { CallScheduleComponent } from './components/call-schedule/call-schedule.component';
import { CallScheduledListComponent } from './components/call-scheduled-list/call-scheduled-list.component';
import { CallLogsListComponent } from './components/call-logs-list/call-logs-list.component';
import { ModifyCallCardComponent } from './components/modify-call-card/modify-call-card.component';
import { UpdateLeadComponent } from './components/update-lead/update-lead.component';
import { LeadListFullComponent } from './components/lead-list-full/lead-list-full.component';


@NgModule({
  declarations: [
    HomeComponent,
    NavComponent,
    HeaderComponent,
    DashboardComponent,
    AddLeadComponent,
    AddPocComponent,
    LeadsHeaderComponent,
    BackBtnDirective,
    LeadsListComponent,
    LeadCardComponent,
    LeadsInfoComponent,
    PocListComponent,
    CallScheduleComponent,
    CallScheduledListComponent,
    CallLogsListComponent,
    ModifyCallCardComponent,
    UpdateLeadComponent,
    LeadListFullComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    FormsModule
  ]
})
export class HomeModule { }
