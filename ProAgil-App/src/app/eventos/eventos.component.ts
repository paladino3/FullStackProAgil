import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

/*
  get filtoList(): string {
    return this.filtroList;
  }
  set filtroList(value: string) {
    this.filtroList = value;
    this.eventosFiltrados = this.filtroList ? this.filtrarEventos(this.filtroList) : this.eventos;
  }
  */
  eventosFiltrados: any = [];
  eventos: any = [];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  filtroSearch = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEventos();
  }

  /*filtrarEventos(filtrarPor: string): any {
    filtrarPor =  filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1);
  }
*/

  alternarImg() {
    this.mostrarImagem = !this.mostrarImagem;
  }


  getEventos() {

    this.eventos = this.http.get('http://localhost:5000/api/values').subscribe(
      response => {
        this.eventos =  response;
        console.log(response);
      }, error => {
        console.log(error);
      });

    }
  }
