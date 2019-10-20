import { Injectable } from '@angular/core';
import { Operation } from '../models/operation.model';
import { HttpClient } from '@angular/common/http';
import { Info } from '../models/info.model';

@Injectable({
  providedIn: 'root'
})
export class OperationService {
  readonly url = 'http://localhost:51775/api/operation';

  info: Info;
  data: Operation;
  list: Operation[];
  filter: number;

  types = [
    {id: 1, name: "Debit"},
    {id: 2, name: "Credit"}
  ];

  constructor(private http: HttpClient) { }

  add(){
    console.log(this.data);
    return this.http.post(this.url, this.data);
  }

  getList(){
    this.http.get(this.url).toPromise().then(res => this.list = res as Operation[]);
  }

  getInfo(){
    this.http.get(this.url + '/info').toPromise().then(res => this.info = res as Info);
  }
}
