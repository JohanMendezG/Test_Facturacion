import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';
import { Response } from '../models/response';

const httpOption = {
  Headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {
  url: string = 'https://localhost:44330/api/clientes';
  constructor(
    private _http: HttpClient
  ) { }
  getCliente(id: number): Observable<Response> {
    return this._http.get<Response>(`${this.url}/${id}`);
  }
  getClientes(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
  addClientes(cliente: Cliente): Observable<any> {
    return this._http.post<string>(this.url, cliente);
  }
  editClientes(cliente: Cliente): Observable<any> {
    return this._http.put<string>(this.url, cliente);
  }
  deleteClientes(id: number): Observable<string> {
    return this._http.delete<string>(`${this.url}/${id}`);
  }
}
