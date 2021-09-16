//$.ajax({
//    url: "https://localhost:44337/Api/Person/getperson",
//    type: "get",
//    dataType: "json",
//    success: function (result) {
//       let array = []
//        array = result
//        console.log(array)
//        $.each(array, (key, value) => {
//            console.log(value.nik)
//        });
//
//    }
//})

$.ajax({
    url: 'https://localhost:44337/Api/Person/getperson'
}).done(res => {
    let htmlContent = "";
    console.log(res.data)

    $.each(res.data, (key, value) => {
        console.log(key);
        htmlContent += `<tr>
                            <td>${key + 1}</td>
                            <td>${value.namaDepan}</td>
                            <td>${value.email}</td>
                            <td>
                                <button
                                    type="button"
                                    class="item-detail btn btn-primary"
                                    data-toggle="modal"
                                    data-target="#pokemonDetailModal"
                                    onClick="pokemonDetail('${value.url}')">Detail</button>
                               
                            </td>
                        </tr>`
    });

    $('.data-pokemon').html(htmlContent)
})

//$(document).ready(function () {
//    $('#example').DataTable();
//});