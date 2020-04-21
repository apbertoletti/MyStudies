import { Component, OnInit, Inject } from '@angular/core';
import { BarService } from './bar.service';
import { BarServiceMock } from './bar-mock.service';
import { BarUnidadeConfig, BAR_UNIDADE_CONFIG } from './bar.confg';

@Component({
    selector: 'app-bar',
    templateUrl: './bar.component.html',
    providers: [
        { provide: BarService, useClass: BarServiceMock }
    ]
})

export class BarComponent implements OnInit {

    configUnidade: BarUnidadeConfig;
    barBedida1: string;

    constructor(
        private barService: BarService,
        @Inject(BAR_UNIDADE_CONFIG) private apiConfigManual: BarUnidadeConfig
        ) { }

    ngOnInit() { 
        this.barBedida1 = this.barService.getDrink();
        this.configUnidade = this.apiConfigManual;
    }
}