<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplicationCourier.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Comenzi active" OnClick="ComenziActive_Click" Width="245px" />
                 </div><br>
                 <%--<div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Istoric comenzi" Width="245px" />
                </div><br>--%>
                <div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Creeaza comanda noua" OnClick="CreeazaComanda_Click" Width="245px" />
                </div><br>
                <div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Adresele mele" OnClick="Adrese_Click" Width="245px"/>
                </div><br>
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Setari cont" Width="245px" OnClick="Setari_Click"/>
                </div><br>
                  <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Vizualizare cont" Width="245px" OnClick="VizualizareCont_Click"/>
                </div><br>
             </div>
        </div>        
</asp:Content>
