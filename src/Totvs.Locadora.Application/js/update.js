const url = 'https://localhost:44307/api/filmes/';
const http = new EasyHTTP();

const lancamento = document.querySelector('#lancamento');
const preco = document.querySelector('#preco');
const genero = document.querySelector('#genero');
const titulo = document.querySelector('#titulo');
const btn = document.querySelector('.btn-info');
const key = document.querySelector('#id');



const id = JSON.parse(localStorage.getItem('filme'));

http.getById(url, id).then(res => {

    lancamento.value = res.dataLancamento
    genero.value = res.genero;
    titulo.value = res.titulo;
    preco.value = res.preco
    key.value = res.id;


});

btn.addEventListener('click', (e) => {


    const filme = {
        'titulo': titulo.value,
        'genero': genero.value,
        'dataLancamento': lancamento.value,
        'preco': parseFloat(preco.value),
        'id': parseInt(key.value)
    }

    http.put(url, filme)
        .then(data => console.log(data))
        .catch(error => alert(error));

    Clear();

    e.preventDefault();
});


lancamento.addEventListener("input", (e) => {
    e.target.value = e.target.value
        .replace(/\D/g, "")
        .replace(/(\d{2})(\d)/, "$1-$2")
        .replace(/(\d{2})(\d)/, "$1-$2")
        .replace(/(\-\d{4})\d+?$/, "$1")
});

preco.addEventListener("input", (e) => {
    e.target.value = e.target.value
        .replace(",", ".");
});

function Clear() {

    preco.value = "";
    titulo.value = "";
    lancamento.value = "";
    genero.value = "";
}




