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

        .header {
            font-size: larger;
            padding: 20px;
            margin-top: 20px;
            font-family: 'brutal-tooth';
        }

        .picContainer {
            padding: 10px;
        }

        .ButtonContainer {
            margin: 10px;
            padding: 10px;
            color: #f9f9f9;
        }

        #Button1 {
            font-size: 17px;
            font-family: Arial, Helvetica, sans-serif;
            color: #f9f9f9;
            font-style: italic;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="header">
            Happy Birthday <br /> Bridger Baby<br />
            5/25/18<br />
        </div>

        <div class="picContainer">
            <asp:Image ID="PicRock" runat="server" ImageUrl="~/App_Data/Rock1.jpg" Visible="False" />
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="#FF6666" BorderColor="#990033" Text="How Much Do We Love You?" OnClick="Button1_Click" />
        </div>
     
        <div class="LabelContainer">
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>

    </form>
</body>
</html>

