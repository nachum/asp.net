<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminZone.aspx.cs" Inherits="nachumTours.AdminZone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
     <link rel="stylesheet" href = "AdminZoneCss.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Adminisrator Zone</h2>
    <div id="zone">
        <div id="add">
            <asp:Button ID="addShow" runat="server" Text="To add a flight press here" Font-Size="8" OnClick="addShow_Click"/>
            <div id="addDet">
                <asp:Label ID="flightLabel" runat="server" Text="Flight number:" Font-Size="9" Width="80px" Visible="false"></asp:Label> <asp:TextBox ID="numberTextBox" runat="server" Width="40px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:Label ID="fromLabel" runat="server" Text="From:" Font-Size="9" Width="30px" Visible="false"></asp:Label> <asp:TextBox ID="fromTextBox" runat="server" Width="60px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:Label ID="toLabel" runat="server" Text="To:" Font-Size="9" Width="30px" Visible="false"></asp:Label> <asp:TextBox ID="toTextBox" runat="server" Width="60px" Font-Size="8" Visible="false"></asp:TextBox>
               <asp:Label ID="dateLabel" runat="server" Text="Date:" Font-Size="9" Width="30px" Visible="false"></asp:Label><asp:TextBox ID="dateTextBox" runat="server" Width="70px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Input valid date!" ControlToValidate="dateTextBox" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="durationLabel" runat="server" Text="Duration:" Font-Size="9" Width="50px" Visible="false"></asp:Label><asp:TextBox ID="durationTextBox" runat="server" Width="60px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:Label ID="priceLabel" runat="server" Text="Price:" Font-Size="9" Width="30px" Visible="false"></asp:Label><asp:TextBox ID="priceTextBox" runat="server" Width="60px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:Label ID="departLabel" runat="server" Text="Depart time:" Font-Size="9" Width="70px" Visible="false"></asp:Label><asp:TextBox ID="departTextBox" runat="server" Width="60px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:Label ID="airlineLabel" runat="server" Text="Airline:" Font-Size="9" Width="43px" Visible="false"></asp:Label><asp:DropDownList ID="airlineDropDownList" runat="server" Visible="false"></asp:DropDownList>
                <asp:Label ID="seatsLabel" runat="server" Text="Seats amount:" Font-Size="9" Width="80px" Visible="false"></asp:Label><asp:TextBox ID="seatsTextBox" runat="server" Width="60px" Font-Size="8" Visible="false"></asp:TextBox>
             </div>
            <asp:Button ID="addButton" runat="server" Text="ADD" OnClick="addButton_Click" Font-Size="8" Visible="false"/>
        </div>
        <div id="changePrice">
            <asp:Button ID="showPriceButton" runat="server" Text="To change a flight price press here" Font-Size="8" OnClick="showPriceButton_Click"/>
            <div id="price">
                <asp:Label ID="flLabel" runat="server" Text="Flight number: " Font-Size="10"  Visible="false"></asp:Label><asp:TextBox ID="flTextBox" runat="server" Width="40px" Font-Size="8" Visible="false"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="New price: " Font-Size="10" Width="80px" Visible="false"></asp:Label><asp:TextBox ID="prTextBox" runat="server"  Width="40px" Font-Size="8" Visible="false"></asp:TextBox>
            </div>
            <asp:Button ID="changeButton" runat="server" Text="Change price" Font-Size="9" Visible="false" OnClick="changeButton_Click"/>
        </div>
        <div id="passengerInfo">
            <asp:Button ID="passeButton" runat="server" Text="To get information about a passenger press here" Font-Size="8" OnClick="passeButton_Click"/>
            <div id="info">
                <asp:Label ID="infoLabel" runat="server" Text="Enter passport number:" Font-Size="10" Visible="false"></asp:Label><asp:TextBox ID="infoTextBox" runat="server" Font-Size="8" Visible="false" Width="80px"></asp:TextBox>
            </div>
            <asp:Button ID="infoButton" runat="server" Text="Get data" Font-Size="10" Visible="false" OnClick="infoButton_Click"/>
            <asp:Label ID="allInfoLabel" runat="server" Text="" Font-Size="10" ForeColor="Blue" Visible="false"></asp:Label>
            <asp:Button ID="retButton" runat="server" Text="Return" Font-Size="8" Visible="false" OnClick="retButton_Click" />
        </div>
        <div id="passList">
            <asp:Label ID="listLabel" runat="server" Text="To get a list of all the passengers on a specific flight:" ></asp:Label><asp:Button ID="Button1" runat="server" Text="Click here" Font-Size="8" OnClick="Button1_Click"/>
            <div id="Div2">
                <asp:Label ID="flNuLabel" runat="server" Text="Flight number: " Font-Size="10" Visible="false" ></asp:Label><asp:TextBox ID="flNuTextBox" runat="server" Width="40px" Font-Size="8" Visible="false"></asp:TextBox>
            </div>
            <asp:Button ID="getListButton" runat="server" Text="Get list" Font-Size="8" Visible="false" OnClick="getListButton_Click"/>
            <asp:Label ID="passengersList" runat="server" Text="" Font-Size="10" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
