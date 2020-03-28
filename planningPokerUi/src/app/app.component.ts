import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public static apiUrl = 'http://localhost:5001/api';
  public static title = 'planningPokerUi';
}
