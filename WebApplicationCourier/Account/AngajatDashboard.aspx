<%@ Page Language="C#" Title="AngajatDashboard" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AngajatDashboard.aspx.cs" Inherits="WebApplicationCourier.Account.AngajatDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <div class="col-md-10">
                        <h4>Comenzi</h4>
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="ComenziBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div><br>
                 </div><br>
                
             </div>
        </div>
</asp:Content>
