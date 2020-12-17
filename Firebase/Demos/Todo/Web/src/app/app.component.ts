import { Component } from '@angular/core';
import { AngularFirestore } from '@angular/fire/firestore';
import { PushNotificationService } from './services/push-notification.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public newTodoItem = "";
  public list = [];
  private mesaggeReceived = '';

  constructor(private firestore: AngularFirestore, private notification: PushNotificationService) {
    this.firestore.collection('Tasks').valueChanges({ idField: 'id' }).subscribe((data) => {
      this.list = data;
    });

    notification.requestPermission().then(token => {
      console.log(token);
    })
  }

  ngOnInit(): void {
    this.notification.receiveMessage().subscribe(payload => {
      console.log(payload);
      this.mesaggeReceived = payload.notification.title;
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
