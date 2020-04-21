import { Component, OnInit } from '@angular/core';
import { BarService } from './bar.service';
import { BarServiceMock } from './bar-mock.service';

@Component({
    selector: 'app-bar',
    templateUrl: './bar.component.html',
    providers: [
        {provide: BarService, useClass: BarServiceMock}
    ]
})

export class BarComponent implements OnInit {

    barBedida1: string;

    constructor(private barService: BarService) { }

    ngOnInit() { 
        this.barBedida1 = this.barService.getDrink();
    }
}