<%@ Page Title="Sedii" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sedii.aspx.cs" Inherits="WebApplicationCourier.Account.Sedii" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                 <div class="col-md-10">
                     <asp:Button runat="server" CssClass="btn btn-default" Text="Vizualizare sedii" Width="245px" OnClick="ListSedii_Click" AutoPostBack="true"/>
                     <asp:DropDownList ID="ModVizualizare" runat="server" Width="400px">
                         <asp:ListItem Enabled="true" Text="" Value="0"/>
                         <asp:ListItem Text="Alfabetic dupa adresa ASC" Value="1"/>
                         <asp:ListItem Text="Alfabetic dupa adresa DESC" Value="2"/>
                         <asp:ListItem Text="Alfabetic dupa manager ASC" Value="3"/>
                         <asp:ListItem Text="Alfabetic dupa manager DESC" Value="4"/>
                     </asp:DropDownList><br>
                     <div class="col-md-10">
                       <asp:TextBox runat="server" Width="600px" Height="300px" ID="SediiBox" BorderStyle="None" ReadOnly="True" TextMode="MultiLine" Visible="false" Font-Size="Larger"></asp:TextBox>                
                    </div>
                 </div><br>
                 <%--<div class="col-md-10">                  
                    <h4>Adauga sediu</h4>
                    <asp:Label runat="server" CssClass="col-md-2 control-label" Width="300px">Adresa:</asp:Label>
                    <asp:TextBox runat="server" ID="AdresaSediu" CssClass="form-control" Width="300px"/><br>
                    <asp:Label runat="server" CssClass="col-md-2 control-label" Width="300px">Introduce numele complet al managerului:</asp:Label>
                    <asp:TextBox runat="server" ID="ManagerSediu" CssClass="form-control" Width="300px"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Adauga" Width="245px" OnClick="AddSediu_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmAddSediu" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Sediu adaugat</asp:Label>
                </div><br><br><br>--%>
                <%--<div class="col-md-10">
                    <h4>Sterge sediu</h4>
                    <asp:DropDownList ID="Sediu" runat="server" OnSelectedIndexChanged="Sediu_SelectedIndexChanged" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                    </asp:DropDownList><br>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Sediu" InitialValue="-1" ErrorMessage="Sediu nu a fost ales." CssClass="text-danger"/><br>
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Sterge" Width="245px" OnClick="DeleteSediu_Click"/><br>
                    <asp:Label runat="server" ID="ConfirmDeleteSediu" CssClass="text-danger" Visible="False" ForeColor="#99CC00">Sediu sters</asp:Label>
                </div><br><br><br>--%>
                <%--<div class="col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-default" Text="Cauta Sediu" Width="245px"/>
                </div><br>--%>
             </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
