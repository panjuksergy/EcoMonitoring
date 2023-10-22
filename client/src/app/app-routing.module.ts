import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {IdentityLoginPage} from "./components/identity-component/pages/identity-login-page/identity-login.page";
import {
  IdentityRegisterPage
} from "./components/identity-component/pages/identity-register-page/identity-register.page";
import {MainPageComponent} from "./components/main-page-component/main-page.component";
import {AuthGuardService} from "./components/identity-component/services/auth.guard";
import {AboutPageComponent} from "./components/about-page-component/about-page.component";
import {LogOutComponent} from "./components/identity-component/pages/log-out-component/log-out.component";
import {ContactPageComponent} from "./components/contact-page-component/contact-page.component";
import {FetchExcelComponent} from "./components/fetch-excel/fetch-excel.component";

const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: "full",
  },
  // {
  //   path: '**',
  //   redirectTo: 'login',
  // },
  {
    path: 'login',
    component: IdentityLoginPage,
  },
  {
    path: 'register',
    component: IdentityRegisterPage
  },
  {
    path: 'datatable',
    component: MainPageComponent,
  },
  {
    path: 'fetchExcel',
    component: FetchExcelComponent,
  },
  {
    path: 'about',
    component: AboutPageComponent,
  },
  {
    path: 'logout',
    component: LogOutComponent,
  },
  {
    path: 'contact/aboutus',
    component: ContactPageComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
