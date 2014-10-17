<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="flightsBetween.aspx.cs" Inherits="nachumTours.flightsBetween" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <link rel="stylesheet" href = "betweenCss.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pad">
    <h2>FLIGHTS BETWEEN</h2>
    <asp:Label ID="betLabel" runat="server" Text=""></asp:Label>
        </div>
</asp:Content>
