import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Card } from '../models/card.model';

@Injectable({
  providedIn: 'root'
})
export class CardsService {
baseUrl='https://localhost:7052/api/Cards';

  constructor(private http: HttpClient) { }
  //get all cards
  getAllCards(): Observable<Card[]>{
    return this.http.get<Card[]>(this.baseUrl)
  }
  //save card
  saveCard(card: Card):Observable<Card>{
    card.id='00000000-0000-0000-0000-000000000000';
    return this.http.post<Card>(this.baseUrl,card);
  }
  //delete card
  deleteCard(id:string):Observable<Card>{
    return this.http.delete<Card>(this.baseUrl + "/" + id);
  }
  //update card
  updateCard(id:string,card:Card):Observable<Card>{
    return this.http.put<Card>(this.baseUrl + "/" + id,card);
  }
}
