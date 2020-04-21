import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BarComponent } from './bar.component';
import { BarUnidadeConfig } from './bar.confg';

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        BarComponent
    ],
    exports: []
})
export class BarModule { 
    static forRoot(config: BarUnidadeConfig) : ModuleWithProviders {
        return {
            ngModule: BarModule,
            providers: [
                { provide: 'configManualUnidade', useValue: config }
            ]
        }
    }

    static forChild() {

    }
}
