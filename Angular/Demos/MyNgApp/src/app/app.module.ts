import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';
import { NavegacaoModule } from './navegacao/navegacao.module';
import { InstitucionalModule } from './institucional/institucional.module';
import { CadastroModule } from './demos/reactiveForms/cadastro.module';
import { AppRoutingModule } from './app.routes';
import { AuthGuard } from './services/app.guard';
import { CadastroGuard } from './services/cadastro.guard';
import { FilmesComponent } from './demos/pipes/filmes/filmes.component';
import { FileSizePipe } from './demos/pipes/filmes/filesize.pipe';
import { ImageFormaterPipe } from './demos/pipes/filmes/image.pipe';
import { BarModule } from './demos/bar-di-zones/bar.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    FilmesComponent,
    FileSizePipe,
    ImageFormaterPipe
  ],
  imports: [
    BrowserModule,
    NavegacaoModule,
    InstitucionalModule,
    CadastroModule,
    AppRoutingModule,
    HttpClientModule,
    BarModule.forRoot({
      unidadeId: 1000,
      unidadeToken: 'esad324ga3gaghas14dc'
    })
  ],
  providers: [
    {provide: APP_BASE_HREF, useValue: '/'},
    AuthGuard,
    CadastroGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
