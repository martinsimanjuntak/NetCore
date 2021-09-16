(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === true) {
                    event.preventDefault();
                    Register();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

$(document).ready(function () {
    var t = $('#dataTable').DataTable({
        "filter": true,
        "columnDefs": [{
            "searchable": false,
            "orderable": false,
            "targets": 0,
        }],
        "order": [[1, 'asc']],
        "ajax": {
            "url": 'https://localhost:44337/api/person/getperson/',
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            {
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "nik"
            },
            {
                "data":"namaDepan"
            },
            {
                "data": "telp",
                render: function (data) {
                    data = data.replace('0', '(+62) ');
                    return data;
                }
            },
            {
                "data":"email"
            },
            {
                "data":"tglLahir"       
            },
            {
                mRender: function (data, type, full,row) {
                    return `<button class="btn btn-primary" title="Edit" data-toggle="modal" onClick="personDetail('${full.nik}')" data-target="#pokemonDetailModal">Detail
                                        </button>
                            <button class="btn btn-danger" title="Edit" data-toggle="modal" onClick="deletePerson('${full.nik}')">Delete</button>`;
                }
            }
        ],
        'columnDefs': [{
            'targets': [0, 6],
            'orderable': false,
        }]
       
    });
    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});

const personDetail = (nik) => {
    $.ajax({
        url: 'https://localhost:44337/api/person/getperson/'+nik
    }).done(res => {
       
        let personDetailContent = `
                                <ul>
                                    <li>Name: ${res.data[0].namaDepan} </li>
                                    <li>Nomor Telepon: ${res.data[0].telp} </li>
                                    <li>Email: ${res.data[0].email} </li>
                                    <li>Tanggal Lahir: ${res.data[0].tglLahir} </li>
                                    <li>Degree: ${res.data[0].degree} </li>
                                    <li>University: ${res.data[0].unversity_Id} </li>

                                </ul>`;

        $('#pokemonDetailModal .modal-body').html(personDetailContent);
        $('h5.modal-title').html(`Person Detail`);
    });
}

$.ajax({
    url: 'https://localhost:44337/API/University/'
}).done(res => {
    let htmlContent = "";
    $.each(res.data, (key, value) => {
        htmlContent += `<option value="${value.id}">${value.name}
                        </option>`
    });

    $('#university').html(htmlContent)
})
const deletePerson = (nik) => {
    $.ajax({
        url: 'https://localhost:44337/API/Person/'+nik,
        method: 'DELETE',
        success: function (data) {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            )
            $('#dataTable').DataTable().ajax.reload()
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Data Yang anda Masukkan sudah Terdaftar',
            })
        }
    });
}
function Register(){
        var data = {};
        data.nik = $("#nik").val();
        data.namaDepan = $("#firstName").val();
        data.namaBelakang = $("#lastName").val();
        data.email = $("#email").val();
        data.password = $("#password").val();
        data.telp = $("#phone").val();
        data.tglLahir = $("#birthday").val();
        data.degree = $("#degree").val();
        data.gpa = $("#gpa").val();
        data.unversity_Id = $("#university").val();
        $.ajax({
            url: 'https://localhost:44337/API/Person/register',
            method: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (data){
                Swal.fire(
                    'Good job!',
                    'You clicked the button!',
                    'success'
                )
                $('#dataTable').DataTable().ajax.reload(20000)
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Data Yang anda Masukkan sudah Terdaftar',
                })
            }
    });
}
