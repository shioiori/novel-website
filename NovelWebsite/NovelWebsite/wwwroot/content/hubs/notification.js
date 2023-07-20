var connection = new signalR.HubConnectionBuilder().withUrl("/notification_hub").build();


connection.on("ReceiveUserNotification", function (_sender, _receiver, _message) {
    console.log(_sender);
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${_sender} ${_message}`;
});

var receiver;

connection.start().then(() => console.log('connected!'))
    .catch(console.error);
