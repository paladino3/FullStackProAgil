import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // importar os FormsModule para buscas em filtro
import { BsDropdownModule, ModalModule, TooltipModule, } from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { EventoService } from './_services/Evento.service';

import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';

import { DateTimeFormatPipePipe } from './_helps/DateTimeFormatPipe.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { setTheme } from 'ngx-bootstrap/utils';

@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent,
      DateTimeFormatPipePipe
   ],
   imports: [
      BrowserModule,
      BsDatepickerModule.forRoot(),
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      BrowserAnimationsModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule, // usei para fazer um filtro de buscas
      ReactiveFormsModule,
      BrowserAnimationsModule,
      // os itens abaixo são do NGX bootstrap, instalei no terminal e realizei as importações acimabundleRenderer.renderToStream
      // ver mais no site: https://valor-software.com/ngx-bootstrap
   ],
   providers: [
      EventoService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
