import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonRoutingModule } from './person-routing.module';
import { ListComponent } from './components/list/list.component';
import {HttpClientModule} from '@angular/common/http'
import {MatTableModule} from '@angular/material/table'
import {MatButtonModule} from '@angular/material/button'
import {MatIconModule} from '@angular/material/icon'



@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    PersonRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    HttpClientModule
  ]
})
export class PersonModule { }
