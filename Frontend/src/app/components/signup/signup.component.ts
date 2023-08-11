import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FeedbacksService } from 'src/app/services/feedbacks.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  signupForm!: FormGroup;
  constructor(private fb:FormBuilder,private signupService:FeedbacksService,private router:Router){

  }
  ngOnInit(): void {
    this.signupForm=this.fb.group({
      name:['',Validators.required],
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
signup(){
    if(this.signupForm.valid){
      this.signupService.signingUp(this.signupForm.value).subscribe({
        next:(res=>{
          alert(res.message);
          this.signupForm.reset();
          this.router.navigate(['']);
        }),
        error:(err=>{
          alert(err?.error.message)
        })
      })
    }
    else{
      alert("Provide Correct Information");
    }
}

}

