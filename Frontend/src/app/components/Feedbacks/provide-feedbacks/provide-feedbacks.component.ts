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
  name = 'Angular';
  
   form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    //email: new FormControl('', [Validators.required, Validators.email])
  });
  addFeedbackRequest: UserFeedback = {
    UserName: '',
    UserFeedback: ''
  };
  constructor(private feedbackservice: FeedbacksService, private router: Router) {

  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');

  }
  addFeedback() {
    this.feedbackservice.addFeedback(this.addFeedbackRequest).subscribe({
      next: (data) => {
        this.resetForm();
      }
    });
  }
  resetForm() {
    this.addFeedbackRequest = {
      UserName: '',
      UserFeedback: ''
    };
  }
}
