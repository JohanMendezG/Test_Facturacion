import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Cliente } from '../../../models/cliente';
import { ApiclienteService } from '../../../Services/apicliente.service';

@Component({
  selector: 'app-cliente-formulario',
  templateUrl: './formcliente.component.html',
  styleUrls: ['./formcliente.component.scss']
})
export class FormClienteComponent {
  public id: number;
  public documento: number;
  public nombres: string;
  public primerApellido: string;
  public segundoApellido: string;
  public edad: number;
  constructor(
    private apiCliente: ApiclienteService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }
  ngOnInit() {
    let id = +this._route.snapshot.params.id;
    this.id = id;
    if (id != 0) {
      this.GetCliente();
    }
  }
  ClienteRequest() {
    const cliente: Cliente = {
      Documento: this.documento,
      Nombres: this.nombres,
      PrimerApellido: this.primerApellido,
      SegundoApellido: this.segundoApellido,
      Edad: this.edad
    };
    if (this.id == 0) {
      this.apiCliente.addClientes(cliente).subscribe(response => {
        alert(response);
        this.Onback();
      });
    } else {
      this.apiCliente.editClientes(cliente).subscribe(response => {
        alert(response);
        this.Onback();
      });
    }
  }
  GetCliente() {
    this.apiCliente.getCliente(this.id).subscribe(response => {
      this.documento = response.Documento;
      this.nombres = response.Nombres;
      this.primerApellido = response.PrimerApellido;
      this.segundoApellido = response.SegundoApellido;
      this.edad = response.Edad;
    });
  }
  Onback(): void {
    this._router.navigate(['/cliente']);
  }
}
