<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nachumTours._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <link rel="stylesheet" href = "deafaultCss.css"  type="text/css" />
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>The cheapest site in the world - we have the best deals for you</h2>
            </hgroup>
           
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Book your flight</h2>
    <div id="allPage">
    <div id="booking">
        <div id="direct">
            <asp:CheckBox ID="RoundCheckBox" runat="server" Checked="True" Font-Overline="False" Font-Size="Small" Height="35px" Width="21px" AutoPostBack="True" Enabled="False" OnCheckedChanged="RoundCheckBox_CheckedChanged" />
            <asp:Label ID="roundLabel" runat="server" Text="Round trip" ClientIDMode="AutoID" ForeColor="White"></asp:Label>
            <asp:CheckBox ID="OneWayCheckBox" runat="server" Font-Size="Small" Height="35px" Width="21px" AutoPostBack="True" OnCheckedChanged="OneWayCheckBox_CheckedChanged" />
            <asp:Label ID="oneLabel" runat="server" Text="One-direction" ForeColor="#E799D3"></asp:Label>
        </div>
       
        <div id="from">
            <div id="fromL">
                <p>from</p>
                <asp:DropDownList ID="deaparture" runat="server" Width="143px" ToolTip="Choose Deaparture City" Height="16px"><asp:ListItem Text="--Country--" Value="" /> </asp:DropDownList>
                </div>
                <div id="toR">
                <p>to</p>
                <asp:DropDownList ID="Arrival" runat="server" Width="143px" ToolTip="Choose Deaparture City" Height="16px"><asp:ListItem Text="--Country--" Value="" /></asp:DropDownList>
                </div>
            </div>
        
        <div id="to">
            <div id="dateL">
            <p>Leave</p>
            <asp:DropDownList ID="Dmonth" runat="server" Width="100" OnLoad="Dmonth_Load" OnSelectedIndexChanged="Dmonth_SelectedIndexChanged" ToolTip="Choose month"><asp:ListItem Text="--Month--" Value="" /></asp:DropDownList>
            <asp:DropDownList ID="Dday" runat="server" Width="70" ToolTip="First choose month"><asp:ListItem Text="--Day--" Value="" /></asp:DropDownList>
            <asp:DropDownList ID="Dyear" runat="server" ToolTip="Choose year"><asp:ListItem Text="--Year--" Value="" /></asp:DropDownList>
            </div>
            <div id="dateR">
                <asp:Label ID="returnLabel" runat="server" Text="Return" ForeColor="White"></asp:Label><br />
                <asp:DropDownList ID="Amonth" runat="server"  Width="100" AutoPostBack="True" OnSelectedIndexChanged="Amonth_SelectedIndexChanged"><asp:ListItem Text="--Month--" Value="" /></asp:DropDownList>
                <asp:DropDownList ID="Aday" runat="server" Width="70" ToolTip="First choose month" Enabled="False"><asp:ListItem Text="--Day--" Value="" /></asp:DropDownList>
                <asp:DropDownList ID="Ayear" runat="server" ToolTip="Choose year"><asp:ListItem Text="--Year--" Value="" /></asp:DropDownList>
            </div> 
        </div>
         <br/>
        <div id="people">
            <asp:Label ID="adultLabel" runat="server" Text="Adults" Font-Size="X-Small"></asp:Label>
            <asp:DropDownList ID="adultsDropDownList" runat="server"></asp:DropDownList>
            <asp:Label ID="childLabel" runat="server" Text="Children" Font-Size="X-Small"></asp:Label>
            <asp:DropDownList ID="childDropDownList" runat="server"></asp:DropDownList>
            <asp:Label ID="classLabel" runat="server" Text="Ticket Class" Font-Size="X-Small"></asp:Label>
            <asp:DropDownList ID="classDropDownList" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div id="searchButton">
            <asp:Button ID="search" runat="server" OnClick="Button1_Click" Text="Search flights" BackColor="#339933" Font-Size="Small" ForeColor="White" />
            <asp:CheckBox ID="directOnly" runat="server" Font-Size="XX-Small" Height="25px" Width="20px" />
            <asp:Label ID="directLabel" runat="server" Text="Direct flights only" Font-Size="XX-Small" ForeColor="White"></asp:Label>
        </div>
    </div>
    <div id="range">
        <div id="priceRange">
            <asp:Button ID="prRaButton" runat="server" Text="To get flights by price press here" Font-Size="8" OnClick="prRaButton_Click"/>
            <div id="hidePrice">
                <asp:Label ID="minLabel" runat="server" Text="Minimum price: " Font-Size="9" ForeColor="Red" Visible="false"></asp:Label><asp:TextBox ID="minTextBox" runat="server" Font-Size="8" Width="50px" Visible="false"></asp:TextBox>
                <asp:Label ID="maxLabel" runat="server" Text="Maximum price" Font-Size="9" ForeColor="Red" Visible="false"></asp:Label><asp:TextBox ID="maxTextBox" runat="server" Font-Size="8" Width="50px" Visible="false"></asp:TextBox>
                <asp:Button ID="getButton" runat="server" Text="Get flights" Font-Size="8" Visible="false" OnClick="getButton_Click" BackColor="Orange"/>
            </div>
       </div>
        <div id="dateRange">
            <asp:Button ID="dateBu" runat="server" Text="To get flights by date press here" Font-Size="8" OnClick="dateBu_Click"/>
            <div id="Div2">
                <asp:Label ID="stLabel" runat="server" Text="From date: " Font-Size="8" ForeColor="Red" Visible="false" Width="60px"></asp:Label><asp:TextBox ID="stTextBox" runat="server" Font-Size="8" Width="80px" Visible="false"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Input valid date!" ControlToValidate="stTextBox" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$" ></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="endLabel" runat="server" Text="To date:" Font-Size="10" ForeColor="Red" Visible="false" Width="60px"></asp:Label><asp:TextBox ID="endTextBox" runat="server" Font-Size="8" Width="80px" Visible="false"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Input valid date!" ControlToValidate="endTextBox" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"></asp:RegularExpressionValidator>
                <br />
                <asp:Button ID="getDateButton" runat="server" Text="Get flights" Font-Size="8" Visible="false" OnClick="Button2_Click" BackColor="Orange"/>
            </div>
       </div>
    </div>
   </div>
</asp:Content>


