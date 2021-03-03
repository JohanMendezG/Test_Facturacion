import { Component, OnInit } from '@angular/core';
import { Response } from '../../models/response';
import { ApiclienteService } from '../../services/apicliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent {
  public clientes: Response;
  constructor(
    private apiCliente: ApiclienteService
  ) { }
  ngOnInit(): void {
    this.getClientes();
  }
  getClientes() {
    this.apiCliente.getClientes().subscribe(response => {
      this.clientes = response;
    });
  }
}
