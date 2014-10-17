<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="finish.aspx.cs" Inherits="nachumTours.finish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <link rel="stylesheet" href = "finishCss.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="booking">
        <h2>BOOKING SUMMARY</h2>
        <h4>Booking has finished successfully</h4>
        <h4>Tickets have been sent to your E-mail</h4>
        <asp:Label ID="passengersLabel" runat="server" Text=""></asp:Label>
    </div>
    
</asp:Content>
