<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="nachumTours.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your contact page.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>08-1234567</span>
        </p>
        <p>
            <span class="label">After Hours:</span>
            <span>054-1234567</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:Support@nachum.com">Support@nachum.com</a></span>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <span><a href="mailto:Marketing@nachum.com">Marketing@nachum.com</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:General@nachum.com">General@nachum.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Jerusalem<br />
            Beit-Hakerem, Hehaluz 23
        </p>
    </section>
</asp:Content>