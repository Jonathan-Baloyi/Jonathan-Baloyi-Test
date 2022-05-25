import { Component } from '@angular/core';
import { IMenu } from './models/IMenu';
import { MenuService } from './services/menu.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent {
  title = 'jb-school-app';

  menuItems: IMenu[] = [];
  constructor(private menuService: MenuService) { }

  ngOnInit(): void {
    this.menuService.getMenu().subscribe(val => {
      this.menuItems = val;
    });
  }
}
