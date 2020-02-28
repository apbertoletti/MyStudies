import { Component } from '@angular/core';

@Component({
  selector: 'app-data-binding',
  templateUrl: './data-binding.component.html'
})
export class DataBindingComponent {
  public contadorClique: number = 0;
  public nomeDigitado: string = "";
  public classeCSS: string = "btn btn-danger";

  public urlImagem: string = "https://angular.io/assets/images/logos/angular/angular.svg"

  adicionarClique(){
    this.contadorClique++;  
  }

  zerarContador(){
    this.contadorClique=0;  
  }

  soltarTecla(event: any){
    this.nomeDigitado = event.target.value;
  }
}
