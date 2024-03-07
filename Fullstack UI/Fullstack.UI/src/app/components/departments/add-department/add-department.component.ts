import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { department } from 'src/app/models/department.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent implements OnInit {
  AddDepartmentReq:department={
    id:0,
    departmentName:''
  };
  constructor(private SharedService: SharedService,private router:Router) {  }
  ngOnInit(): void { 
  }
  addDepartment(){
    console.log(this.AddDepartmentReq);
      this.SharedService.AddDepartments(this.AddDepartmentReq).subscribe({
        next: (department)=>{
          
           this.router.navigate(['departments']);
          //this.employees=employees;
        },
        error:(Response)=>{
           console.log(Response) 
        }
      })
    }

}
