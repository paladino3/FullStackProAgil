import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-titulos',
  templateUrl: './titulos.component.html',
  styleUrls: ['./titulos.component.css']
})
export class TitulosComponent implements OnInit {
 @Input() titulos: string;
  constructor() { }

  ngOnInit() {
  }

}
