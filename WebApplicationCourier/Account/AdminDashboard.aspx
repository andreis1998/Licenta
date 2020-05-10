<%@ Page Title="AdminDashboard" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="WebApplicationCourier.Account.AdminDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Angajati" Width="245px" OnClick="Angajati_Click"/>
                 </div><br>
                 <div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Clienti" Width="245px" OnClick="Clienti_Click"/>
                </div><br>
                <%--<div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Comenzi" Width="245px" OnClick="Comenzi_Click"/>
                </div><br>--%>
                <div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Sedii" Width="245px" OnClick="Sedii_Click"/>
                </div><br>
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Masini" Width="245px" OnClick="Masini_Click"/>
                </div><br>
                  <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Adrese" Width="245px" OnClick="Adrese_Click"/>
                </div><br>
             </div>
        </div>        
</asp:Content>
