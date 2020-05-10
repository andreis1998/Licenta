<%@ Page Language="C#" Title="Comanda noua" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreeazaComanda.aspx.cs" Inherits="WebApplicationCourier.Account.CreeazaComanda" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                    <h4>Adresa</h4>
                    <asp:DropDownList ID="Adresa" runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Adresa" InitialValue="-1" ErrorMessage="Adresa nu a fost aleasa." CssClass="text-danger"/><br>
                     <h4>Informatii colete</h4>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Denumire</asp:Label>
                    <asp:TextBox runat="server" ID="Denumire" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Pret</asp:Label>
                    <asp:TextBox runat="server" ID="Pret" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Greutate</asp:Label>
                    <asp:TextBox runat="server" ID="Greutate" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Dimensiuni ({latime}x{lungime}x{inaltime})</asp:Label>
                    <asp:TextBox runat="server" ID="Dimensiuni" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Cantitate</asp:Label>
                    <asp:TextBox runat="server" ID="Cantitate" CssClass="form-control" Width="300px"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Adauga colet" Width="245px" OnClick="AddColet_Click"/><br><br>

                    <asp:Label runat="server" CssClass="col-md-2 control-label">Observatii</asp:Label>
                    <asp:TextBox runat="server" ID="AlteDetalii" CssClass="form-control" Width="400px" Height="80px" TextMode="MultiLine"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Plaseaza" Width="245px" OnClick="AddComanda_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmComanda" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Comanda plasata</asp:Label>
                </div><br>
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
