import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProvideFeedbacksComponent } from './components/Feedbacks/provide-feedbacks/provide-feedbacks.component';
import { AllFeedbacksComponent } from './components/Feedbacks/all-feedbacks/all-feedbacks.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginpageComponent } from './components/Login-page/loginpage/loginpage.component';
import { NavbarComponent } from './components/Feedbacks/Navbar/navbar/navbar.component';
import { SignupComponent } from './components/signup/signup.component';



@NgModule({
  declarations: [
    AppComponent,
    ProvideFeedbacksComponent,
    AllFeedbacksComponent,
    LoginpageComponent,
    NavbarComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
