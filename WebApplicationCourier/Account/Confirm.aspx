<%@ Page Title="Account Confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="WebApplicationCourier.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Multumim pentru contul creat pe site-ul nostru. Dati click <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aici</asp:HyperLink>  pentru log in            
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
