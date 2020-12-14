import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public newTodoItem = "";
  public list = [
    {text: 'Tarefa 1', done: true }, 
    {text: 'Tarefa 2', done: false }, 
    {text: 'Tarefa 3', done: true }, 
  ]

  addNewItem(): void {
    alert(this.newTodoItem);
  }
}
