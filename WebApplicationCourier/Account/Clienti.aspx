<%@ Page Title="Clienti" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clienti.aspx.cs" Inherits="WebApplicationCourier.Account.Clienti" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Vizualizare clienti" Width="245px" OnClick="ListClienti_Click" />
                     <asp:DropDownList ID="ModVizualizare" runat="server" Width="400px">
                         <asp:ListItem Enabled="true" Text="" Value="0"/>
                         <asp:ListItem Text="Dupa nume ASC" Value="1"/>
                         <asp:ListItem Text="Dupa nume DESC" Value="2"/>
                         <asp:ListItem Text="Dupa prenume ASC" Value="3"/>
                         <asp:ListItem Text="Dupa prenume DESC" Value="4"/>
                         <asp:ListItem Text="Dupa data nasterii ASC" Value="5"/>
                         <asp:ListItem Text="Dupa data nasterii DESC" Value="6"/>
                         <asp:ListItem Text="Dupa email" Value="7"/>
                         <asp:ListItem Text="Dupa categorie" Value="8"/>
                         <asp:ListItem Text="Dupa username" Value="9"/>
                     </asp:DropDownList><br>
                     <div class="col-md-10">
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="ClientiBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div><br>
                 </div><br>
                <div class="col-md-10">
                    <h4>Sterge client</h4>
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Alege client</asp:Label><br>
                    <asp:DropDownList ID="Client" runat="server" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Client" InitialValue="-1" ErrorMessage="Clientul nu a fost ales." CssClass="text-danger"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Sterge" Width="245px" OnClick="DeleteClient_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmDeleteClient" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Cont client sters</asp:Label>
                </div><br><br><br>
                <%--<div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Cauta clienti" Width="245px"/>
                </div><br>--%>
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
