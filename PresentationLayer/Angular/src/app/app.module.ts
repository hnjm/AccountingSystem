import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { OperationsComponent } from './components/operations.component';
import { OperationComponent } from './components/operation/operation.component';
import { OperationListComponent } from './components/operation-list/operation-list.component';
import { OperationService } from './services/operation.service';
import { InfoComponent } from './components/info/info.component';

@NgModule({
  declarations: [
    AppComponent,
    OperationsComponent,
    OperationComponent,
    OperationListComponent,
    InfoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [OperationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
