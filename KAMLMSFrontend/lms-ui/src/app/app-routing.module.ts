import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { AuthenticationGuard } from './guard/authentication.guard';
import { SignupComponent } from './components/auth/signup/signup.component';
const routes: Routes = [{path:"login",component:LoginComponent},
  {path:"signup",component:SignupComponent},
  {path:"",loadChildren:()=>import('../app/home/home.module').then(m=>m.HomeModule),canLoad:[AuthenticationGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
