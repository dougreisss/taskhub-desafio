import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Menu } from './layout/menu/menu';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, Menu],
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})

export class App {

}
