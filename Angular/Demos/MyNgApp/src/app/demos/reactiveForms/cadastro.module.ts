import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';

import { NgBrazil } from 'ng-brazil';
import { TextMask } from 'ng-brazil';
import { CustomFormsModule } from 'ng2-validation'
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        CadastroComponent
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        RouterModule,
        TextMask.TextMaskModule,
        NgBrazil,
        CustomFormsModule,
    ],
    exports: [
        CadastroComponent
    ]
})
export class CadastroModule{}