//Function to get data based on teh search
function getData(){
    var form = document.getElementById("frmSearch");
    let formData = new FormData(form);

    fetch('/chart/getData', {
        method: 'post',
        headers: { 'Accept': 'application/json',
        'Content-Type': 'application/json' },
        body: JSON.stringify(Object.fromEntries(formData))
    })
    .then(response => response.json())
    .then(data => updateChart(data))
    .catch(function (err) {
        console.log('error: ' + err);
    });    
}

//Function to udpate the chart with the results
function updateChart(values){
    var rowBars = document.getElementById("row-bars");
    var legendUl = document.getElementById("legend");
    //Delete existing bars before adding new ones
    while (rowBars.firstChild) {
        rowBars.removeChild(rowBars.lastChild);
    }
    //Delete existing legends before adding new ones
    while (legendUl.firstChild) {
        legendUl.removeChild(legendUl.lastChild);
    }

    if(values){
        var totalOrders = values.totalOrders;
        //Add bar for each client
        values.clientOrders.forEach(element => {
            //Create the bars
            var percent = (element.numberOfOrders / totalOrders) * 100;
            var rBar = document.createElement("div");            
            var text = document.createTextNode(element.clientName);
            rBar.className = "rbars"
            rBar.style.cssText = "width: " + percent + "%";
            rowBars.appendChild(rBar);

            //Create the legend
            var legendLi = document.createElement("li");
            legendLi.className = "Legend-item";

            var legendColorBox = document.createElement("span");
            legendColorBox.className = "Legend-colorBox";
            legendLi.appendChild(legendColorBox);

            var legendTextBox = document.createElement("span");
            legendTextBox.appendChild(text);
            legendLi.appendChild(legendTextBox);

            legendUl.appendChild(legendLi);
    
        });
    }
}