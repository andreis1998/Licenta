<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplicationCourier.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!--<style>
    label.a {
        font-size: 13px;
    }

    label.b {
        font-size: large;
    }

    label.c {
        font-size: 150%;
    }
    </style>-->

    <h2><%: Title %></h2>
    <p class="text-danger">
        <!--<asp:Literal runat="server" ID="ErrorMessage" />-->
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" OnTextChanged="Username_TextChanged" AutoPostBack="true" Width="300px"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                    CssClass="text-danger" ErrorMessage="The username field is required." /><br>
                <asp:Label runat="server" CssClass="text-danger" ID="DuplicateUser" Visible="False">Acest username este deja ales.</asp:Label>
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
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" Width="300px"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
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
            <asp:Label runat="server" AssociatedControlID="TipCont" CssClass="col-md-2 control-label">Tipul de cont:</asp:Label>
            <div class="col-md-10">
              <asp:DropDownList ID="TipCont" runat="server" OnSelectedIndexChanged="TipCont_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Enabled="true" Text="Selecteaza contul" Value="0"/>
                <asp:ListItem Text="Cont standard" Value="1"/>
                <asp:ListItem Text="Cont plus" Value="2"/>
                <asp:ListItem Text="Cont premium" Value="4"/>
              </asp:DropDownList><br>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TipCont"
                    InitialValue="-1" ErrorMessage="Tipul de cont nu a fost ales." CssClass="text-danger"/>
            </div>
        </div>
        <div class="form_group">
            <asp:Label runat="server" AssociatedControlID="Descriere" CssClass="col-md-2 control-label">Descriere cont</asp:Label>
            <div class="col-md-10">
               <asp:TextBox runat="server" Width="400px" Height="200px" ID="Descriere" BorderStyle="None" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>                
            </div>
        </div>
        <br>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    
</asp:Content>
