import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddLeadComponent } from './components/add-lead/add-lead.component';
import { AddPocComponent } from './components/add-poc/add-poc.component';
import { LeadsInfoComponent } from './components/leads-info/leads-info.component';

const routes: Routes = [{
  path: "", component: HomeComponent,
  children: [
    { path: "", component: DashboardComponent },
    { path:"add", component: AddLeadComponent},
    {path:"addpoc/:id",component:AddPocComponent},
    {path:"details/:id",component:LeadsInfoComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
