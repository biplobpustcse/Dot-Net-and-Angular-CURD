import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Card } from './models/card.model';
import { CardsService } from './service/cards.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  cards:Card[] =[];
  card: Card = {
    id: '',
    cardHolderName: '',
    cardNumber: '',
    expireMonth: '',
    expireYear: '',
    cvc: ''
  }
  constructor(private modalService: NgbModal,private cardsService:CardsService) {
  }
  ngOnInit(): void {
    this.getAllcards();
  }
  getAllcards(){
    this.cardsService.getAllCards()
    .subscribe(
      response =>{
        this.cards = response;
        console.log(response);
      }
    )
    ;
  }
  onSubmit(){
    if(this.card.id ===''){
      this.cardsService.saveCard(this.card)
      .subscribe(
        response =>{
          this.getAllcards();
          this.card={   
            id: '',
            cardHolderName: '',
            cardNumber: '',
            expireMonth: '',
            expireYear: '',
            cvc: ''     
          }
          console.log(response);
        }
      )
    }
    else{
      this.updateCard(this.card.id,this.card);   
    }
   
  }
  updateCard(id:string,card:Card){
    this.cardsService.updateCard(id,card)
    .subscribe(
      response=>{
        this.cardsService.getAllCards();
      }
    );
  }
  deleteCard(id:string){
    this.cardsService.deleteCard(id)
    .subscribe(
      response=>{
        this.getAllcards();
      }
    );
  }
  selectCard(card:Card){
    this.card = card;
  }

  public open(modal: any): void {
    this.modalService.open(modal);
  }
  title = 'cards';
}
