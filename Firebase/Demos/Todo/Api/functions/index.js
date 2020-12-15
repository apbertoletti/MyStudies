const functions = require('firebase-functions');
const express = require('express');
const admin = require('firebase-admin');

const serviceAccont = require('./todolist-73aea-firebase-adminsdk-zvk4b-a6d5530af1.json');

admin.initializeApp({
    credential: admin.credential.cert(serviceAccont)
})

const app = express();

app.get('/', (req, res) => {
    res.json({ success: true })
})

app.get('/teste', (req, res) => {
    res.json({ success: true, message: 'Deu bom!' })
})

app.post('/createTask', async (req, res) => {
    await admin.firestore().collection('Tasks').add({
        text: req.body.text,
        done: false
    });
    res.json({ success: true });
})

app.post('/completeTask/:id', async (req, res) => {
    await admin.firestore().collection('Tasks').doc(req.params.id).update({
        done: true
    });
    res.json({ success: true });
})

exports.api = functions.https.onRequest(app);

exports.sendNotification = functions.firestore.document('Tasks/{id}').onWrite(async (change) => {
    const data = change.after.data() || {};
    await admin.firestore().collection('Notifications').add({
        text: 'Nova tarefa criada: ' + data.text,
        date: new Date()
    });
});