
$(document).ready(function () {
    //loadDataTOClassDropDown($('#GradeID'));
    $('#GradeID').on('change', function () {
        loadDataTOClassDropDown(this);
    });
});

function loadDataTOClassDropDown(id) {
    var gradeID = $(id).val();
    var classList = $('#classID');
    classList.empty();
    classList.append('<option disabled selected>--Select Class--</option>');
    if (gradeID !== '') {
        $.ajax({
            url: '/Teacher/CurrentControl/GetClassByGradeId?gradeId=' + gradeID,
            success: function (classes) {
                $.each(classes, function (i, classItem) {
                    classList.append($('<option></option>').attr('value', classItem.gradeClassID).text(classItem.className));
                });
            },
            error: function () {
                alert('something went wrong!');
            }
        });
    }

}

$(document).ready(function () {
    //loadDataTOClassDropDown($('#GradeID'));
    $('#YearID').on('change', function () {
        loadDataTOSemesterDropDown(this);
    });
});

function loadDataTOSemesterDropDown(id) {
    var yearID = $(id).val();
    var semesterList = $('#semesterID');
    semesterList.empty();
    semesterList.append('<option disabled selected>--Select Semester--</option>');
    if (semesterID !== '') {
        $.ajax({
            url: '/Teacher/CurrentControl/GetSemesterByYearID?yearId=' + yearID,
            success: function (semesters) {
                $.each(semesters, function (i, semesterItem) {
                    semesterList.append($('<option></option>').attr('value', semesterItem.yearSemesterID).text(semesterItem.semesterNumber + '- ' + semesterItem.semesterNameEN + ' - ' + semesterItem.semesterNameAR));
                });
            },
            error: function () {
                alert('something went wrong!');
            }
        });
    }

}



//$(document).ready(function () {
//    showBusDropDowns($('#btncheck2')[0]);
//});
//$('#btncheck2').change(function () { // When Bus checkbox is toggled
//    showBusDropDowns(this);
//});

//function showBusDropDowns(btn) {
//    console.log(btn);
//    if (btn.checked || btn.val == true) {
//        //$('#busSelect1, #busSelect2').prop('type', ""); // Enable dropdowns

//        $('#busOptions').removeClass('d-none'); // Show dropdowns
//        $('#busSelect1, #busSelect2').prop('disabled', false); // Enable dropdowns
//    } else {
//        //$('#busSelect1, #busSelect2').prop('type', "hidden");//.val(''); // Disable and reset dropdowns

//        $('#busOptions').addClass('d-none'); // Hide dropdowns
//        $('#busSelect1, #busSelect2').prop('disabled', true);//.val(''); // Disable and reset dropdowns
//    }
//}



//$(document).ready(function () {
//    loadDataTable();
//});



//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": { url: '/admin/student/getall' },
//        "columns": [
//            { data: 'studentID', "width": "5%" },
//            { data: 'studentNameEN', "width": "15%" },
//            { data: 'currentClass.grade.gradeName', "width": "15%" },
//            { data: 'currentClass.className', "width": "15%" }, 
//            {
//                data: 'studentID',
//                "render": function (data) {
//                    return `<div class="w-75 btn-group" role="group">
//                                <a href="/admin/student/upsert?id=${data}" class="btn btn-primary btn-sm mx-2">
//                                    <i class="bi bi-pencil-square" style="position: relative;"></i>
//                                </a>
//                            </div>`;
//                },
//                "width": "3%"
//            }
//        ],

//        dom: 'Bfrtip',
//        buttons: [
//            {
//                extend: 'pdfHtml5',
//                text: 'Export PDF',
//                orientation: 'portrait', // or 'landscape'
//                pageSize: 'A4',          // Options: A3, A4, A5, etc.
//                title: 'My Custom PDF Title',
//                customize: function (doc) {
//                    // Change margins
//                    doc.pageMargins = [30, 30, 30, 30];  // [left, top, right, bottom]

//                    // Add styles to the document
//                    doc.styles.tableHeader = {
//                        color: 'black',
//                        background: '#4CAF50',
//                        alignment: 'center'
//                    };

//                    // Add header text
//                    doc['header'] = (function () {
//                        return {
//                            columns: [
//                                {
//                                    text: 'Custom Header Title',
//                                    alignment: 'left',
//                                    margin: [30, 10]
//                                }
//                            ],
//                            margin: [10, 0]
//                        };
//                    });

//                    // Add footer text
//                    doc['footer'] = (function (page, pages) {
//                        return {
//                            columns: [
//                                {
//                                    alignment: 'left',
//                                    text: 'Generated by My Application',
//                                    margin: [30, 0]
//                                },
//                                {
//                                    alignment: 'right',
//                                    text: 'Page ' + page.toString() + ' of ' + pages.toString(),
//                                    margin: [0, 0, 30, 0]
//                                }
//                            ],
//                            margin: [10, 0]
//                        };
//                    });

//                    // Change table alignment
//                    doc.content[1].table.widths = ['10%', '30%', '30%', '30%'];  // Set column widths
//                }
//            }
//        ]
//    });
//}

