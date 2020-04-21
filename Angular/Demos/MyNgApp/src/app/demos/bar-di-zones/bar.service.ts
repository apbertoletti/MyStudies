import { Injectable, Inject, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BAR_UNIDADE_CONFIG, BarUnidadeConfig } from './bar.confg';

export function BarFactory(http: HttpClient, pilhaInjecao: Injector) {
    return new BarService(http, pilhaInjecao.get(BAR_UNIDADE_CONFIG));
}

@Injectable()
export class BarService {
    constructor(
        private http: HttpClient,
        @Inject(BAR_UNIDADE_CONFIG) private config: BarUnidadeConfig
    ) { }

    getBarConfig(): string{
        return 'Unidade ID: ' + this.config.unidadeId + ' Toke: ' + this.config.unidadeToken;
    }
 
    getDrink(): string{
        return 'Bebidas';
    }

    getFood(): string{
        return 'Comidas';
    }
    
    getSweet(): string{
        return 'Doces';
    }
}