import { Component, Input } from '@angular/core';
import { Produto } from '../models/produto';

@Component({
    selector: 'produto-count',
    templateUrl: 'produto-count.component.html'
})

export class ProdutoCountComponent {
    @Input()
    produtos: Produto[];

    contarAtivos(): number {
        if (!this.produtos)
            return;

        return this.produtos.filter((prod: Produto) => prod.ativo).length;
    }
}