import { Component, OnInit } from '@angular/core';
import { IStudentViewModel } from 'src/app/models/IStudentViewModel';
import { StudentService } from '../../../services/student.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: []
})
export class HomeComponent implements OnInit {


  constructor() { }

  ngOnInit(): void {
  }
}
