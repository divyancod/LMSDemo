import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string = ''
  password: string = ''
  errorMessage: string = ''

  constructor(private authService: AuthService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }


  loginUser() {
    this.errorMessage = ''
    this.authService.LoginUser(this.email, this.password).subscribe(data => {
      localStorage.setItem("lms_ui_token", data.token);
      localStorage.setItem("lms_ui_user", data.name);
      localStorage.setItem("lms_ui_position",data.position);
      this.router.navigate([""]);
    }, error => {
      this.errorMessage = error
    })
  }

}
