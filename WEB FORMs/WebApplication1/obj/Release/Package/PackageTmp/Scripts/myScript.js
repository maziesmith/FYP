function Select() {
    alert("ss");
}

type0 = new Array("--")
type1 = new Array("bo", "bstar", "yo", "ystar");
type2 = new Array("zd", "zdd");
type3 = new Array("ao", "astar");

type11 = new Array("b\u00B0", "b*", "y\u00B0", "y*");
type22 = new Array("z\'", "z&quot");
type33 = new Array("a\u00B0", "a*");



function populateSelect() {
    frag = $('#MainContent_fragtype :selected').val(); //get dropdown value [frag type]
    $('#MainContent_HandleIons').html(''); //reset ions handle
    console.log(frag);
    if (frag == '*') {
        document.getElementById("handle").style.display = "none";

    }

    var i = 0;
   
     
    if (frag == 'CID' || frag == 'BIRD' || frag == 'IMD' || frag == 'HCD' || frag == 'SID') {
        document.getElementById("handle").style.display = "block";

        type0.forEach(function (t) {
            $('#MainContent_HandleIons').append('<option value="*">' + t + '</option>');
        });

        for (i = 0; i < type1.length;i++)
        {
            $('#MainContent_HandleIons').append('<option value="' + type1[i] + '">' + type11[i] + '</option>');
        };
    }



    if (frag == 'ECD' || frag == 'ETD') {
        document.getElementById("handle").style.display = "block";

        type0.forEach(function (t) {
            $('#MainContent_HandleIons').append('<option value="*">' + t + '</option>');
        });
        for (i = 0; i < type2.length;i++)
        {
            $('#MainContent_HandleIons').append('<option value="' + type2[i] + '">' + type22[i] + '</option>');
        };
    }

    if (frag == 'EDD' || frag == 'NETD') {
        document.getElementById("handle").style.display = "block";

        type0.forEach(function (t) {
            $('#MainContent_HandleIons').append('<option value="*">' + t + '</option>');
        });
        for (i = 0; i < type3.length;i++)
        {
            $('#MainContent_HandleIons').append('<option value="' + type3[i] + '">' + type33[i] + '</option>');
        };
    }

}

function asd() {
    var e = document.getElementById("MainContent_HandleIons");
    //alert(e);
    var strUser = e.options[e.selectedIndex].value;
    document.getElementById("ss").value = strUser;
    //alert(strUser);
}

function awain() {
    var selectedOpts = $('#Variable_modifications');

    var variable_mod = []
    for (index = 0; index < fruits.length; index++) {
        variable_mod[index] = selectedOpts[index];
    }
    document.getElementById("ss2").value = selectedOpts.join(',');
}

function add_mod() {

    var selectedOpts = $('#modifications_select option:selected');
    if (selectedOpts.length == 0) {
        alert("Nothing to move.");

    }
    $('#Variable_modifications').append($(selectedOpts).clone());

    $(selectedOpts).remove();

}

function remove_mod() {

    var selectedOpts = $('#Variable_modifications option:selected');
    if (selectedOpts.length == 0) {
        alert("Nothing to move.");

    }
    $('#modifications_select').append($(selectedOpts).clone());

    $(selectedOpts).remove();
}

function fix_Add_Click() {

    var selectedOpts = $('#modifications_select option:selected');
    if (selectedOpts.length == 0) {
        alert("Nothing to move.");

    }
    $('#Fixed_modifications').append($(selectedOpts).clone());
    $(selectedOpts).remove();
}

function fix_Remove_Click() {

    var selectedOpts = $('#Fixed_modifications option:selected');
    if (selectedOpts.length == 0) {
        alert("Nothing to move.");

    }
    $('#modifications_select').append($(selectedOpts).clone());
    $(selectedOpts).remove();
}

function MW_enable() {
    var checkedValue = $("#MainContent_filterDB").is(":checked");
    var checkedValue1 = $("#MainContent_optionsRadios3").is(":checked");
    if (checkedValue) {
        document.getElementById("MMW").style.display = "block";
    }
    else {
        if (checkedValue1) { }
        else
        document.getElementById("MMW").style.display = "none";
    }
}

function tuner_enable() {
    document.getElementById("MMW").style.display = "block";
}

function tuner_disable() {
    var checkedValue = $("#MainContent_filterDB").is(":checked");
    if (checkedValue) { }
    else
        document.getElementById("MMW").style.display = "none";
}

function PST_enable() {
    document.getElementById("PST").style.display = "block";
}

function PST_disable() {
    document.getElementById("PST").style.display = "none";
}

function P_enable() {
    document.getElementById("Param").style.display = "block";
}

function P_disable() {
    document.getElementById("Param").style.display = "none";
}

function PST_length_enable() {
    document.getElementById("PST_length").style.display = "block";
}

function PST_length_disable() {
    document.getElementById("PST_length").style.display = "none";
}

function PTM_enable() {
    document.getElementById("PTM").style.display = "block";
}

function PTM_disable() {
    document.getElementById("PTM").style.display = "none";
}

function Final_score_enable() {
    document.getElementById("Final_score").style.display = "block";
}

function Final_score_disable() {
    document.getElementById("Final_score").style.display = "none";
}

function length_enable() {
    //var checkedValue = $("#MainContent_length").is(":checked");

    //if (checkedValue) {

    //}
    //else {
    if ($("#MainContent_length").prop('checked')) {
        $("#pst_max").css("color", "black");
        $("#pst_min").css("color", "black");
    } else {
        $("#pst_max").css("color", "grey");
        $("#pst_min").css("color", "grey");
    }
    document.getElementById("PST_Length_max").disabled = !($("#MainContent_length").is(":checked"));
    document.getElementById("PST_Length_min").disabled = !($("#MainContent_length").is(":checked"));
    //}
}

function change_label() {
    document.getElementById("lab").innerText = "This is updated value";
}

function mod_right() {
    var options = document.getElementById('Variable_modifications').options;
    var values = [];

    for (var i = 0, iLen = options.length; i < iLen; i++) {
        values.push(options[i].value);
    }
    var strUser = values.join(',');
    document.getElementById("vari").value = strUser;

}

function mod_right_fixi() {
    var options = document.getElementById('Fixed_modifications').options;
    var values = [];

    for (var i = 0, iLen = options.length; i < iLen; i++) {
        values.push(options[i].value);
    }
    var strUser = values.join(',');
    document.getElementById("fixi").value = strUser;


}

function BeginProcess() {
    // Create an iframe.
    var iframe = document.createElement("iframe");

    // Point the iframe to the location of
    //  the long running process.
    iframe.src = "LongRunningProcess.aspx";

    // Make the iframe invisible.
    iframe.style.display = "none";

    // Add the iframe to the DOM.  The process
    //  will begin execution at this point.
    document.body.appendChild(iframe);
}

function UpdateProgress(PercentComplete, Message) {
    alert('progress');
    document.getElementById('trigger').value =
      PercentComplete + '%: ' + Message;
}

