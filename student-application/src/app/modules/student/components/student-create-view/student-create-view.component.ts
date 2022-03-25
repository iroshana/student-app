import { Component, OnInit } from '@angular/core';
import { StudentModel } from '../../models/student.model'
import { StudentService } from '../../services/student.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-student-create-view',
  templateUrl: './student-create-view.component.html',
  styleUrls: ['./student-create-view.component.css']
})
export class StudentCreateViewComponent implements OnInit {
  public student: StudentModel = new StudentModel();
  public isViewForm: boolean;

  public regForm:FormGroup;
  private firstName:FormControl;
  private lastName:FormControl;

  constructor(private studentService: StudentService, private router: Router, private route: ActivatedRoute, private formBuilder:FormBuilder) {
    this.regForm=formBuilder.group({
      firstName:this.firstName,
      lastName: this.lastName
    });
   }

  ngOnInit(): void {
    this.isViewForm = false;   

    if(this.route.routeConfig.path == "view/:id"){
      this.isViewForm = true;

      this.route.params.forEach((params: Params) => {
        let id = params['id'];
        this.studentService.getStudentDetailById(id).subscribe((data) => {
          this.student = data;
        });
      });
    }
  }

  backToList(){
    this.router.navigate(['student/list']);
  }

  saveStudent(){
    debugger;

    this.student.firstName = this.regForm.controls['firstName'].value;
    this.student.lastName = this.regForm.controls['lastName'].value;

    if(!this.regForm.invalid){
      this.studentService.saveStudent(this.student).subscribe((data) => {
        this.backToList();
      });
    }
    
  }
}
