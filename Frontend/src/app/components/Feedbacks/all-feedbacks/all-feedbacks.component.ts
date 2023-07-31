import { HttpClient } from '@angular/common/http';
import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-all-feedbacks',
  templateUrl: './all-feedbacks.component.html',
  styleUrls: ['./all-feedbacks.component.css']
})
export class AllFeedbacksComponent implements OnInit {
  feedbackData: any[] = [];
  cnt:number=0;
  Date_Time:any[][]=[];
  APIUrl:string= "http://localhost:3333/api/Feedback";
  constructor(private http:HttpClient){

  }
  ngOnInit(): void {
    this.getFeedbackData();
  }
  getFeedbackData(){
    this.http.get<any[]>(this.APIUrl).subscribe(
      (data)=>{
        this.feedbackData=data;
      }
      );
  }
  delete(id:number){
     this.http.delete<any[]>(this.APIUrl+'/DeleteFeedback');
  }
}
