<%@ Page Title="Angajati" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Angajati.aspx.cs" Inherits="WebApplicationCourier.Account.Angajati" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Vizualizare angajati" Width="245px" OnClick="ListAngajati_Click" />
                     <asp:DropDownList ID="ModVizualizare" runat="server" Width="400px">
                         <asp:ListItem Enabled="true" Text="" Value="0"/>
                         <asp:ListItem Text="Dupa nume ASC" Value="1"/>
                         <asp:ListItem Text="Dupa nume DESC" Value="2"/>
                         <asp:ListItem Text="Dupa prenume ASC" Value="3"/>
                         <asp:ListItem Text="Dupa prenume DESC" Value="4"/>
                         <asp:ListItem Text="Dupa data nasterii ASC" Value="5"/>
                         <asp:ListItem Text="Dupa data nasterii DESC" Value="6"/>
                         <asp:ListItem Text="Dupa masina ASC" Value="7"/>
                         <asp:ListItem Text="Dupa masina DESC" Value="8"/>
                         <asp:ListItem Text="Dupa sediu" Value="9"/>
                         <asp:ListItem Text="Dupa username" Value="10"/>
                     </asp:DropDownList><br>
                     <div class="col-md-10">
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="AngajatiBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div><br>
                 </div><br>
                 <div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Adauga angajati" Width="245px" OnClick="AddEmployees_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmAddEmployee" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Angajat adaugat</asp:Label>
                </div><br>
                <%--<div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Sterge angajati" Width="245px"/>
                </div><br>
                <div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Cauta angajati" Width="245px"/>
                </div><br>--%>
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
