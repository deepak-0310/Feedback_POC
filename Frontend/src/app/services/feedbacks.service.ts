import { Injectable } from '@angular/core';
import { UserFeedback } from 'src/models/Feedback';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';
import {map} from 'rxjs/operators';
type pageParametersType={
  cnt:number,
  pgs:number
}
@Injectable({
  providedIn: 'root'
})

export class FeedbacksService {
  APIUrl: string = "https://localhost:7016/api/";
  constructor(private http: HttpClient) { }
  signingUp(signupObj:any):Observable<any>{
       return this.http.post<any>(this.APIUrl+'Signup/register',signupObj);
  }
  Login(loginObj:any){
    return this.http.post<any>(this.APIUrl+'Signup/authenticate',loginObj);
  }
  addFeedback(addFeedbackRequest:any): Observable<UserFeedback> {
    return this.http.post<any>(this.APIUrl+'Feedback', addFeedbackRequest);
  }
  getFeedback(FED:any):Observable<any>{
    return this.http.get<any>(this.APIUrl+`Feedback?PageNumber=${FED.cnt}&PageSize=10`,FED);
  }
}
