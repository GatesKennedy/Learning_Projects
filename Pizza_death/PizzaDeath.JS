



//Topping Variables and Counts
//Class: list.item
var scale = "medium";
var iSc=0;

var crust = "plain";
var iCr=0;

var sauce = "red";
var iSa=0;

var cheese = "cow";
var iCh=0;

var plants = "no plants";
var iPl=0;

var protein = "no protein";
var iPr=0;


var itemCost = {
	smallCost:6.00,
	mediumCost:10.00,
	largeCost:14.00,
	xlargeCost:16.00,
	goatCost:3.00,
	stuffedCost:3.00,
	plantsCost:1.00,
	proteinCost:1.00
}

var itemExtra = [
	'smallCost',
	'mediumCost',
	'largeCost',
	'xlargeCost',
	'goatCost',
	'stuffedCost',
	'plantsCost',
	'proteinCost'
]
function statusLoad() {
	document.getElementById("scale").innerHTML = scale;
	document.getElementById("crust").innerHTML = crust;
	document.getElementById("sauce").innerHTML = sauce;
	document.getElementById("cheese").innerHTML = cheese;
	document.getElementById("plants").innerHTML = plants;
	document.getElementById("protein").innerHTML = protein;

	document.getElementById("scaleCost").innerHTML = "+$10";
	document.getElementById("crustCost").innerHTML = "+$0";
	document.getElementById("sauceCost").innerHTML = "+$0";
	document.getElementById("cheeseCost").innerHTML = "+$0";
	document.getElementById("plantsCost").innerHTML = "+$0";
	document.getElementById("proteinCost").innerHTML = "+$0";

	document.getElementById("scaleCost").title = "10";
	document.getElementById("crustCost").title = "0";
	document.getElementById("sauceCost").title = "0";
	document.getElementById("cheeseCost").title = "0";
	document.getElementById("plantsCost").title = "0";
	document.getElementById("proteinCost").title = "0";

	total()
}

var listScale = document.getElementsByName("size");
var listCrust = document.getElementsByName("crust");
var listSauce = document.getElementsByName("sauce");
var listCheese = document.getElementsByName("cheese");
var listPlants = document.getElementsByName("plants");
var listProtein = document.getElementsByName("protein");

function radioChecked(value,name) {
	document.getElementById(name).innerHTML = value;
	var costId = value+"Cost";
	console.log(costId);
	console.log(itemExtra.indexOf(value+"Cost"));

	if (itemExtra.indexOf(costId)>=0) {
		console.log(costId);
		document.getElementById(name+"Cost").innerHTML = "+$"+itemCost[costId];
		document.getElementById(name+"Cost").title = itemCost[costId];
	} else {
		document.getElementById(name+"Cost").innerHTML = "+$"+0.00;
		document.getElementById(name+"Cost").title = "0";
	}
	total()
}

var plantsSelected = [];
var proteinSelected = [];

function boxChecked(value,name,id) {
	if (name=="plants") {
		while(iPl<plantsSelected.length) {
			plantsSelected.pop();
		}
		while(iPl<listPlants.length) {
			if (listPlants[iPl].checked) {
				plantsSelected.push("<br>"+listPlants[iPl].value);
			}
			iPl++;
		}
		iPl=0;
		document.getElementById("plants").innerHTML = plantsSelected;
		var sumPl=plantsSelected.length;
		document.getElementById("plantsCost").innerHTML = "+$"+sumPl;
		document.getElementById("plantsCost").title = "sumPl";
	}
	else {
		while(iPr<proteinSelected.length) {
			proteinSelected.pop();
		}
		while(iPr<listProtein.length) {
			if (listProtein[iPr].checked) {
				proteinSelected.push("<br>"+listProtein[iPr].value);
			}
			iPr++;
		}
		iPr=0;
		document.getElementById("protein").innerHTML =proteinSelected;
		var sumPr=proteinSelected.length;
		document.getElementById("proteinCost").innerHTML="+$ "+sumPr;
		document.getElementById("proteinCost").title = "sumPr";
	}
	total()
}

function total() {
	var listCost = document.getElementsByClassName("money");
	var topCat = listCost.length;
	var totCat = [];
	var j=0;
	while(j<topCat.length) {
		topCat.pop();
	}
	while(j<topCat) {
		var tempCat=listCost[j].textContent;
		var moneyCat=tempCat.slice(2,4);

		totCat.push(parseInt(moneyCat));
		j++;
	}
	console.log(totCat)
	j=0;
	var totalCost = totCat.reduce(add,0);
	function add(a, b) { 
		return a + b; 
	}
	document.getElementById("orderTotal").innerHTML="Order Total: $"+totalCost+".00";
}

/*==============================
		Order Confirm
==============================*/


// Get the modal
var modal = document.getElementById('orderConfirm');

// Get the button that opens the modal
var btn = document.getElementById("orderButton");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
    modal.style.display = "block";
    populateConfirm();
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
//======================================
//======== Confirm Content ==============
//======================================

function populateConfirm () {

	document.getElementById("finalContent").innerHTML = "<br>Thank You! <br> One last thing..<br> Please Confirm your order below.<br><br>"
	var confirmOption = document.getElementsByClassName("item");
	var confirmContent = document.getElementsByClassName("value");
	var confirmCost = document.getElementsByClassName("money");
	var k =0;
	while (k<confirmContent.length) {
		var confirmOptionTemp = confirmOption[k].textContent;
		var confirmContentTemp = confirmContent[k].textContent;
		var confirmCostSlice = confirmCost[k].textContent;
		var confirmCostTemp = confirmCostSlice.slice(1,4);
		$("#finalContent").append(confirmOptionTemp+" "+confirmContentTemp+"&nbsp &nbsp &nbsp"+confirmCostTemp+"<br>");
		k++;
	};
	var finalOrderTotal = document.getElementById("orderTotal").textContent;
		$("#finalContent").append("<br><br>"+finalOrderTotal);
};
	


//Topping Costs
/*
	//Scale: specific
	var smallCost = 6.00;
	var mediumCost = 10.00;
	var largeCost = 14.00;
	var xlargeCost = 16.00;

	//protein: additional > 1st
	var proteinCost = 1.00;

	//protein: additional > 1st
	var plantsCost = 1.00;

	//cheese: specific
	var goatCost = 3.00;

	//crust: specific
	var stuffedCost = 3.00;
*/

