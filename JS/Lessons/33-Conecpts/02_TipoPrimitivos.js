/********* 
JavaScript has a number of different primitive types (MDN):

- Booleans
- Strings
- Numbers
- null
- undefined (void in Flow types)
- Symbols (new in ECMAScript 2015)
********/
console.log(typeof true); //boolean
console.log(typeof Boolean(true)); //boolean
console.log(typeof new Boolean(true)); //object
console.log(typeof (new Boolean(true)).valueOf()); //boolean

console.log(typeof 'Nome do cliente'); //string

console.log(typeof 28); //number

console.log('teste'.length); //5


/********* Conversões implicitas ********/

var doze = new Number(12);
var quinze = doze + 3; //aqui a variavel 12 é convertida de object para number pelo próprio JS

console.log(quinze)
console.log(typeof doze)
console.log(typeof quinze)


