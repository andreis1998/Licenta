<%@ Page Title="Masini" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Masini.aspx.cs" Inherits="WebApplicationCourier.Account.Masini" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Vizualizare masini" Width="245px" OnClick="ListCars_Click" />
                     <asp:DropDownList ID="ModVizualizare" runat="server" Width="400px">
                         <asp:ListItem Enabled="true" Text="" Value="0"/>
                         <asp:ListItem Text="Alfabetic dupa marca ASC" Value="1"/>
                         <asp:ListItem Text="Alfabetic dupa marca DESC" Value="2"/>
                         <asp:ListItem Text="Dupa an ASC" Value="3"/>
                         <asp:ListItem Text="Dupa an DESC" Value="4"/>
                         <asp:ListItem Text="Dupa numarul de km ASC" Value="5"/>
                         <asp:ListItem Text="Dupa numarul de km DESC" Value="6"/>
                         <asp:ListItem Text="Dupa categorie" Value="7"/>
                         <asp:ListItem Text="Dupa sediu" Value="8"/>
                     </asp:DropDownList><br>
                     <div class="col-md-10">
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="MasiniBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div>
                 </div><br><br><br>
                 <hr />
                 <div class="col-md-10">                  
                    <h4>Adauga masina</h4>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Marca:</asp:Label>
                    <asp:TextBox runat="server" ID="Marca" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Model:</asp:Label>
                    <asp:TextBox runat="server" ID="Model" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Anul fabricatiei:</asp:Label>
                    <asp:TextBox runat="server" ID="An" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Numar kilometri:</asp:Label>
                    <asp:TextBox runat="server" ID="NrKm" CssClass="form-control" Width="300px"/><br>
                     <asp:Label runat="server" CssClass="col-md-2 control-label">Alege tipul masini (categoria)</asp:Label><br>
                     <asp:DropDownList ID="Categorie" runat="server" Width="400px">
                         <asp:ListItem Enabled="true" Text="" Value="0"/>
                         <asp:ListItem Text="Masina mica" Value="1"/>
                         <asp:ListItem Text="Masina medie" Value="2"/>
                         <asp:ListItem Text="Masina mare" Value="3"/>
                     </asp:DropDownList><br><br><br>
                     <asp:Label runat="server" CssClass="col-md-2 control-label">Alege sediul masini</asp:Label><br>
                    <asp:DropDownList ID="Sediu" runat="server" OnSelectedIndexChanged="Sediu_SelectedIndexChanged" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Sediu" InitialValue="-1" ErrorMessage="Masina nu a fost aleasa." CssClass="text-danger"/><br>
                     <asp:Label runat="server" CssClass="col-md-2 control-label">Alte detalii</asp:Label>
                    <asp:TextBox runat="server" ID="AlteDetalii" CssClass="form-control" Width="400px" Height="80px" TextMode="MultiLine"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Adauga" Width="245px" OnClick="AddMasina_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmAddMasina" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Masina adaugata</asp:Label>
                </div><br><br><br>
                <div class="col-md-10">
                    <h4>Sterge masina</h4>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Alege masina</asp:Label><br>
                    <asp:DropDownList ID="Masina" runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Masina" InitialValue="-1" ErrorMessage="Masina nu a fost aleasa." CssClass="text-danger"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Sterge" Width="245px" OnClick="DeleteMasina_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmDeleteMasina" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Masina stearsa</asp:Label>
                </div><br><br><br>
                <%--<div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Cauta masina" Width="245px"/>
                </div><br>--%>
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>