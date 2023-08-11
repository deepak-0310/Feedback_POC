import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FeedbacksService } from 'src/app/services/feedbacks.service';

@Component({
  selector: 'app-loginpage',
  templateUrl: './loginpage.component.html',
  styleUrls: ['./loginpage.component.css']
})
export class LoginpageComponent {
  signinForm!: FormGroup;
  constructor(private fb:FormBuilder,private loginServie:FeedbacksService,private router:Router){

  }
  ngOnInit(): void {
    this.signinForm=this.fb.group({
      email:['',Validators.required],
      password:['',Validators.required]
    })

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
signin(){
  if(this.signinForm.valid){
    this.loginServie.Login(this.signinForm.value).subscribe({
      next:(res)=>{
        alert(res.message);
        this.router.navigate(['feedbackform']);
      },
      error:(err)=>{
        alert(err?.error.message)
      }
    })
  }
  else{
    alert("Provide correct details");
  }
}
}
