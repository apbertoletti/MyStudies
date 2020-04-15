import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';

import { AppComponent } from './app.component';
import { NavegacaoModule } from './navegacao/navegacao.module';
import { InstitucionalModule } from './institucional/institucional.module';
import { CadastroModule } from './demos/reactiveForms/cadastro.module';
import { AppRoutingModule } from './app.routes';
import { AuthGuard } from './services/app.guard';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    NavegacaoModule,
    InstitucionalModule,
    CadastroModule,
    AppRoutingModule
  ],
  providers: [
    {provide: APP_BASE_HREF, useValue: '/'},
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
