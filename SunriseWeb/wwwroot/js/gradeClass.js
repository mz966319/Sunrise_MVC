//$(document).ready(function () {
//    loadDataTable();
//    //$('#tblData').DataTable({
//    //    dom: 'Bfrtip', // This option allows buttons to be displayed
//    //    buttons: [
//    //        'copy', 'csv', 'excel', 'pdf', 'print'
//    //    ]
//    //});
//});

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({

//        "ajax": {url:'/admin/gradeClass/getall'},
//        "columns": [
//            { data: 'gradeClassID',"width":"5%" },
//            { data: 'className', "width": "15%" },
//            { data: 'grade.gradeName', "width": "15%" },
//            {
//                data: 'gradeClassID',
//                "render": function (data) {
//                    return `<div class="w-75 btn-group" role="group">
//                                <a href="/admin/gradeclass/upsert?id=${data}" class="btn btn-primary btn-sm mx-2">
//                                    <i class="bi bi-pencil-square" style="position: relative; "></i>
//                                </a>
//                            </div>`
//                },
//                "width": "1%"
//            }
//        ],
//        dom: 'Bfrtip',  // Display buttons above the table
//        buttons: [
//            'copy', 'csv', 'excel', 'pdf', 'print'
//        ]


//    });
//}


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/gradeClass/getall' },
        "columns": [
            { data: 'gradeClassID', "width": "5%" },
            { data: 'className', "width": "15%" },
            { data: 'grade.gradeName', "width": "15%" },
            { data: 'sectionName', "width": "15%" },
            {
                data: 'gradeClassID',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="/admin/gradeclass/upsert?id=${data}" class="btn btn-primary btn-sm mx-2">
                                    <i class="bi bi-pencil-square" style="position: relative;"></i>
                                </a>
                            </div>`;
                },
                "width": "1%"
            }
        ]
    });
}

