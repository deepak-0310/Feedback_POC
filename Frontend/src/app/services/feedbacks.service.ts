import { Injectable } from '@angular/core';
import { UserFeedback } from 'src/models/Feedback';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class FeedbacksService {
  APIUrl: string = "https://localhost:7016/api/Feedback";
  constructor(private http: HttpClient) { }
  addFeedback(addFeedbackRequest:any): Observable<UserFeedback> {
    return this.http.post<any>(this.APIUrl, addFeedbackRequest);
  }
  getFeedback():Observable<any>{
    return this.http.get<any>(this.APIUrl);
  }
}
