import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IStudentViewModel } from 'src/app/models/IStudentViewModel';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: []
})
export class StudentListComponent implements OnInit {

  public students: IStudentViewModel[] = [];

  constructor(private studentService: StudentService, private router: Router) { }

  ngOnInit(): void {
    this.studentService.getStudents().subscribe(students => {

      // Sort the array by both school name and surname
      students.sort((a: any, b: any) => {
        if (a.schoolName === b.schoolName) {
          return b.schoolName - a.schoolName;
        }
        return a.surname > b.surname ? 1 : -1;
      });

      this.students = students;
    }, (error: any) => {
      console.error(error);
    });
  }

  onAddStudentBtnClick() {
    this.router.navigate(['/add-student']);
  }
}
