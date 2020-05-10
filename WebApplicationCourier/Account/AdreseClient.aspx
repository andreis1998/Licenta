<%@ Page Title="Adresele mele" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdreseClient.aspx.cs" Inherits="WebApplicationCourier.Account.AdreseClient" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Vizualizare adrese" Width="245px" OnClick="ListAdrese_Click"/>
                     <asp:DropDownList ID="ModVizualizare" runat="server" Width="400px">
                         <asp:ListItem Enabled="true" Text="" Value="0"/>
                         <asp:ListItem Text="Alfabetic dupa strada ASC" Value="1"/>
                         <asp:ListItem Text="Alfabetic dupa strada DESC" Value="2"/>
                     </asp:DropDownList><br>
                     <div class="col-md-10">
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="AdreseBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div>
                 </div><br><br><br>
                 <hr />
                 <div class="col-md-10">                  
                    <h4>Adauga adresa din baza de date</h4>
                     <asp:DropDownList ID="AdresaAdauga" runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br><br>
                    <h4>Adauga adresa noua</h4>
                    <asp:Label runat="server" ID="AdresaDuplicata" CssClass="text-danger" Visible="false">Adresa deja existenta</asp:Label><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Strada:</asp:Label>
                    <asp:TextBox runat="server" ID="Strada" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Numar:</asp:Label>
                    <asp:TextBox runat="server" ID="Numar" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Bloc:</asp:Label>
                    <asp:TextBox runat="server" ID="Bloc" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Scara:</asp:Label>
                    <asp:TextBox runat="server" ID="Scara" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Etaj:</asp:Label>
                    <asp:TextBox runat="server" ID="Etaj" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Apartament:</asp:Label>
                    <asp:TextBox runat="server" ID="Apartament" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Alte detalii</asp:Label>
                    <asp:TextBox runat="server" ID="AlteDetalii" CssClass="form-control" Width="400px" Height="80px" TextMode="MultiLine"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Adauga" Width="245px" OnClick="AddAdresa_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmAddAdresa" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Adresa adaugata</asp:Label>
                </div><br><br><br>
                <div class="col-md-10">
                    <h4>Sterge adresa</h4>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Alege adresa</asp:Label><br>
                    <asp:DropDownList ID="Adresa" runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Adresa" InitialValue="-1" ErrorMessage="Adresa nu a fost aleasa." CssClass="text-danger"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Sterge" Width="245px" OnClick="DeleteAdresa_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmDeleteAdresa" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Adresa stearsa</asp:Label>
                </div><br>
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
