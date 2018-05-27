<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BridgerBaby.aspx.cs" Inherits="HappyBirthdayBridgerBaby.BridgerBaby" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HappyBirthdayBridgerBallbach</title>
    <link rel="stylesheet" href="stylesheet1.css" type="text/css" />
    <style>
        body {
            background-color: #090909;
            color: #f8f8f8;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }
        
        .picContainer {
            padding: 10px;
        }
        
        .header {
            font-size: larger;
            padding-bottom: 10px;
            margin: 0px;
        }

        .ButtonContainer {
            text-align: center;
            padding: 10px;
            color: #f9f9f9;
        }

        #Button1 {
            font-size: 17px;
            font-family: Arial, Helvetica, sans-serif;
            color: #f9f9f9;
            font-style: italic;
        }

        .LabelContainer {
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
            padding-left: 25%;
            padding-right: 25%;
            
        }
        
        @import "compass/css3";
        @keyframes fadeIn {
            from {opacity: .2; }
        }
        body {
            background-color: #111;
            color: #bbb;
            font-family: Helvetica, Arial, sans-serif;
            animation: fadeIn 2.5s infinite alternate;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="picContainer">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Hair_ForWeb.jpg" />
        </div>

        <div class="header">
            Happy Birthday <br />
            .:5/25/18:.
        </div>

        <div class="ButtonContainer">
            <asp:Button ID="Button1" runat="server" BackColor="#FF6666" BorderColor="#990033" Text="How Much Love?" OnClick="Button1_Click" BorderStyle="None" CssClass="ButtonClass" />
        </div>
     
        <div class="LabelContainer">
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>

    </form>
</body>
</html>

