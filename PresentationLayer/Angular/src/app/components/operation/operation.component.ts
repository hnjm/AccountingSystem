import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { OperationService } from 'src/app/services/operation.service';
import { Operation } from 'src/app/models/operation.model';

@Component({
  selector: 'app-operation',
  templateUrl: './operation.component.html',
  styles: []
})
export class OperationComponent implements OnInit {

  constructor(private service:OperationService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    
    this.service.data = {
      id: 0,
      description: '', 
      amount: null,
      type: null,
      totalAmount: 0,
      date: ''
    }
  }

  onSubmit(form: NgForm){
    this.service.add().subscribe(
      res => {
        this.resetForm(form);
        this.service.getInfo();
        this.service.getList();
      },
      err => {
        console.log(err.error);
      }
    )
  }

}
