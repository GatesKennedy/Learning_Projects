<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BridgerBaby.aspx.cs" Inherits="HappyBirthdayBridgerBaby.BridgerBaby" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HappyBirthdayBridgerBallbach</title>
    <link rel="stylesheet" href="stylesheet1.css" type="text/css" />
    <style>
        
        .picContainer {
            padding: 10px;
            display: flex;
            justify-content: center;
        }
        
        .header {
            font-size: larger;
            padding-bottom: 10px;
            margin: 0px;
            text-align: center;
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
            text-shadow: -1px 2px 5px #555555;
            border-bottom-width:2px;
            border-left-width:2px;
            border-top-width: 1px;
            border-right-width: 1px;
        }


        .LabelContainer {
            font-size: larger;
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
            padding: 6px;
            margin-left: 22%;
            margin-right: 22%;
            border-bottom: 2px solid #555555;
            border-left: 1.2px solid #555555;
        }
        

    </style>
</head>
<body>


    <form id="form1" runat="server">

        <div class="picContainer">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Hair_ForWeb.jpg" />
        </div>

        <div class="header">
            .:5/25/18:.
        </div>

        <div class="ButtonContainer">
            <asp:Button ID="Button1" runat="server" BackColor="#111111" BorderColor="#555555" Text="How Much Love?" OnClick="Button1_Click" BorderStyle="Solid" CssClass="ButtonClass"/>
        </div>
     
        <div class="LabelContainer">
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>

    </form>
</body>
</html>

