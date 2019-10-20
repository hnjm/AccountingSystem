import { Component, OnInit } from '@angular/core';
import { OperationService } from 'src/app/services/operation.service';
import { Operation } from 'src/app/models/operation.model';

@Component({
  selector: 'app-operation-list',
  templateUrl: './operation-list.component.html',
  styles: []
})
export class OperationListComponent implements OnInit {

  constructor(private service: OperationService) { }

  ngOnInit() {
    this.service.getList();
  }

  open(o: Operation) {
    this.service.data = Object.assign({}, o);
  }

}
