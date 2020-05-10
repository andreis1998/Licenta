<%@ Page Title="Setari cont" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setari_cont.aspx.cs" Inherits="WebApplicationCourier.Account.Setari_cont" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
    <h2><%: Title %></h2><br><br>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <h4>Schimba adresa de email</h4>
                <hr />
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Introduce adresa veche de email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="oldEmail" CssClass="form-control" Width="300px" TextMode="Email" />
                        <asp:Label runat="server" ID="oldEmailLbl" CssClass="text-danger" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Introduce adresa noua de email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="newEmail" CssClass="form-control" TextMode="Email" Width="300px"/>
                        <asp:Label runat="server" CssClass="text-danger" ID="newEmailLbl" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Schimba Email" CssClass="btn btn-default" OnClick="ChangeEmail_Click" /><br>
                        <asp:Label runat="server" ID="changeEmail" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
            <br><br>
            <div class="form-horizontal">
                <h4>Schimba numarul de telefon</h4>
                <hr />
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Introduce noul numar de telefon</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="newPhone" CssClass="form-control" TextMode="Phone" Width="300px"/>
                        <asp:Label runat="server" CssClass="text-danger" ID="newPhoneLbl" Visible="False">Numarul de telefon este gresit.</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Schimba numarul de telefon" CssClass="btn btn-default" OnClick="ChangePhone_Click"/><br>
                        <asp:Label runat="server" ID="changePhone" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
            <br><br>
            <div class="form-horizontal">
                <h4>Schimba parola</h4>
                <hr />
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Introduce parola veche</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="oldPassword" CssClass="form-control" TextMode="Password" Width="300px" />
                        <asp:Label runat="server" CssClass="text-danger" ID="oldPasswordLbl" Visible="false">Parola este gresita.</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Introduce parola noua</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="newPassword" CssClass="form-control" TextMode="Password" Width="300px" />
                        <asp:Label runat="server" ID="newPasswordLbl" Visible="false" CssCLass="text-danger">Parola neintrodusa</asp:Label><br>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Confirma parola</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="newPasswordConfirm" CssClass="form-control" TextMode="Password" Width="300px" />
                        <asp:Label runat="server" CssClass="text-danger" ID="confirmPasswordLbl" Visible="false">Parolele nu sunt identice</asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button runat="server" Text="Schimba parola" CssClass="btn btn-default" OnClick="ChangePassword_Click" /><br>
                        <asp:Label runat="server" ID="changePassword" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
            <br><br>
            <div class="form-horizontal">
                <h4>Schimba tipul de cont</h4>
                <hr />
                <div class="form-group">
                    <div class="col-md-10">
                      <asp:DropDownList ID="TipCont" runat="server" OnSelectedIndexChanged="ChangeTipCont_Click">
                        <asp:ListItem Enabled="true" Text="Selecteaza contul" Value="0"/>
                        <asp:ListItem Text="Cont standard" Value="1"/>
                        <asp:ListItem Text="Cont plus" Value="2"/>
                        <asp:ListItem Text="Cont premium" Value="4"/>
                      </asp:DropDownList><br>
                       <asp:Label runat="server" ID="changeTipCont" Visible="false"></asp:Label><br><br>
                      <asp:Button runat="server" Text="Aplica" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br><asp:Button runat="server" CssClass="btn btn-default" Text="<--" OnClick="Back_Click"/>
</asp:Content>

