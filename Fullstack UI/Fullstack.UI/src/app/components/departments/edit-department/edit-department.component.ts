import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { department } from 'src/app/models/department.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.css']
})
export class EditDepartmentComponent implements OnInit {
  departmentDetails: department={
    id:0,
    departmentName:''
    };
  ngOnInit(): void {
    
    this.route.paramMap.subscribe({next:(params)=>{
      debugger;
      const id=params.get('id');
      console.log(params.get('id'));
      if(id){
        this.SharedService.GetDepartment(parseInt(id)).subscribe({
          next: (departmentRes)=>{
            console.log(departmentRes);
             this.departmentDetails=departmentRes;
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
  constructor(private SharedService:SharedService, private route:ActivatedRoute, private router:Router) {
  }
  UpdateDepartment(){
    this.SharedService.updateDepartment(this.departmentDetails.id,this.departmentDetails).subscribe(
     {
      next:(Response)=>{
        this.router.navigate(['departments']);
      }
     } 
    )
  }

  deletedepartment(id:number){
    this.SharedService.deleteDepartment(id).subscribe(
      {
       next:(Response)=>{
         this.router.navigate(['departments']);
       }
      } 
     )
  }


}
