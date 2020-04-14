import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, ViewChildren, Query, QueryList } from '@angular/core';
import { Produto } from '../models/produto';
import { Observable, fromEvent } from 'rxjs';
import { ProdutoCountComponent } from '../componentes/produto-count.component';
import { ProdutoDetalheComponent } from '../componentes/produto-card-detalhe.component';

@Component({
  selector: 'app-produto-dashboard',
  templateUrl: './produto-dashboard.component.html',
  styles: []
})
export class ProdutoDashboardComponent implements OnInit, AfterViewInit {

  produtos: Produto[]

  @ViewChildren(ProdutoDetalheComponent)
  produtoCards: QueryList<ProdutoDetalheComponent> 
  
  @ViewChild(ProdutoCountComponent, { static: false })
  mensagemContador: ProdutoCountComponent

  @ViewChild('cabecalhoProdutos', { static: false })
  mensagemTela: ElementRef

  constructor() { }

  ngAfterViewInit(): void {
    //Podemos interagir com o estado do objeto, ou mesmo ele por completo.
    console.log('Objeto do contador: ', this.mensagemContador.produtos);

    let clickCabecalho: Observable<any> = fromEvent(this.mensagemTela.nativeElement, 'click');
    clickCabecalho.subscribe(() => {
      alert('Clicou no texto!');
      return;
    })

    console.log(this.produtoCards);
    this.produtoCards.forEach(p => {
      console.log(p.produto);
    })
  }

  ngOnInit() {
    this.produtos = [{
      id: 1,
      nome: 'Teste',
      ativo: true,
      valor: 100,
      imagem: 'celular.jpg'
    },
    {
      id: 2,
      nome: 'Teste 2',
      ativo: false,
      valor: 200,
      imagem: 'gopro.jpg'
    },
    {
      id: 3,
      nome: 'Teste 3',
      ativo: true,
      valor: 300,
      imagem: 'laptop.jpg'
    },
    {
      id: 4,
      nome: 'Teste 4',
      ativo: true,
      valor: 400,
      imagem: 'mouse.jpg'
    },
    {
      id: 5,
      nome: 'Teste 5',
      ativo: true,
      valor: 500,
      imagem: 'teclado.jpg'
    },
    {
      id: 6,
      nome: 'Teste 6',
      ativo: false,
      valor: 600,
      imagem: 'headset.jpg'
    }];
  }

  mudarStatus(evento: Produto) {
    evento.ativo = !evento.ativo;
  }

}
