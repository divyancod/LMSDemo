import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LeadInformation, LeadManagement, LeadTypes, TimezoneInfo } from '../models/LeadsModel';
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
    return this.httpClient.get<LeadInformation>(`${this.baseUrl}/leads?id=${id}`);
  }

  addPOC(payload: any) {
    return this.httpClient.post(`${this.baseUrl}/contacts-poc/add`, payload);
  }

  getLeadTypes() {
    return this.httpClient.get<LeadTypes[]>(`${this.baseUrl}/leads/get-leads-types`);
  }

  loadDashboard() {
    return this.httpClient.get<LeadManagement>(`${this.baseUrl}/leads/lead-dashboard`);
  }

  getAllPOC(id: string) {
    return this.httpClient.get<POCDetails[]>(`${this.baseUrl}/contacts-poc/get-poc?companyId=${id}`);
  }
  getAllPOCMin(id: string) {
    return this.httpClient.get<PocDetailsMin[]>(`${this.baseUrl}/contacts-poc/get-poc-min?companyId=${id}`);
  }

  //-------------
  scheduleCall(payload: any) {
    return this.httpClient.post(`${this.baseUrl}/call-details/schedule`, payload);
  }

  getCallScheduled(companyId: string, page: number, statusFilter: any) {
    return this.httpClient.post<CallScheduledResponse[]>(`${this.baseUrl}/call-details/calls-by-companyid?companyId=${companyId}&page=${page}`, statusFilter);
  }

  getCallsStatus() {
    return this.httpClient.get<CallStatusModel[]>(`${this.baseUrl}/call-details/calls-status-types`);
  }

  updateCallStatus(payload: any) {
    return this.httpClient.post(`${this.baseUrl}/call-details/update-call-status`, payload);
  }

  //----
  getFollowUpList(day: string, month: string, year: string) {
    return this.httpClient.get<FollowUpModel[]>(`${this.baseUrl}/central-data/get-followups?day=${day}&month=${month}&year=${year}`);
  }
  getAtRiskLeads()
  {
    return this.httpClient.get<FollowUpModel[]>(`${this.baseUrl}/central-data/at-risk`);
  }

  getAllCountryList()
  {
    return this.httpClient.get<TimezoneInfo[]>(`${this.baseUrl}/data-control/countries`)
  }
}
