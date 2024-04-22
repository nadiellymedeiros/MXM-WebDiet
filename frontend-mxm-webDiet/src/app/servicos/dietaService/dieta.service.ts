import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dieta } from '../../modelos/dieta';

@Injectable({
  providedIn: 'root',
})
export class DietaService {
  constructor(private http: HttpClient) {}

  private urlDieta: string = 'http://localhost:5265/api/diet';

  criarPrompt(obj: any): Observable<any> {
    return this.http.post<any>(this.urlDieta, obj);
  }

  // listarDietas(): Observable<any[]> {
  //   return this.http.get<any[]>(this.urlDieta);
  // }
}
