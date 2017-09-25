<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ChickenCoop.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />


    <fieldset>
        <legend>Login</legend>
        <div class="form-group col-lg-12 col-md-offset-2">
            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" ControlToValidate="txtEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <br />
        <div class="form-group col-lg-12 col-md-offset-2">
            <asp:Label ID="lblPwd" runat="server" Text="Password" CssClass="col-lg-2 control-label"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPwd" runat="server" Display="None" ControlToValidate="txtPwd" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />




    </fieldset>



        <div class="btn-group btn-group-justified">

            <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-default" PostBackUrl="~/Door" CausesValidation="false">Cancel</asp:LinkButton>


            <asp:LinkButton ID="lbLogin" runat="server" CssClass="btn btn-primary" CausesValidation="true" OnClick="btnLogin_Click">Login</asp:LinkButton>
        </div>


    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />







    <br />
    <br />
</asp:Content>
