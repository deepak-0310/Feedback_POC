import { HttpClient } from '@angular/common/http';
import { Component,OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import {map} from 'rxjs/operators';
import { FeedbacksService } from 'src/app/services/feedbacks.service';
import { UserFeedback } from 'src/models/Feedback';

@Component({
  selector: 'app-all-feedbacks',
  templateUrl: './all-feedbacks.component.html',
  styleUrls: ['./all-feedbacks.component.css']
})


export class AllFeedbacksComponent implements OnInit {
  dataSubscription?:Subscription;
  data:any;
  constructor(private getService:FeedbacksService){

  }
  ngOnInit(): void {
    this.dataSubscription=this.getService.getFeedback().subscribe(
      (response:any)=>{
        this.data=response;
      }
      
    );
  }
  
}
