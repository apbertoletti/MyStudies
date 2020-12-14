import { Component } from '@angular/core';
import { AngularFirestore } from '@angular/fire/firestore';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public newTodoItem = "";
  public list = [];

  constructor(private firestore: AngularFirestore) {
    this.firestore.collection('Tasks').valueChanges({ idField: 'id' }).subscribe((data) => {
      this.list = data;
    })
  }

  addNewItem(): void {
    this.firestore.collection('Tasks').add({
      text: this.newTodoItem,
      done: false
    }).then(() => {
      this.newTodoItem = '';
    });
  }

  checkTask(event): void {
    const id = event.option.value.id;
    const checked = event.option.selected;

    this.firestore.collection('Tasks').doc(id).update({
      done: checked
    });
  }
}
