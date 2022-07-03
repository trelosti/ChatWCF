<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="ChatClientMVC.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat application</title>
</head>
<body>
    
        <div id="menu">
            <p><button data-bind="click:Connect">
                <span data-bind="text: connect"></span>
               </button></p>
            <p>Nickname : <input data-bind="value: nickname"></p>
           
        </div>
    
    
    <script src="Scripts/knockout-3.5.1.js"></script>
    <script type="text/javascript">
        var vm = {
            connect: ko.observable("connect"),
            nickname: ko.observable("")
        };

        vm.Connect = function () {
            v.connect("disconnect")
        };

        ko.applyBindings(vm, document.getElementById("menu"));
    </script>
</body>
</html>
