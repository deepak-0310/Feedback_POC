import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'POC_FeedbackDemo';
  isLoginPage:boolean=false;
  constructor(private router:Router){
    
  }
  ngOnInit(){
    this.router.events.subscribe(event=>{
      if(event instanceof NavigationEnd){
        this.isLoginPage=event.url==='';
      }
    })
  }
}
