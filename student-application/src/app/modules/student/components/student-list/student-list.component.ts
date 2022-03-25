import { Component, OnInit } from '@angular/core';
import { StudentService } from '../../services/student.service'
import { StudentModel } from '../../models/student.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  public studentList: StudentModel[];

  constructor(private studentService: StudentService, private router: Router) {

   }

  ngOnInit(): void {
    this.getAllStudent();

  }

  getAllStudent(){
    this.studentService.getStudentList().subscribe((data) => {
      this.studentList = data;
    });
  }

  studentDetails(id: number){
    this.router.navigate(['student/view/', id]);
  }

  createStudent(){
    this.router.navigate(['student/create']);
  }

}
