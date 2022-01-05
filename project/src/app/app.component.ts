import { Component } from '@angular/core';
import { SpinerService } from './Services/spiner.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(public spinerService:SpinerService) {
    
  }
}
