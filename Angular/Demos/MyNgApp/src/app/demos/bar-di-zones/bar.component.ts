import { Component, OnInit, Inject } from '@angular/core';
import { BarService, BarFactory } from './bar.service';
import { BarServiceMock } from './bar-mock.service';
import { BarUnidadeConfig, BAR_UNIDADE_CONFIG } from './bar.confg';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-bar',
    templateUrl: './bar.component.html',
    providers: [
        //Comentado esta primeira abordagem de resolução de DI, para utilizar a próxima via Factory
        /* { provide: BarService, useClass: BarServiceMock } */ 
        {
            provide: BarService,
            useFactory: BarFactory, 
                        deps: [
                            HttpClient, BAR_UNIDADE_CONFIG
                        ]
        }
    ]
})

export class BarComponent implements OnInit {

    configUnidade: BarUnidadeConfig;
    barBedida1: string;
    dadosUnidade: string;

    constructor(
        private barService: BarService,
        @Inject(BAR_UNIDADE_CONFIG) private apiConfigManual: BarUnidadeConfig
        ) { }

    ngOnInit() { 
        this.barBedida1 = this.barService.getDrink();
        this.configUnidade = this.apiConfigManual;
        this.dadosUnidade = this.barService.getBarConfig();
    }
}