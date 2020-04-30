function Funcao01() {
    Funcao02();
    console.log('Executou a função 1');
}

function Funcao02() {
    Funcao03();
    console.log('Executou a função 2');
}

function Funcao03() {
    console.log('Executou a função 3');
}

Funcao01();