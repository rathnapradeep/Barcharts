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

function updateChart(values){
    var rowBars = document.getElementById("row-bars");
    var legendUl = document.getElementById("legend");
    //Delete existing bars before adding new ones
    while (rowBars.firstChild) {
        rowBars.removeChild(rowBars.lastChild);
    }
    while (legendUl.firstChild) {
        legendUl.removeChild(legendUl.lastChild);
    }

    if(values){
        var totalOrders = values.totalOrders;
        //Add bar for each client
        values.clientOrders.forEach(element => {
            var percent = (element.numberOfOrders / totalOrders) * 100;
            var rBar = document.createElement("div");            
            // rBar.innerHTML(element.ClientName);
             var text = document.createTextNode(element.clientName);
            //rBar.appendChild(text);
            rBar.className = "rbars"
            rBar.style.cssText = "width: " + percent + "%";
            rowBars.appendChild(rBar);

            var legendLi = document.createElement("li");
            legendLi.className = "Legend-item";

            var legendColorBox = document.createElement("span");
            legendColorBox.className = "Legend-colorBox";
            //legendColorBox.style.cssText = "background-color: green";
            legendLi.appendChild(legendColorBox);

            var legendTextBox = document.createElement("span");
            legendTextBox.appendChild(text);
            legendLi.appendChild(legendTextBox);

            legendUl.appendChild(legendLi);
    
        });
    }
}