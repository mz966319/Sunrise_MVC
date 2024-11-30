
//$(document).ready(function () {
//    $('#semesterID').on('change', function () {

//    });
//});


$(document).ready(function () {
    $('#classID').on('change', function () {
        loadDataTOStudentsDropDown(this);
    });
});


function loadDataTOStudentsDropDown(id) {
    var classID = $(id).val();
    var yearID = $('#YearID').val();
    var semesterID = $('#semesterID').val();
    var studentsList = $('#studentID');
    studentsList.empty();
    studentsList.append('<option disabled selected>--Select Student--</option>');
    if (classID == -10) {
        document.getElementById("studentID").disabled = true;

    }
    else {
        document.getElementById("studentID").disabled = false;
        if (classID !== '') {
            $.ajax({
                url: '/Admin/ControlReports/GetStudentsByYearIDSemesterIDClassID?yearId=' + yearID + '&semesterId=' + semesterID + '&classId=' + classID,
                success: function (students) {
                    $.each(students, function (i, student) {
                        studentsList.append($('<option></option>').attr('value', student.studentID).text(student.studentNameEN));
                    });
                },
                error: function () {
                    alert('something went wrong!');
                }
            });
        }
    }

}




$(document).ready(function () {
    $('#gradeID').on('change', function () {
        loadDataTOClassDropDown(this);
    });
});

function loadDataTOClassDropDown(id) {
    var gradeID = $('#gradeID').val();
    var classList = $('#classID');
    $('#studentID').empty();
    $('#studentID').append('<option disabled selected>--Select Student--</option>');
    classList.empty();
    classList.append('<option disabled selected>--Select Class--</option>');
    classList.append('<option value="-10">-All-</option >');
    if (gradeID == -10 || gradeID == -11 || gradeID == -12) {
        document.getElementById("classID").disabled = true;
        document.getElementById("studentID").disabled = true;

    }
    else {
        document.getElementById("classID").disabled = false;
        document.getElementById("studentID").disabled = false;
    
        if (gradeID !== '') {
            $.ajax({
                url: '/Admin/ControlReports/GetClassByGradeId?gradeId=' + gradeID,
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
}


$(document).ready(function () {
    $('#YearID').on('change', function () {
        loadDataTOSemesterDropDown(this);
    });
});


function loadDataTOSemesterDropDown(id) {
    var yearID = $(id).val();
    var semesterList = $('#semesterID');
    semesterList.empty();
    semesterList.append('<option disabled selected>--Select Semester--</option>');
    $('#classID').empty();
    document.getElementById("gradeID").selectedIndex = 0;
    $('#classID').append('<option disabled selected>--Select Class--</option>');
    $('#studentID').empty();
    $('#studentID').append('<option disabled selected>--Select Student--</option>');
    if (semesterID !== '') {
        $.ajax({
            url: '/Admin/ControlReports/GetSemesterByYearID?yearId=' + yearID,
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