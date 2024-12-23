import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginUser } from '../models/Auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  LoginUser(email: string, password: string) {
    return this.http.post<LoginUser>(`${this.baseUrl}/auth/login`, { email: email, password: password })
  }

  SignUp(name: string, phone: string, email: string, password: string) {
    return this.http.post<string>(`${this.baseUrl}/auth/signup`, { email: email, password: password, fullname: name, phone: phone })
  }

  isUserAuthenticated(): boolean {
    var token = localStorage.getItem("lms_ui_token")
    if (token == null || token == '') {
      return false;
    }
    return true;
  }
  
  getCurrentUser()
  {
    var user = localStorage.getItem("lms_ui_user") +' ('+ localStorage.getItem("lms_ui_position")+')';
    return user;
  }
}
