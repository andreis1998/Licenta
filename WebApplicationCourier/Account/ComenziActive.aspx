<%@ Page Language="C#" Title="Comenzi active" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComenziActive.aspx.cs" Inherits="WebApplicationCourier.Account.ComenziActive" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <div class="col-md-10">
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="ComenziBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div><br>
                 </div><br>
                
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
