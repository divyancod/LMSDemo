import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  currentUser:string=''
  constructor(private loginService:AuthService) { }

  ngOnInit(): void {
    this.currentUser = this.loginService.getCurrentUser() ?? '';
  }

  logout()
  {
    localStorage.clear();
    location.reload();
  }

}
