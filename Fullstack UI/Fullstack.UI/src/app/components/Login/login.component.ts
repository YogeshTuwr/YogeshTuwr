import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { SharedService } from 'src/app/services/shared.service';
import { FormControl, Validators, FormGroup, FormBuilder, AbstractControl } from '@angular/forms'
import { usermaster } from 'src/app/models/usermaster.model';
import { textChangeRangeIsUnchanged } from 'typescript';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  ObjuserMaster: usermaster = {
    emailId: '',
    password: '',
    id: 0,
    fullName: '',
    designation: '',
    userMessage: '',
    accessToken: '',

  };


  // email: string = '';
  // password: string = '';
  constructor(private router: Router, private SharedService: SharedService) { }




  ngOnInit(): void { }
  // SignIn() {
  //   debugger;
  //   if (this.email == '') {
  //     alert('Please enter email Address');
  //     return;
  //   }
  //   if (this.password == '') {
  //     alert('Please enter password');
  //     return;
  //   }
  //   this.SharedService.GetSignIn(this.email,this.password).subscribe(
  //     {
  //       next: (Response) => {
  //         alert('Login successful');
  //         this.router.navigate(['employees']);
  //       },
  //       error(Error){
  //         //alert('Login Fail Please check User Name and Password..');
  //         console.log(Error.message);
  //       }
  //     }
  //   )
  // }
  SignIn() {

    if (this.ObjuserMaster.emailId == '') {
      alert('Please enter email Address');
      return;
    }
    if (this.ObjuserMaster.password == '') {
      alert('Please enter password');
      return;
    }
    this.SharedService.GetSignIn(this.ObjuserMaster).subscribe((res: any) => {
      if (res.userMessage == 'Login Success') {
        
        debugger;
        let token = res.accessToken;
        // if (token) {
        //   Request = res.clone({
        //     setHeaders: {
        //       Authorization: 'Bearer ${token}'
        //     }
        //   })
        //   alert('Login successful');
        //   this.router.navigate(['employees']);
        // }

        alert('Login successful');
          this.router.navigate(['employees']);
        
      }
      else {

      }
    })
  };
}
