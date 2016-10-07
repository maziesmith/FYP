<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" Async="true"%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Register</h2>
    <h4>Create a new account</h4>
    <div class="container">
    <div class="row">
        
            <div class="form-horizontal
                ">
                <hr />
                <asp:ValidationSummary runat="server" CssClass="text-danger" />

                
                <div class="row mar">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Name">Name:</asp:Label>
                      <asp:TextBox runat="server"  ID="Name" CssClass="form-control col-md-10" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                        CssClass="text-danger" ErrorMessage="The name field is required." />

                </div>
                <div class="row mar">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Email">Email:</asp:Label>
                   <asp:TextBox runat="server"  ID="Email" CssClass="form-control col-md-10" TextMode="SingleLine" />     
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="The email field is required." /> 
                    <asp:RegularExpressionValidator Display="Dynamic" ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" ControlToValidate="Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                    

                </div>
                <div class="row mar">
                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="UserKaID">User&nbsp;Name:</asp:Label>
                    <asp:TextBox runat="server" ID="UserKaID" CssClass="form-control col-md-10" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserKaID"
                        CssClass="text-danger" ErrorMessage="The User ID field is required." />
                </div>
                <div class="row mar">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Password">Password:</asp:Label>
                    <asp:TextBox runat="server"  ID="Password" TextMode="Password" CssClass="form-control col-md-10" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="The password field is required." />

                </div>
                <div class="row mar">

                    <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="ConfirmPassword">Confirm&nbsp;Password:</asp:Label>
                    <asp:TextBox runat="server"  ID="ConfirmPassword" TextMode="Password" CssClass="form-control col-md-10" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />

                </div>

                
                    <div class="col-md-offset-1 col-md-10">
                        <br />
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                        <br /> <br />
                       <br />
             <asp:Label ID="reg_stat"  CssClass="text-danger control-label"   runat="server"></asp:Label>
                    </div>
                </div>
            
        </div>
    </div>
</asp:Content>
