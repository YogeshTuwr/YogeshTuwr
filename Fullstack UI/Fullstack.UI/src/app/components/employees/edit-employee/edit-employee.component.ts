import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { employee } from 'src/app/models/employee.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit{
  /**
   *
   */
  employeeDetails: employee={
    id:'',
    name:'',
    email:'',
    phone:0,
    salary:0,
    department:''
  };
  constructor( private route:ActivatedRoute,private sharedService: SharedService,private router:Router) {
    
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe({next:(params)=>{
      
      const id= params.get('id');
      console.log(params.get('id'));
      if(id){
        this.sharedService.GetEmployee(id).subscribe({
          next: (employeeRes)=>{
            console.log(employeeRes);
             this.employeeDetails=employeeRes;
            //this.employees=employees;
          },
          error:(Response)=>{
             console.log(Response) 
          }
        })
      }
    }
    })
  }

  UpdateEmployee(){
    this.sharedService.updateEmployee(this.employeeDetails.id,this.employeeDetails).subscribe(
     {
      next:(Response)=>{
        this.router.navigate(['employees']);
      }
     } 
    )
  }

  deleteEmployee(id:string){
    this.sharedService.deleteEmployee(id).subscribe(
      {
       next:(Response)=>{
         this.router.navigate(['employees']);
       }
      } 
     )
  }

}
