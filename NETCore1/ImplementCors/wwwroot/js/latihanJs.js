const p = document.getElementById('b');
// selectQuery
const animals = [
    {
        name: "Fluffy", species: "cat", class: { name: 'mamalia' }
    },
    {
        name: "Nemo", species: "dog", class: { name: 'vertebrata' }
    },
    {
        name: "Ursa", species: "cat", class: { name: 'mamalia' }
    }
]


//for (let i = 0; i < animals.length; i++) {
//    console.log("Nama Hewan : " + animals[i].name);
//    console.log("Spesies : " + animals[i].species);
//    console.log("Class : " + animals[i].class.name);
//}


//let dog = [];

//function NonMamalia() {
//    for (let animal of animals) {
//        if (animal.species == "dog") {
//            animal.class.name = 'non-mamalia'
//            dog.push(animal)
//            console.log(dog)
//        }
//    }
//}
//let cat = []

//function onlyCat() {
//    cat = animals.filter(animal => animal.species == "cat")
//    console.log(cat)
//}
$.ajax({
    url: 'https://pokeapi.co/api/v2/pokemon/'
}).done(res => {
    let htmlContent = "";
    console.log(res.results)

    $.each(res.results, (key, value) => {
        htmlContent += `<tr>
                            <td>${key + 1}</td>
                            <td>${value.name}</td>
                            <td>${value.url}</td>
                            <td>
                                <button
                                    type="button"
                                    class="item-detail btn btn-primary"
                                    data-toggle="modal"
                                    data-target="#pokemonDetailModal"
                                    onClick="pokemonDetail('${value.url}')">Detail</button>
                                <button class="btn btn-danger">Hapus</button>
                            </td>
                        </tr>`
    });

    $('.data-pokemon').html(htmlContent)
})



//$(document).ready(function () {
//    $('#dataTable').DataTable({
//        "filter": true,
//        "ajax": {
//            "url": 'https://localhost:44337/api/person/getperson/',
//            "datatype": "json",
//            "dataSrc": "data"
//        },

//        "columns": [
//            {
//                "data": "id",
//                render: function (data, type, row, meta) {
//                    return meta.row + meta.settings._iDisplayStart + 1;
//                }
//            },
//            {
//                "data": "nik"
//            },
//            {
//                "data":"namaDepan"
//            },
//            {
//                "data":"telp"
//            },
//            {
//                "data":"email"
//            },
//            {
//                "data":"tglLahir"
//            },
//            {
//                mRender: function (data, type, full) {
//                    return ' <button type="button" class="item-detail btn btn-primary mr-2" data-toggle="modal" data-target="#pokemonDetailModal" >Detail</button>' +
//                      '<button type="button" class="item-detail btn btn-danger" data-toggle="modal" data-target="#pokemonDetailModal">Hapus</button>';
//                }
//            }

            
          
           
//        ]
//    });
//});

const pokemonDetail = (url) => {
    $.ajax({
        url: url
    }).done(res => {
        console.log(res)

        let abilities = "";
        let types = ""

        res.abilities.map(item => {
            abilities += `<li>${item.ability.name}</li>`
        })

        res.types.map(item => console.log(item.type.name))

        res.types.map(item => {
            if (item.type.name === "grass") {
                types += `<span class="badge badge-success mr-1">${item.type.name}</span>`
            }
            if (item.type.name === "poison") {
                types += `<span class="badge badge-danger mr-1">${item.type.name}</span>`
            }
            if (item.type.name === "fire") {
                types += `<span class="badge badge-warning mr-1">${item.type.name}</span>`
            }
            if (item.type.name === "flying") {
                types += `<span class="badge badge-info mr-1">${item.type.name}</span>`
            }
            if (item.type.name === "normal") {
                types += `<span class="badge badge-light mr-1">${item.type.name}</span>`
            }
            if (item.type.name === "water") {
                types += `<span class="badge badge-primary mr-1">${item.type.name}</span>`
            }
            if (item.type.name === "bug") {
                types += `<span class="badge badge-success mr-1">${item.type.name}</span>`
            }
        })


        let pokeDetailContent = `
                                <img
                                    src="${res.sprites.other.dream_world.front_default}"
                                    class="mx-auto d-block mb-3"
                                    alt="pokeimg"
                                    width="200px"
                                    height="200px" />
                                    <div class="text-center">${types}</div>
                                <ul>
                                    <li>Name: ${res.name} </li>
                                    <li>Weight: ${res.height} </li>
                                    <li>Height: ${res.weight}</li>
                                    <li>Abilities:
                                        <ul>
                                            ${abilities}
                                        </ul>
                                    </li>
                                </ul>`;

        $('#pokemonDetailModal .modal-body').html(pokeDetailContent);
        $('h5.modal-title').html(`Character Detail: ${res.name}`);
    });
}   