"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/calendarHub").build();

connection.on("ReceiveMessage", function (id, name, location, date, image) {



    var eventName = document.createTextNode(name);
    var eventLocation = document.createTextNode(location);
    var eventTime = document.createTextNode(date);


    var newLink = document.createElement("a");
    var linkText = document.createTextNode("More");
    var url = '/Event/Details/' + id;
    newLink.setAttribute("href", url);
    newLink.appendChild(linkText);

    var img = document.createElement('img');
    img.src = 'images/' + image;
    

    var eventTable = document.getElementById('eventList').getElementsByTagName('tbody')[0];
    var newRow = eventTable.insertRow(0);
    var firstCell = newRow.insertCell(0);
    var secondCell = newRow.insertCell(1);
    var thirdCell = newRow.insertCell(2);
    var forthCell = newRow.insertCell(3);
    var fifthCell = newRow.insertCell(4);

    var rowCount = eventTable.rows.length;

    firstCell.appendChild(img);
    secondCell.appendChild(eventName);
    thirdCell.appendChild(eventLocation);
    forthCell.appendChild(eventTime);
    fifthCell.appendChild(newLink);

    document.getElementById('eventList').deleteRow(rowCount);


});

connection.start().catch(function (err) {
    return console.error(err.toString());
});



