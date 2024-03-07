import { Component, OnInit } from '@angular/core';

import { employee } from 'src/app/models/employee.model';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees:employee[]=[];
  constructor(private SharedService:SharedService) {
    //console.log("employee constructor called");
    //this.logger.error("Your log message goes here");
    //this.logger.warn("Multiple", "Argument", "support");
  }
  ngOnInit(): void {
    this.SharedService.GetAllEmployees().subscribe({
      next: (employees)=>{
        console.log(employees)
        this.employees=employees;
      },
      error:(Response)=>{
         console.log(Response) 
      }
    })
  }

}
