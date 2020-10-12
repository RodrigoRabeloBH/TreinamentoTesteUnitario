const api = new EasyHTTP();
const uri = 'https://localhost:44307/api/filmes/';

const wrapper = document.querySelector('.wrapper');



document.addEventListener('DOMContentLoaded', ShowMovies);

function GetById(filme) {

    localStorage.setItem('filme', JSON.stringify(filme));
}

function Remove(id) {
    api.delete(uri, id)
        .then(res => console.log(res))
        .catch(error => console.log(error))
}

function ShowMovies() {

    let output = '';

    api.get(uri).then(res => {

        res.forEach(filme => {

            output +=
                `             
                        <tr>
                            <td>${filme.titulo}</td>
                            <td>${filme.genero}</td>
                            <td>${filme.dataLancamento}</td>
                            <td>${filme.preco}</td>
                            <td>
                                <a href="update.html" class="editar" onclick="GetById(${filme.id})">Editar |</a>
                                <a href="#" class="remover" onclick="Remove(${filme.id})">Remover</a>
                            </td>
                        </tr>              
                `
        });

        document.querySelector('.tbody').innerHTML = output;
    })
}

