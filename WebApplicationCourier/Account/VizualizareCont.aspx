<%@ Page Title="Detalii cont" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VizualizareCont.aspx.cs" Inherits="WebApplicationCourier.Account.VizualizareCont" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
    <div class="row">
        <div class="col-md-8">
            <div class="form-group">
                <asp:Label runat="server" ID="Username" Font-Size="Larger">Username:</asp:Label>
                <asp:Label runat="server" ID="UsernameValue" Font-Size="Larger"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="Nume" Font-Size="Larger">Nume: </asp:Label>
                <asp:Label runat="server" ID="NumeValue" Font-Size="Larger"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="Prenume" Font-Size="Larger">Prenume: </asp:Label>
                <asp:Label runat="server" ID="PrenumeValue" Font-Size="Larger"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="Email" Font-Size="Larger">Email: </asp:Label>
                <asp:Label runat="server" ID="EmailValue" Font-Size="Larger"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="NumarDeTelefon" Font-Size="Larger">Numar de telefon: </asp:Label>
                <asp:Label runat="server" ID="NumarDeTelefonValue" Font-Size="Larger"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="DataNasterii" Font-Size="Larger">Data nasterii: </asp:Label>
                <asp:Label runat="server" ID="DataNasteriiValue" Font-Size="Larger"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="TipCont" Font-Size="Larger">Tipul de cont: </asp:Label>
                <asp:Label runat="server" ID="TipContValue" Font-Size="Larger"></asp:Label>
            </div>
        </div>
    </div>
     <br><asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
