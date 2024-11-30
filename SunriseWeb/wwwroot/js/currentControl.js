
$(document).ready(function () {
    $('#semesterID').on('change', function () {

    });
});


$(document).ready(function () {
    $('#gradeID').on('change', function () {
        loadDataTOSubjectDropDown(this);
        $('#classID').empty();
        $('#classID').append('<option disabled selected>--Select Class--</option>');
    });
});

function loadDataTOSubjectDropDown(id) {
    var gradeID = $(id).val();
    var subjectList = $('#subjectID');
    subjectList.empty();
    subjectList.append('<option disabled selected>--Select Subject--</option>');
    if (gradeID !== '') {
        $.ajax({
            url: '/Teacher/CurrentControl/GetSubjectByGradeID?gradeId=' + gradeID,
            success: function (subjects) {
                $.each(subjects, function (i, subject) {
                    subjectList.append($('<option></option>').attr('value', subject.subjectID).text(subject.subjectNameEN));
                });
            },
            error: function () {
                alert('something went wrong!');
            }
        });
    }
}

$(document).ready(function () {
    $('#subjectID').on('change', function () {
        loadDataTOClassDropDown(this);
    });
});

function loadDataTOClassDropDown(id) {
    var subjectID = $(id).val();
    var gradeID = $('#gradeID').val();
    var classList = $('#classID');
    classList.empty();
    classList.append('<option disabled selected>--Select Class--</option>');
    if (gradeID !== '') {
        $.ajax({
            url: '/Teacher/CurrentControl/GetClassByGradeId?gradeId=' + gradeID + '&subjectId=' + subjectID,
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
    $('#YearID').on('change', function () {
        loadDataTOSemesterDropDown(this);
    });
    //loadDataTOSemesterDropDown($('#YearID'));
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