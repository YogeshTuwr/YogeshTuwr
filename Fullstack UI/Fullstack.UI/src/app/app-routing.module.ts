import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employees/employee-list/employee-list.component';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/employees/edit-employee/edit-employee.component';
import { DepartmentListComponent } from './components/departments/department-list/department-list.component';
import { AddDepartmentComponent } from './components/departments/add-department/add-department.component';
import { EditDepartmentComponent } from './components/departments/edit-department/edit-department.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [{
  path: '',
  component:LoginComponent,
  pathMatch:'full'
},
{
  path:'Login',
  component:LoginComponent
  
},
{path:'employees',
component:EmployeeListComponent
},{
  path:'employees/add',
  component: AddEmployeeComponent
},
{
  path:'employees/edit/:id',
  component: EditEmployeeComponent
},
{
  path:"departments",
  component:DepartmentListComponent},
  {
    path:'departments/add',
    component:AddDepartmentComponent
  },
  {path:'departments/edit/:id',
component:EditDepartmentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
