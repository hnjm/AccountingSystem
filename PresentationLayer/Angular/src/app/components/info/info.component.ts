import { Component, OnInit } from '@angular/core';
import { OperationService } from 'src/app/services/operation.service';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styles: []
})
export class InfoComponent implements OnInit {

  constructor(private service:OperationService) { }

  ngOnInit() {
    this.service.getInfo()
  }

}
