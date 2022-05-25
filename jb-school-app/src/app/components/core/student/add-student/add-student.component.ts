import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: []
})
export class AddStudentComponent implements OnInit {

  studentForm = new FormGroup({
    name: new FormControl(),
    surname: new FormControl(),
    dateOfBirth: new FormControl(),
    gender: new FormControl(),
    grade: new FormControl(),
    schoolCode: new FormControl(),
    schoolName: new FormControl()
  });


  constructor(
    private formBuilder: FormBuilder,
    private studentService: StudentService,
    private router: Router
  ) {
    this.createForm();
  }

  ngOnInit(): void {

  }

  onSubmit() {
    this.studentService.addStudent(this.studentForm.value).subscribe((res: any) => {
      //Route back to home after saving successfully
      this.router.navigate(['/home']);
    }, (error: any) => {
      console.error(error);
    });
  }

  createForm() {
    this.studentForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      surname: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      grade: ['', [Validators.required]],
      schoolCode: ['', [Validators.required]],
      schoolName: ['', [Validators.required]]
    });
  }

}
