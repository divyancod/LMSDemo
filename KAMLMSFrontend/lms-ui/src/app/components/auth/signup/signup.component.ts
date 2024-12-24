import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  name: string = '';
  email: string = '';
  phone: string = '';
  password: string = '';
  repassword: string = '';
  errorMessage: string = '';
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  signUp() {
    this.errorMessage=''
    if(!this.validation())
    {
      return;
    }
    this.authService.SignUp(this.name, this.phone, this.email, this.password).subscribe(data => {
      this.router.navigate(["/login"]);
    },
      error => {
        this.errorMessage = error;
       })
  }
  validation(): boolean
  {
    if(this.name=='')
    {
      this.errorMessage = 'Enter Name'
      return false;
    }
    if(this.email=='')
    {
      this.errorMessage = 'Enter Email Address'
      return false;
    }
    if(this.phone=='')
    {
      this.errorMessage='Enter phone number'
      return false;
    }
    if (this.password.length==0 || this.password != this.repassword) {
      this.errorMessage = "Password do not match";
      return false;
    }
    return true;
  }
}
