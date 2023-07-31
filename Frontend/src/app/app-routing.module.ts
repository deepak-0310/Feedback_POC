import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProvideFeedbacksComponent } from './components/Feedbacks/provide-feedbacks/provide-feedbacks.component';
import { AllFeedbacksComponent } from './components/Feedbacks/all-feedbacks/all-feedbacks.component';

const routes: Routes = [
  {
    path:'',
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
