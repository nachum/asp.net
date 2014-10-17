<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="flightTable.aspx.cs" Inherits="nachumTours.flightTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <link rel="stylesheet" href = "flightTableCss.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div class="fli">
     <asp:ListView ID="listview1" runat="server" > 
        <LayoutTemplate> 
            <table id="fl" cellpadding:"4"> 
                <tr class="headLine" style="background-color:#E5E5FE"> 
                    <th>Flight Along</th> 
                    <th>Flight Back</th> 
                    <th>Stops</th>
                    <th>Price</th>
                </tr> 
                <tr id="itemplaceholder" runat="server"></tr> 
            </table> 
       </LayoutTemplate>
       <ItemTemplate>
             <tr class="bodyColors"> 
                <td><asp:Label ID="txtFName" Text='<%#Eval("Flight Along") %>' runat="server"></asp:Label></td> 
                <td><asp:Label ID="txtLName" Text='<%#Eval("Flight Back") %>' runat="server"></asp:Label></td> 
                <td><asp:Label ID="txtCompany" Text='<%#Eval("Stops") %>' runat="server"></asp:Label></td> 
                <td><asp:Label ID="PriceLabel" Text='<%#Eval("Price") %>' runat="server"></asp:Label></td>
                <td><asp:Button ID="details"  text="Select" runat="server" OnCommand="details_Command" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button></td>  
             </tr> 
       </ItemTemplate>  
    </asp:ListView><br /><br />  
 </div>   
  
</asp:Content>
