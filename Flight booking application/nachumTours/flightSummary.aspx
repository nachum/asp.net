<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="flightSummary.aspx.cs" Inherits="nachumTours.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <link rel="stylesheet" href = "summaryCss.css"  type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
  <asp:ListView ID="listAlong" runat="server" > 
        <LayoutTemplate> 
            <table id="det" cellpadding:"4"> 
                <tr > 
                    <th>Flight Along Details</th> 
                </tr> 
                <tr id="itemplaceholder" runat="server"></tr> 
            </table> 
       </LayoutTemplate>
       <ItemTemplate>
             <tr class="bodyColors"> 
                <td><asp:Label ID="alDet" Text='<%#Eval("Along") %>' runat="server"></asp:Label></td> 
             </tr> 
       </ItemTemplate>  
    </asp:ListView><br /><br /> 

  <asp:ListView ID="ListBack" runat="server" > 
        <LayoutTemplate> 
            <table id="det" cellpadding:"4" > 
                <tr > 
                    <th>Flight Back Deatails</th> 
                </tr> 
                <tr id="itemplaceholder" runat="server"></tr> 
            </table> 
       </LayoutTemplate>
       <ItemTemplate>
             <tr > 
                <td><asp:Label ID="baDet" Text='<%#Eval("Back") %>' runat="server"></asp:Label></td> 
             </tr> 
       </ItemTemplate>  
    </asp:ListView><br /><br /> 

    <asp:ListView ID="priceBuy" runat="server" > 
        <LayoutTemplate> 
            <table id="det" cellpadding:"4" > 
                <tr id="itemplaceholder" runat="server"></tr> 
            </table> 
       </LayoutTemplate>
       <ItemTemplate>
             <tr > 
                <td><asp:Label ID="priceDet" Text='<%#Eval("prices") %>' runat="server"></asp:Label></td> 
                 <td><asp:Button ID="Buy" runat="server" Text="Buy" OnClick="Buy_Click" /></td>
            </tr> 
       </ItemTemplate>  
    </asp:ListView><br /><br /> 
</asp:Content>

