<%@ Page Title="Adauga angajati" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="AddEmployees.aspx.cs" Inherits="WebApplicationCourier.Account.AddEmployees" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
         <div class="row">
             <div class="col-md-8">
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Username" CssClass="form-control" OnTextChanged="Username_TextChanged" AutoPostBack="true" Width="300px"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                CssClass="text-danger" ErrorMessage="The username field is required." /><br>
                            <asp:Label runat="server" CssClass="text-danger" ID="DuplicateUser" Visible="False">Acest username este deja dat catre alt angajat.</asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Width="300px" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Nume" CssClass="col-md-2 control-label">Nume</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Nume" CssClass="form-control" Width="300px"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Nume"
                                CssClass="text-danger" ErrorMessage="Numele nu a fost completat." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Prenume" CssClass="col-md-2 control-label">Prenume</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Prenume" CssClass="form-control" Width="300px"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Prenume"
                                CssClass="text-danger" ErrorMessage="Prenumele nu a fost completat." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" OnTextChanged="Email_TextChanged" AutoPostBack="true" Width="300px"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." /><br>
                            <asp:Label runat="server" CssClass="text-danger" ID="DuplicateEmail" Visible="False">Exista deja un cont cu acest email.</asp:Label>
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="NrTel" CssClass="col-md-2 control-label">Numar telefon</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NrTel" CssClass="form-control" OnTextChanged="NrTel_TextChanged" AutoPostBack="true" Width="300px"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NrTel"
                                CssClass="text-danger" ErrorMessage="Numarul de telefon nu a fost completat."/><br>
                            <asp:Label runat="server" CssClass="text-danger" ID="IncorrectNumber" Visible="False">Numarul de telefon nu este corect.</asp:Label>
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="col-md-2 control-label"><b>Data Nasterii</b></asp:Label>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:Label runat="server" AssociatedControlID="AnulNasterii" CssClass="col-md-2 control-label">Anul</asp:Label>
                                <asp:TextBox runat="server" ID="AnulNasterii" CssClass="form-control" Width="76px" OnTextChanged="AnulNasterii_TextChanged" AutoPostBack="true"/>
                            <asp:Label runat="server" AssociatedControlID="LunaNasterii" CssClass="col-md-2 control-label">Luna</asp:Label>
                                <asp:TextBox runat="server" ID="LunaNasterii" CssClass="form-control" Width="76px" OnTextChanged="LunaNasterii_TextChanged" AutoPostBack="true"/>
                            <asp:Label runat="server" AssociatedControlID="ZiuaNasterii" CssClass="col-md-2 control-label">Ziua</asp:Label>
                                <asp:TextBox runat="server" ID="ZiuaNasterii" CssClass="form-control" Width="76px" OnTextChanged="ZiuaNasterii_TextChanged" AutoPostBack="true"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="AnulNasterii"
                                    CssClass="text-danger" ErrorMessage="Anul nu a fost completata." />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="LunaNasterii"
                                    CssClass="text-danger" ErrorMessage="Luna nu a fost completata." />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ZiuaNasterii"
                                    CssClass="text-danger" ErrorMessage="Ziua nu a fost completata." /><br>
                                <asp:Label runat="server" CssClass="text-danger" ID="IncorrectYear" Visible="False">Anul este scris gresit.</asp:Label>
                                <asp:Label runat="server" CssClass="text-danger" ID="IncorrectMonth" Visible="False">Luna este scris gresit.</asp:Label>
                                <asp:Label runat="server" CssClass="text-danger" ID="IncorrectDay" Visible="False">Ziua este scris gresit.</asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Sex" CssClass="col-md-2 control-label">Sex</asp:Label>
                        <div class="col-md-10">
                            <asp:RadioButtonList ID="Sex" runat="server">
                                <asp:ListItem Text="Barbat" Value="M" />
                                <asp:ListItem Text="Femeie" Value="F" />
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Sex"
                                CssClass="text-danger" ErrorMessage="Sexul nu a fost ales." />
                        </div>
                    </div>
                     <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Adresa" CssClass="col-md-2 control-label">Adresa</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Adresa" CssClass="form-control" Width="300px"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Adresa"
                                    CssClass="text-danger" ErrorMessage="Adresa nu a fost completat." />
                            </div>
                    </div>
                     <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="CNP" CssClass="col-md-2 control-label">CNP</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="CNP" CssClass="form-control" Width="300px"/>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CNP"
                                        CssClass="text-danger" ErrorMessage="CNP-ul nu a fost completat." />
                                </div>
                    </div>
                      <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Sediu" CssClass="col-md-2 control-label">Sediu</asp:Label>
                        <div class="col-md-10">
                          <asp:DropDownList ID="Sediu" runat="server" OnSelectedIndexChanged="Sediu_SelectedIndexChanged" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                          </asp:DropDownList><br>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Sediu"
                                InitialValue="-1" ErrorMessage="Sediu nu a fost ales." CssClass="text-danger"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Masina" CssClass="col-md-2 control-label">Masina</asp:Label>
                        <div class="col-md-10">
                          <asp:DropDownList ID="Masina" runat="server" OnSelectedIndexChanged="Sediu_SelectedIndexChanged" AutoPostBack="true" DataTextField="Text" DataValueField="Value" Width="400px">
                          </asp:DropDownList><br>
                        </div>
                    </div>
                    <br>
                    <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" OnClick="AddEmployee_Click" Text="Adauga" CssClass="btn btn-default" />
                    </div>
        </div>
            </div>
        </div>
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>
