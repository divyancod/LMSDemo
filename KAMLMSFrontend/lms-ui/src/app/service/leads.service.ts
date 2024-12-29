import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LeadInformation, LeadManagement, SingleLead, TimezoneInfo } from '../models/LeadsModel';
import { POCDetails, PocDetailsMin } from '../models/POCModel';
import { CallScheduledResponse, CallStatusModel } from '../models/CallsModel';
import { FollowUpModel } from '../models/FollowUp';

@Injectable({
  providedIn: 'root'
})
export class LeadsService {

  private baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) { }

  addLeads(payload: any) {
    return this.httpClient.post<string>(`${this.baseUrl}/leads`, payload);
  }

  getLead(id: string) {
    return this.httpClient.get<LeadInformation>(`${this.baseUrl}/leads/${id}`);
  }

  addPOC(payload: any) {
    return this.httpClient.post(`${this.baseUrl}/point-of-contact`, payload);
  }

  loadDashboard() {
    return this.httpClient.get<LeadManagement>(`${this.baseUrl}/dashboard`);
  }

  getAllPOC(id: string) {
    return this.httpClient.get<POCDetails[]>(`${this.baseUrl}/point-of-contact/${id}`);
  }
  getAllPOCMin(id: string) {
    return this.httpClient.get<PocDetailsMin[]>(`${this.baseUrl}/point-of-contact/${id}?withLessData=true`);
  }

  //-------------
  scheduleCall(payload: any) {
    return this.httpClient.post(`${this.baseUrl}/calls`, payload);
  }

  getCallScheduled(companyId: string, page: number, statusFilter: number[]) {
    var url = `${this.baseUrl}/calls/${companyId}?page=${page}`;
    if(statusFilter.length!=0)
    {
      var status = statusFilter.map((item)=>`&statuses=${item}`).join('');
      url = url+status
    }
    return this.httpClient.get<CallScheduledResponse[]>(url);
  }

  getCallsStatus() {
    return this.httpClient.get<CallStatusModel[]>(`${this.baseUrl}/reference-data/calls-status-types`);
  }

  updateCallStatus(payload: any) {
    return this.httpClient.patch(`${this.baseUrl}/calls`, payload);
  }

  //----
  getFollowUpList(day: string, month: string, year: string) {
    return this.httpClient.get<FollowUpModel[]>(`${this.baseUrl}/dashboard/by-followups?day=${day}&month=${month}&year=${year}`);
  }
  getAtRiskLeads()
  {
    return this.httpClient.get<FollowUpModel[]>(`${this.baseUrl}/dashboard/by-risk`);
  }

  getAllCountryList()
  {
    return this.httpClient.get<TimezoneInfo[]>(`${this.baseUrl}/reference-data/countries`)
  }

  updateLead(payload:any)
  {
    return this.httpClient.patch(`${this.baseUrl}/leads`,payload);
  }

  getLeadsByType(type: number, page: number) {
    return this.httpClient.get<SingleLead[]>(`${this.baseUrl}/leads/${type}?page=${page}`);
  }
}
