import { Component } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';

@Component({
  selector: 'app-root',
  template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center" class="content">
      <h1>
        Welcome to {{title}}!
      </h1>
      <span style="display: block">{{ title }} app is running!</span>
      <img width="300" alt="Angular Logo" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyNTAgMjUwIj4KICAgIDxwYXRoIGZpbGw9IiNERDAwMzEiIGQ9Ik0xMjUgMzBMMzEuOSA2My4ybDE0LjIgMTIzLjFMMTI1IDIzMGw3OC45LTQzLjcgMTQuMi0xMjMuMXoiIC8+CiAgICA8cGF0aCBmaWxsPSIjQzMwMDJGIiBkPSJNMTI1IDMwdjIyLjItLjFWMjMwbDc4LjktNDMuNyAxNC4yLTEyMy4xTDEyNSAzMHoiIC8+CiAgICA8cGF0aCAgZmlsbD0iI0ZGRkZGRiIgZD0iTTEyNSA1Mi4xTDY2LjggMTgyLjZoMjEuN2wxMS43LTI5LjJoNDkuNGwxMS43IDI5LjJIMTgzTDEyNSA1Mi4xem0xNyA4My4zaC0zNGwxNy00MC45IDE3IDQwLjl6IiAvPgogIDwvc3ZnPg==">
    </div>
    <h2>Here are some links to help you start: </h2>
    <ul>
      <li>
        <h2><a target="_blank" rel="noopener" href="https://angular.io/tutorial">Tour of Heroes</a></h2>
      </li>
      <li>
        <h2><a target="_blank" rel="noopener" href="https://angular.io/cli">CLI Documentation</a></h2>
      </li>
      <li>
        <h2><a target="_blank" rel="noopener" href="https://blog.angular.io/">Angular blog</a></h2>
      </li>
    </ul>
    
  `,
  styles: []
})
export class AppComponent {
  title = 'RXJS';

  minhaPrommisse(nome: string) : Promise<string> {
    return new Promise((res, rej) => {
      if (nome === 'André'){
        res('Bem vindo ' + nome);
      }
      else{
        rej('Ops! Você não é o André')
      }
    });
  }

  minhaObservable(nome: string) : Observable<string> {
    return new Observable(subs => {
      if (nome === 'André') {
        subs.next('Olá! ' + nome);
        subs.next('Olá ' + nome + ' novamente!');
        setTimeout(() => {
          subs.next('Resposta com delay"');
        }, 5000);
        subs.complete();
      }
      else{
        subs.error('Ops... deu erro!')
      }
    })
  }

  usuarioObservable(nome: string, email: string) : Observable<Usuario> {
    return new Observable(subs => {
      if (nome === 'Admin') {
        let usuario = new Usuario(nome, email);      
        setTimeout(() => {
          subs.next(usuario);
        }, 1000);

        setTimeout(() => {
          subs.next(usuario);
        }, 3000);
        
        setTimeout(() => {
          subs.next(usuario);
        }, 5000);

        setTimeout(() => {
          subs.next(usuario);
        }, 7000);

        setTimeout(() => {
          subs.complete();
        }, 9000);
      }
      else{
        subs.error('Ops... deu erro!')
      }
    })
  }

  ngOnInit(): void {
    // this.minhaPrommisse('André')
    //   .then(res => console.log(res))
    //   .catch(err => console.log(err));

    // this.minhaObservable('André')
    //   .subscribe(
    //     result => console.log(result),
    //     err => console.log(err));    

    const observer = {
      next: val => this.escrever(val),
      erro: err => this.escrever(err),
      complete: () => console.log('FIM!')
    }

    // const obs = this.minhaObservable('André');
    // obs.subscribe(observer);

    const obs = this.usuarioObservable('Admin', 'admin@admin.com');
    const subs = obs.subscribe(observer);

    setTimeout(() => {
      subs.unsubscribe();
      this.escrever('Conexão fechada: ' + subs.closed);
    }, 3500);

  }

  escrever(texto: string) {
    console.log(texto)
  }
}

export class Usuario {
  email: string;
  nome: string;

  constructor(nome: string, email: string) {
    this.nome = nome;
    this.email = email;
  }
}
