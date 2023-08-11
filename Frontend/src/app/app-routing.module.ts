import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProvideFeedbacksComponent } from './components/Feedbacks/provide-feedbacks/provide-feedbacks.component';
import { AllFeedbacksComponent } from './components/Feedbacks/all-feedbacks/all-feedbacks.component';
import { LoginpageComponent } from './components/Login-page/loginpage/loginpage.component';
import { SignupComponent } from './components/signup/signup.component';
import { NavbarComponent } from './components/Feedbacks/Navbar/navbar/navbar.component';

const routes: Routes = [
  {
    path:'',
    component:LoginpageComponent
  },
  {
    path:'navbar',
    component:NavbarComponent
  },
  {
    path:'signup',
    component:SignupComponent
  },
  {
    path:'feedbackform',
    component:ProvideFeedbacksComponent
  },
  {
    path:'allfeedbacks',
    component:AllFeedbacksComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
