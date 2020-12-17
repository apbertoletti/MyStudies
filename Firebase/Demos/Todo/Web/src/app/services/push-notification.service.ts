import { Injectable } from '@angular/core';
import { rejects } from 'assert';
import firebase from 'firebase';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MessagePayload } from './notification-interfaces';

@Injectable({
  providedIn: 'root'
})
export class PushNotificationService {

  messagingFirebase: firebase.messaging.Messaging;

  constructor() { 
    if (!firebase.apps.length) {
      firebase.initializeApp(environment.firebaseConfig);
    } else {
      firebase.app();
    }
    this.messagingFirebase = firebase.messaging();
  } 

  requestPermission = ()=> {
    return new Promise(async (resolve, reject) => {
      const permissao = await Notification.requestPermission();
      if (permissao == "granted") {
        const tokenFirebase = await this.messagingFirebase.getToken();
        resolve(tokenFirebase);
      } else {
        reject(new Error("Não houve permissão de acesso as notificações"))
      }
    })
  }

  messagingObservable = new Observable<MessagePayload>(o => {
    this.messagingFirebase.onMessage(payload => {
      o.next(payload)
    })
  })

  receiveMessage() {
    return this.messagingObservable;
  }
}
