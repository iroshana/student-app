import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentListComponent } from './components/student-list/student-list.component';
import {StudentCreateViewComponent } from './components/student-create-view/student-create-view.component'

const routes: Routes = [
  {
    path: 'student', children: [
      {path: 'list', component: StudentListComponent },
      {path: 'create', component: StudentCreateViewComponent },
      {path: 'view/:id', component: StudentCreateViewComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
