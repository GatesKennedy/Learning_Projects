<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BridgerBaby.aspx.cs" Inherits="HappyBirthdayBridgerBaby.BridgerBaby" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HappyBirthdayBridgerBallbach</title>
    <link rel="stylesheet" href="stylesheet1.css" type="text/css" />

    <script src="~/Scripts/JavaScript.js" lang="javascript" type="text/javascript"></script>

</head>
<body>

        <!-- Trigger/Open The Modal 
    <button id="myBtn">Open Modal</button>
    -->

    <!-- The Modal -->
    <div id="myModal" class="modal">

      <!-- Modal content -->
      <div class="modal-content">
        <span class="close">&times;</span>
        <p>Some text in the Modal..</p>
      </div>

    </div>

    <form id="form1" runat="server">

        <div class="picContainer">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Hair_ForWeb.jpg" />
        </div>

        <div class="header">
            .:5/25/18:.
        </div>

        <div class="ButtonContainer">
            <asp:Button ID="Button1" runat="server" BackColor="#111111" BorderColor="#555555" Text="How Much Love?" OnClick="Button1_Click" BorderStyle="Solid" CssClass="ButtonClass"/>
            <br />
<<<<<<< HEAD
        </div>

        <div class="waysLabel">
=======
            
        </div>

        <div>
>>>>>>> e2fa9c33605fff60dc69fe7a456b5d17c7d9bb5d
            <asp:Label ID="WaysToSay" runat="server" Visible="False" CssClass="waysLabel"></asp:Label>
        </div>
     
        <div class="LabelContainer">
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
        </div>

    </form>
</body>
</html>

