const functions = require('firebase-functions');
const express = require('express')

const app = express();

app.get('/', (req, res) => {
    res.json({ success: true })
})

app.get('/teste', (req, res) => {
    res.json({ success: true, message: 'Deu bom!' })
})

exports.api = functions.https.onRequest(app);

// Create and Deploy Your First Cloud Functions
// https://firebase.google.com/docs/functions/write-firebase-functions