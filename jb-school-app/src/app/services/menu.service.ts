import { IMenu } from '../models/IMenu';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class MenuService {
  constructor() { }

  public getMenu(): Observable<IMenu[]> {
    const homeMenuItem: IMenu = {
      name: 'Home',
      link: '/home',
      isCurrent: false,
      isDisabled: false
    };

    const aboutMenuItem: IMenu = {
      name: 'About',
      link: '/about',
      isCurrent: false,
      isDisabled: false
    };

    const contactMenuItem: IMenu = {
      name: 'Contact',
      link: '/contact',
      isCurrent: false,
      isDisabled: false
    };

    /* Incase menu items are required in the future, we'll just uncomment the following code */
    const menuItems: IMenu[] = [];
    menuItems.push(homeMenuItem);
    menuItems.push(aboutMenuItem);
    menuItems.push(contactMenuItem);

    const res: Observable<IMenu[]> = of(menuItems);
    return res;
  }
}
