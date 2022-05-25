import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/core/about/about.component';
import { ContactComponent } from './components/core/contact/contact.component';
import { HomeComponent } from './components/core/home/home.component';
import { AddStudentComponent } from './components/core/student/add-student/add-student.component';
import { StudentListComponent } from './components/core/student/student-list/student-list.component';

const routes: Routes = [
  { path: '', component: StudentListComponent },
  { path: 'home', component: StudentListComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'add-student', component: AddStudentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
