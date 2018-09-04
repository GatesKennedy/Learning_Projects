
// FRUSTUM CALCULATOR

/*	========================
     Input/Output Variables
    =======================*/

function inputInit() {
    this.value = 0;
    this.flag = false;
}
var input_diameter1 = new inputInit();
var input_diameter2 = new inputInit();
var input_lateral = new inputInit();

var output_radius1;
var output_radius2;
var output_angle;
/*
console.log(
    "in_dia1 = " + input_diameter1.value + "\n",
    "in_dia2 = " + input_diameter2.value + "\n",
    "in_lat = " + input_lateral.value
); */

//======================
//      Input Check
//======================

function valueCheck(inputVal) {
    console.log("enter fxn: valueCheck");
    if (isNaN(inputVal)) {
        console.log(inputVal + " is not a number!");
        return 0;
    }
    else {
        console.log(inputVal + " is a number!");
        return inputVal;
    }
}

function flagSwitch(inputVal) {
    console.log("enter fxn: flagSwtich");
    if (isNaN(inputVal)) return false;
    else return true;
}

//=========================
//    Output Population
//=========================

function outputPopul8() {
    console.log("enter fxn: outputPoul8");
    document.getElementById("OutputRadius1").value = output_radius1;
    document.getElementById("OutputRadius2").value = output_radius2;
    document.getElementById("OutputAngle").value = output_angle;
}

/*	=======================
 		Event Listeners
     ======================*/
/*  function inputChange() {
        console.log("enter onchange fxn" + this.getElementsByName);
        this.value = valueCheck
     } */

    document.getElementById("InputDiameter1").onchange = function() {
        //console.log("enter onchange InputDiameter");
        input_diameter1.value = valueCheck(document.getElementById("InputDiameter1").value);
        input_diameter1.flag = flagSwitch(input_diameter1.value);
        runMath();
    }
    document.getElementById("InputDiameter2").onchange = function() {
        //console.log("enter onchange InputDiameter2");
        input_diameter2.value = valueCheck(document.getElementById("InputDiameter2").value);
        input_diameter2.flag = flagSwitch(input_diameter2.value);
        runMath();
    }
    document.getElementById("InputLateral").onchange = function() {
        //console.log("enter onchange InputLateral");
        input_lateral.value = valueCheck(document.getElementById("InputLateral").value); 
        input_lateral.flag = flagSwitch(input_lateral.value);
        runMath();
    }

/*	=======================
         Frustum Math
	======================*/
    // RUN MATH FUNCTION
    function runMath() {
        console.log(
            input_diameter1.value, input_diameter1.flag + "\n",
            input_diameter2.value, input_diameter2.flag + "\n",
            input_lateral.value, input_lateral.flag
        ) 
        if(input_diameter1.flag && input_diameter2.flag && input_lateral.flag) {
            // frustumMath(),
            mockMath(); 
        }  
        else console.log("fnx: runMath Failed");
    }

    // MOCK MATH
    function mockMath() {
        console.log("enter fxn: mockMath");
        output_radius1 = input_diameter1.value*2;
        output_radius2 = input_diameter2.value*2;
        output_angle = input_lateral.value*2;
        outputPopul8();
    }

    // FRUSTUM MATH
    function frustumMath(){

    }

/*	========================
        Render Variables
    =======================*/

