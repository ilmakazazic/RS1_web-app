
        "use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    
    document.getElementById("sendButton").disabled = true;



    connection.on("ReceiveMessage", function (user, message, test) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
     
        var encodedMsg = test + ": " + user + " says " + msg; 
        while (document.getElementById("messagesList").firstChild) {
            document.getElementById("messagesList").removeChild(document.getElementById("messagesList").firstChild);
        }
        test.forEach(myFunction);
        //var li = document.createElement("li");
        //li.textContent = encodedMsg;
        //document.getElementById("messagesList").appendChild(li);
    });

function myFunction(text) {
    var li = document.createElement("li");
    li.textContent = text;
    document.getElementById("messagesList").appendChild(li);
}

    connection.start().then(function () {
        document.getElementById("sendButton").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
