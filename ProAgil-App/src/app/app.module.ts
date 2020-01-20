import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TooltipModule, ModalModule, BsDatepickerModule } from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { EventoService } from './_services/evento.service';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { EventosComponent } from './eventos/eventos.component';

import { CommonModule } from '@angular/common';

import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { ContatosComponent } from './contatos/contatos.component';
import { TitulosComponent } from './_shared/titulos/titulos.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      EventosComponent,
      DateTimeFormatPipePipe,
      DashboardComponent,
      PalestrantesComponent,
      ContatosComponent,
      TitulosComponent
   ],
   imports: [
      BrowserModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ToastrModule.forRoot({
        timeOut: 1000
      }),
      BrowserAnimationsModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
     ],
     providers: [
        EventoService
     ],
     bootstrap: [
        AppComponent
     ]
  })
  export class AppModule { }
