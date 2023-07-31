import { Injectable } from '@angular/core';
import { UserFeedback } from 'src/models/Feedback';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class FeedbacksService {
  APIUrl: string = "http://localhost:3333/api/Feedback";
  constructor(private http: HttpClient) { }
  addFeedback(addFeedbackRequest: UserFeedback): Observable<UserFeedback> {
    return this.http.post<UserFeedback>(this.APIUrl, addFeedbackRequest);
  }
}
