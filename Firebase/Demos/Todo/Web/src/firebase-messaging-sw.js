importScripts('https://www.gstatic.com/firebasejs/8.2.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.2.0/firebase-messaging.js');

firebase.initializeApp(
{
    apiKey: "AIzaSyB0pVrn057AT8WWzD2-47yCz_SLCNhkS6c",
    authDomain: "todolist-73aea.firebaseapp.com",
    projectId: "todolist-73aea",
    storageBucket: "todolist-73aea.appspot.com",
    messagingSenderId: "302237195625",
    appId: "1:302237195625:web:4885efb8fd2be2578e71f8",
    measurementId: "G-4B58YZMY92"
});

const messaging = firebase.messaging();