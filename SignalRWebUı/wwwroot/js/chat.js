
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7121/SignalRHub").build();

document.getElementById("sendbutton").disabled = true;  //Pasif Yapt�k Butonu

connection.on("ReceiverMessage", function (user, message) {
    var currentTime = new Date(); //Aktif Zaman Dilimini Al�r
    var currentHour = currentTime.getHours();  //Saat Bilgisini Al�r
    var currentMinute = currentTime.getMinutes(); //Dakikak Bilgisini Al�r

    var li = document.createElement("li");
    var span = document.createElement("span");

    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML +=`: ${message} - ${currentHour}:${currentMinute}`;
    document.getElementById("messagelist").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;  //Aktif Yapt�k Butonu
}).catch(function (err) {
    return console.log(err.ToString());
})

document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.log(err.ToString());
    });
    event.preventDefault();
})