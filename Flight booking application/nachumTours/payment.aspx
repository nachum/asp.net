<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="nachumTours.payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <link rel="stylesheet" href = "paymentCss.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="back">
    <h3>Who's traveling?</h3>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <div id="checking">
        <asp:Label ID="checkLabel" runat="server" Text="Check if you appear in the system " Font-Size="13" ForeColor="Orange"></asp:Label>
        <asp:Button ID="checkButton" runat="server" Text="Check" OnClick="checkButton_Click"/>
        <asp:Label ID="validLabel" runat="server" Text="" Visible="false"></asp:Label>
    </div>
 
    <h4>Billing information</h4>
    <div id="bill">
        <div id="card">
            <h5>*</h5>
            <p>Type of card</p>
        </div>
        <br />
        <div id="cards">
            <asp:CheckBox ID="visaCheckBox" runat="server" OnCheckedChanged="visaCheckBox_CheckedChanged" AutoPostBack="false"/>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/visa.jpg" ImageAlign="Middle" Height="40px" Width="60px"/>
            <asp:CheckBox ID="masterCheckBox" runat="server" OnCheckedChanged="masterCheckBox_CheckedChanged" AutoPostBack="true"/>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/masterCard.jpg" ImageAlign="Middle" Height="40px" Width="60px"/>
        </div>
        <div id="cardNumbers">
            <div id="cardNum">
                <h5>*</h5>
                <p>Card number</p>
                <asp:TextBox ID="cardTextBox" runat="server" Width="140px" Font-Size="8"></asp:TextBox>
            </div>
            <div id="secCode">
                <h5>*</h5>
                <p>Security code</p>
                <asp:TextBox ID="secTextBox" runat="server" Width="50px" Font-Size="8"></asp:TextBox>
            </div>
        </div>
        <br />
        <div id="expire">
           <h5>*</h5>
           <p>Expiration date</p>
           <asp:DropDownList ID="monthDropDownList" runat="server"><asp:ListItem Text="--Month--" Value="" /></asp:DropDownList>
            <asp:DropDownList ID="yearDropDownList" runat="server"><asp:ListItem Text="--Year--" Value="" /></asp:DropDownList>
        </div>
        <div id="name">
            <h5>*</h5>
            <p>Name as it appears on the card</p>
            <asp:TextBox ID="nameTextBox" runat="server" Width="160px" Font-Size="8"></asp:TextBox>
        </div>
        <div id="remember">
            <asp:CheckBox ID="rememberCheckBox" runat="server" Font-Size="7"/>
            <asp:Label ID="rememberLabel" runat="server" Text="Remember me?" Font-Size="7" ForeColor="Blue"></asp:Label>
        </div>
    </div>
    <br />
    <asp:Button ID="done" runat="server" Text="Submit order" OnClick="done_Click"/>
</asp:Content>
