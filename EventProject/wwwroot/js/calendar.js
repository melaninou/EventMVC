"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/calendarHub").build();

connection.on("ReceiveMessage", function (id, name, location, date) {


    var eventName = document.createTextNode(name);
    var eventLocation = document.createTextNode(location);
    var eventTime = document.createTextNode(date);
    var eventId = document.createTextNode(id);

    var newLink = document.createElement("a");
    var url = '@Url.Action("Details", "Event")';
    newLink.setAttribute("href", url);
    var linkText = document.createTextNode("More");
    newLink.appendChild(linkText);


    var eventTable = document.getElementById('eventList').getElementsByTagName('tbody')[0];
    var newRow = eventTable.insertRow(0);
    var firstCell = newRow.insertCell(0);
    var secondCell = newRow.insertCell(1);
    var thirdCell = newRow.insertCell(2);
    var forthCell = newRow.insertCell(3);

    firstCell.appendChild(eventName);
    secondCell.appendChild(eventLocation);
    thirdCell.appendChild(eventTime);
    forthCell.appendChild(newLink);




});

connection.start().catch(function (err) {
    return console.error(err.toString());
});



