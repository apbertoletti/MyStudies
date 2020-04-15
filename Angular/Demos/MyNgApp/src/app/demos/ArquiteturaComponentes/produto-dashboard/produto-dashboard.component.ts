import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, ViewChildren, Query, QueryList } from '@angular/core';
import { Produto } from '../models/produto';
import { Observable, fromEvent } from 'rxjs';
import { ProdutoCountComponent } from '../componentes/produto-count.component';
import { ProdutoDetalheComponent } from '../componentes/produto-card-detalhe.component';
import { ProdutoService } from '../services/produto.service';
import { ActivatedRoute } from '@angular/router';

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

  constructor(
    private route: ActivatedRoute
  ) { }

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
    this.produtos = this.route.snapshot.data['prods']
  }

  mudarStatus(evento: Produto) {
    evento.ativo = !evento.ativo;
  }

}
