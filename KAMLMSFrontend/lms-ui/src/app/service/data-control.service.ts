import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { POCRoles } from '../models/LeadsModel';

@Injectable({
  providedIn: 'root'
})
export class DataControlService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRoles() {
    return this.http.get<POCRoles[]>(`${this.baseUrl}/reference-data/roles`);
  }
}
