import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ApiclienteService } from '../../../Services/apicliente.service';

@Component({
  selector: 'app-cliente-confirmacion',
  templateUrl: './confcliente.component.html',
  styleUrls: ['./confcliente.component.scss']
})
export class ConfClienteComponent {
  public id: number;
  constructor(
    private apiCliente: ApiclienteService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }
  ngOnInit() {
    let id = +this._route.snapshot.params.id;
    this.id = id;
  }
  Delete() {
    this.apiCliente.deleteClientes(this.id).subscribe(response => {
      alert(response);
      this.Onback();
    });
  }
  Onback(): void {
    this._router.navigate(['/cliente']);
  }
}
