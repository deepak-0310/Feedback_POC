import { HttpClient } from '@angular/common/http';
import { Component,OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import {map} from 'rxjs/operators';
import { FeedbacksService } from 'src/app/services/feedbacks.service';
import { UserFeedback } from 'src/models/Feedback';

type pageParametersType={
  cnt:number,
  pgs:number
}
@Component({
  selector: 'app-all-feedbacks',
  templateUrl: './all-feedbacks.component.html',
  styleUrls: ['./all-feedbacks.component.css']
})


export class AllFeedbacksComponent implements OnInit {
  dataSubscription?:Subscription;
  data:any;
  pageParameters: pageParametersType={
    cnt:1,
    pgs:10
  };
  constructor(private getService:FeedbacksService)
  {
    
  }
  ngOnInit(): void {
    this.dataSubscription=this.getService.getFeedback(this.pageParameters).subscribe(
      (response:any)=>{
        this.data=response;
      }
      
    );
  }
  onNext(){
      this.pageParameters.cnt+=1;
      this.ngOnInit();
  }
  onPrevious(){
      this.pageParameters.cnt-=1;
      this.ngOnInit();
  }
  
}
