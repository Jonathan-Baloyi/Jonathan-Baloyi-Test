import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/core/navbar/navbar.component';
import { FooterComponent } from './components/core/footer/footer.component';
import { HomeComponent } from './components/core/home/home.component';
import { ContainerComponent } from './components/core/container/container.component';
import { MenuService } from './services/menu.service';
import { AboutComponent } from './components/core/about/about.component';
import { ContactComponent } from './components/core/contact/contact.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentService } from './services/student.service';
import { StudentListComponent } from './components/core/student/student-list/student-list.component';
import { AddStudentComponent } from './components/core/student/add-student/add-student.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    ContainerComponent,
    AboutComponent,
    ContactComponent,
    StudentListComponent,
    AddStudentComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CommonModule
  ],
  providers: [MenuService, StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
