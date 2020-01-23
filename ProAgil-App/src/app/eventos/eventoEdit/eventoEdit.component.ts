import { Component, OnInit } from '@angular/core';
import { EventoService } from 'src/app/_services/evento.service';
import { BsModalService, BsLocaleService } from 'ngx-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-evento-edit',
  templateUrl: './eventoEdit.component.html',
  styleUrls: ['./eventoEdit.component.css']
})
export class EventoEditComponent implements OnInit {

  titles = 'Editar Eventos';
  registerForm: FormGroup;
  evento = { };


  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private localeService: BsLocaleService,
    private toastr: ToastrService
    ) {
      this.localeService.use('pt-br');
    }

  ngOnInit() {
    this.validation();
  }


  validation() {
    this.registerForm = this.fb.group({
      tema:  ['',  [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local:  ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      dataEvento:  ['', Validators.required],
      imagemUrl:  ['', Validators.required],
      qtdePessoas:  ['', [Validators.required, Validators.max(5000)]],
      telefone:  ['', Validators.required],
      email:  ['', [Validators.required, Validators.email]],
      lotes: this.fb.group({

      })


    });
  }

}
