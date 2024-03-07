import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { employee } from 'src/app/models/employee.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  AddEmployeeReq:employee={
    id:'',
    name:'',
    email:'',
    phone:0,
    salary:0,
    department:''
  };
  ngOnInit(): void {
    
  }
  constructor(private SharedService: SharedService,private router:Router) {  }
    addEmployee(){
console.log(this.AddEmployeeReq);
  this.SharedService.AddEmployees(this.AddEmployeeReq).subscribe({
    next: (employee)=>{
      
       this.router.navigate(['employees']);
      //this.employees=employees;
    },
    error:(Response)=>{
       console.log(Response) 
    }
  })
}
}
