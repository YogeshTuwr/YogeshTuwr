import { Component, OnInit } from '@angular/core';
import { department } from 'src/app/models/department.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {
  
  departments:department[]=[];
  constructor(private SharedService:SharedService ) {
  }
  ngOnInit(): void {
    this.SharedService.GetAllDepartment().subscribe({
      next: (Departments)=>{
        console.log(Departments)
        this.departments=Departments;
      },
      error:(Response)=>{
         console.log(Response) 
      }
    })
  }

}
