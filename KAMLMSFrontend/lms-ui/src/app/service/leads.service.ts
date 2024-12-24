import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LeadInformation, LeadManagement, LeadTypes } from '../models/LeadsModel';
import { POCDetails } from '../models/POCModel';

@Injectable({
  providedIn: 'root'
})
export class LeadsService {

  private baseUrl = environment.apiUrl;
  constructor(private httpClient:HttpClient) { }

  addLeads(payload:any)
  {
    return this.httpClient.post<string>(`${this.baseUrl}/leads`,payload);
  }

  getLead(id:string)
  {
    return this.httpClient.get<LeadInformation>(`${this.baseUrl}/leads?id=${id}`);
  }
  
  addPOC(payload:any)
  {
    return this.httpClient.post(`${this.baseUrl}/contacts-poc/add`,payload);
  }

  getLeadTypes()
  {
    return this.httpClient.get<LeadTypes[]>(`${this.baseUrl}/leads/get-leads-types`);
  }

  loadDashboard()
  {
    return this.httpClient.get<LeadManagement>(`${this.baseUrl}/leads/lead-dashboard`);
  }

  getAllPOC(id:string)
  {
    return this.httpClient.get<POCDetails[]>(`${this.baseUrl}/contacts-poc/get-poc?companyId=${id}`);
  }
}
