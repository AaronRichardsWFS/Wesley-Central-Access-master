// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// showing the alerts when doing create update delete
setTimeout(function () {


    //ahr
    //var liElements = getElementsByClassName('alert');
    //if (liElements.length > 0) {
    //  liElements[0].remove();
    //}
    //end ahr

    document.getElementsByClassName('alert')[0].remove();
}, 3000);

// CLIENT MODELS

$('.phone').keydown(function (e) {
    var key = e.charCode || e.keyCode || 0;
    $text = $(this);
    if (key !== 8 && key !== 9) {
        if ($text.val().length === 3) {
            $text.val($text.val() + '-');
        }
        if ($text.val().length === 7) {
            $text.val($text.val() + '-');
        }
    }
    return (key == 8 || key == 9 || key == 46 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105));
})
$('#ssn').keydown(function (e) {
    var key = e.charCode || e.keyCode || 0;
    $text = $(this);
    if (key !== 8 && key !== 9) {
        if ($text.val().length === 3) {
            $text.val($text.val() + '-');
        }
        if ($text.val().length === 6) {
            $text.val($text.val() + '-');
        }
    }
    return (key == 8 || key == 9 || key == 46 || (key >= 48 && key <= 57) || (key >= 96 && key <= 105));
})

// END OF CLIENT MODELS



// CLIENT SERVICES

// internal external type
$(document).ready(function () {
    toggleExtInt();
    $("#intext").change(function () {
        toggleExtInt();
    });
});
function toggleExtInt() {
    if ($("#intext").val() == "Internal") {
        $("#internal").show();
        $("#external").hide();
    } else if ($("#intext").val() == "External") {
        $("#external").show();
        $("#internal").hide();
    } else {
        $("#internal").hide();
        $("#external").hide();
    }
}

// service
$(document).ready(function () {
    toggleServ();
    $("#serv").change(function () {
        toggleServ();
    });
});
function toggleServ() {
    var servs = $("#serv").text().split('\n');
    var num = parseInt($("#serv").val());
    curr = ""
    for (var i = 3; i < (servs.length + 1); i++) {
        if (i == num) {
            curr = servs[i - 0]
        }
    }
    //  console.log(servs)
    //  console.log(num)
    //  console.log(curr)
    if (num == 13) {
        //	console.log("Option1")
        $("#op").hide();
        $("#otherserv1").hide();
        $("#otherserv2").hide();
        $("#otherserv3").hide();
        $("#otherserv4").hide();
    } else if ((num == 3) || (num == 27) || (num == 23)) {
        //	console.log("Option2")
        $("#otherserv1").show();
        $("#otherserv2").show();
        $("#otherserv3").show();
        $("#otherserv4").show();
        $("#op").hide();
    } else {
        //	console.log("Option3")
        $("#op").hide();
        $("#otherserv1").hide();
        $("#otherserv2").hide();
        $("#otherserv3").hide();
        $("#otherserv4").hide();
    }
}

// site
$(document).ready(function () {
    toggleSite();
    $("#site").change(function () {
        toggleSite();
    });
});
function toggleSite() {
    //  console.log(curr)
    //  console.log($("#site").val())
    if ($("#site").val() == 60) {
        $("#sch").show();
    } else {
        $("#sch").hide();
    }
}


// END OF CLIENT SERVICES


//Age Calculation



$(document).ready(function () {
    calculate_age();
    $("#dob").change(function () {
        calculate_age();
    });
});


function calculate_age() {
    var DateOB = $("#dob").val()


    //console.log("Test Date")
    //console.log(DateOB)


    var birthdate = new Date(DateOB);
    var cur = new Date();
    var diff = cur - birthdate; // This is the difference in milliseconds
    var age = Math.floor(diff / 31557600000)
    //console.log(age)
    //console.log("Test Date 2")


    //$("#age").val = age;
    //document.getElementById($("#dob")) = age;
    document.getElementById('age').value = age;
    //console.log("Test Date 3")


}



// END OF Age Calucation




// Preliminary testing of confirmation warning if data has changed
// DOES NOT WORK CORRECTLY BECAUSE STILL GIVES ALERT WHEN CLICKING SAVE
var somethingChanged = false;
$('#somethingChanged input').change(function () {
    somethingChanged = true;
    console.log("true");
});
$('#somethingChanged select').change(function () {
    somethingChanged = true;
    console.log("true");
});

$(window).bind('beforeunload', function (e) {
    if (somethingChanged && !confirm("You have unsaved changes. Are you sure you wish to leave?"))
        return false;
});