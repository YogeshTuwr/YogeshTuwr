import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { employee } from '../models/employee.model';
import { Observable } from 'rxjs';
import { EmployeeListComponent } from '../components/employees/employee-list/employee-list.component';
import { AddEmployeeComponent } from '../components/employees/add-employee/add-employee.component';
import { department } from '../models/department.model';
import { usermaster } from '../models/usermaster.model';
   

@Injectable({
  providedIn: 'root'
})
export class SharedService {

readonly ApiUrl:string = 'https://localhost:7095/api';
constructor( private http:HttpClient) {}
GetAllEmployees():Observable<employee[]>{
  //return this.http.get<employee[]>(ApiUrl + "/Employees");
  console.log("https://localhost:7095/api/Employees");
//return this.http.get<employee[]>("https://localhost:7095/api/Employees")
return this.http.get<employee[]>(this.ApiUrl +"/Employees")
}

GetAllDepartment():Observable<department[]>{
  console.log(this.ApiUrl +"/Departments");
  return this.http.get<department[]>(this.ApiUrl +"/Departments")
}

AddEmployees(AddEmployeeReq:employee):Observable<employee>{
  AddEmployeeReq.id="00000000-0000-0000-0000-000000000000";
  console.log("Serv : " + AddEmployeeReq.id);
//return this.http.post<employee>("https://localhost:7095/api/Employees",AddEmployeeReq);
return this.http.post<employee>(this.ApiUrl +"/Employees",AddEmployeeReq);
}
AddDepartments(AddDepartmentReq:department):Observable<department>{
 // AddEmployeeReq.id="00000000-0000-0000-0000-000000000000";
  //console.log("Serv : " + AddEmployeeReq.id);
//return this.http.post<employee>("https://localhost:7095/api/Employees",AddEmployeeReq);
return this.http.post<department>(this.ApiUrl +"/Departments",AddDepartmentReq);
}



GetEmployee(Id:String):Observable<employee>{
  //console.log("https://localhost:7095/api/Employees/");
//return this.http.get<employee>( "https://localhost:7095/api/Employees/"+Id);
return this.http.get<employee>( this.ApiUrl +"/Employees/"+Id);
}

GetDepartment(Id:number):Observable<department>{
  debugger;
  //console.log("https://localhost:7095/api/Employees/");
//return this.http.get<employee>( "https://localhost:7095/api/Employees/"+Id);
return this.http.get<department>( this.ApiUrl +"/Departments/"+Id);
}



GetSignIn(ObjuserMaster:usermaster):Observable<usermaster>{
  debugger;
  //console.log("https://localhost:7095/api/Employees/");
//return this.http.get<employee>( "https://localhost:7095/api/Employees/"+Id);
return this.http.post<usermaster>( this.ApiUrl +"/Logins/",ObjuserMaster);
}


updateEmployee(Id:String,updateEmployeeReq:employee):Observable<employee>{
  console.log("https://localhost:7095/api/Employees/");
  return this.http.put<employee>("https://localhost:7095/api/Employees/"+Id,updateEmployeeReq);
  }
  deleteEmployee(id:String):Observable<employee>{
    //console.log("https://localhost:7095/api/Employees/");
  //return this.http.delete<employee>( "https://localhost:7095/api/Employees/"+id);
  return this.http.delete<employee>( this.ApiUrl +"/Employees/"+id);
  }

  updateDepartment(Id:number,updateDepartmentReq:department):Observable<department>{
    console.log("https://localhost:7095/api/Employees/");
    return this.http.put<department>("https://localhost:7095/api/Departments/"+Id,updateDepartmentReq);
    }
    deleteDepartment(id:number):Observable<department>{
      //console.log("https://localhost:7095/api/Employees/");
    //return this.http.delete<employee>( "https://localhost:7095/api/Employees/"+id);
    return this.http.delete<department>( this.ApiUrl +"/Departments/"+id);
    }
    
}
