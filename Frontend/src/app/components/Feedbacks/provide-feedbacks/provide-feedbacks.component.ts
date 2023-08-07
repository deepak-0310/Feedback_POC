import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FeedbacksService } from 'src/app/services/feedbacks.service';
import { UserFeedback } from 'src/models/Feedback';
import { FormControl, NgForm } from '@angular/forms'
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-provide-feedbacks',
  templateUrl: './provide-feedbacks.component.html',
  styleUrls: ['./provide-feedbacks.component.css']
})
export class ProvideFeedbacksComponent implements OnInit {
  feedbackForm!: FormGroup;
  constructor(private feedbackservice: FeedbacksService,private fb: FormBuilder) {

  }
  ngOnInit(): void {
    this.feedbackForm=this.fb.group({
      username:['',Validators.required],
      userfeedback:['',Validators.required]
    })

  }
  onSubmit(){
    if(this.feedbackForm.valid){
      this.addFeedbacks();
    }
    else{
      this.validateFormFields(this.feedbackForm);
      alert("The form is invalid");
    }
  }
  private validateFormFields(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field =>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true})
      }
      else if(control instanceof FormGroup){
        this.validateFormFields(control);
      }
    })

  }
  // addFeedbackRequest:any = this.feedbackForm.value;
  addFeedbacks() {
    console.log(this.feedbackForm.value);
    this.feedbackservice.addFeedback(this.feedbackForm.value).subscribe({
      next: (data) => {
        this.feedbackForm.reset();
      }
    });
  }
  resetForm() {
    this.feedbackForm.reset();
  }
}
