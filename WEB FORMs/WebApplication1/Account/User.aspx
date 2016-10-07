<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication1.Account.User" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Manage Your Account</h2>
     <h4>Edit Your Personal Information.</h4>

    <div class="row">
        <div class="container">
            <div class="form-horizontal">
                <hr />
                
                <div class="form-group">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Name">New Name</asp:Label>
                      <asp:TextBox runat="server"  ID="Name" CssClass="form-control col-md-10" TextMode="SingleLine" />
                   

                </div>
                <div class="form-group">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Email">New Email</asp:Label>
                   <asp:TextBox runat="server"  ID="Email" CssClass="form-control col-md-10" TextMode="SingleLine" />     
                   
                    <asp:RegularExpressionValidator Display="Dynamic" ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" ControlToValidate="Email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                    

                </div>
                
                    <div class="col-md-offset-1 col-md-10">
                        <br />
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:Button runat="server" OnClick="Unnamed_Click" Text="Update Info" CssClass="btn btn-default" />
                        <br /> <br />
                       <br />
                        <asp:Label ID="Update"  CssClass="text-danger control-label"   runat="server"></asp:Label>
                    </div>





                <hr />
                <div class="form-group">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Password">Old&nbsp;Password</asp:Label>
                    <asp:TextBox runat="server"  ID="TextBox1" TextMode="Password" CssClass="form-control col-md-10" />
                    
                </div>

                <div class="form-group">

                    <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="Password">New&nbsp;Password</asp:Label>
                    <asp:TextBox runat="server"  ID="Password" TextMode="Password" CssClass="form-control col-md-10" />
                    

                </div>
                <div class="form-group">

                    <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="ConfirmPassword">Confirm&nbsp;Password</asp:Label>
                    <asp:TextBox runat="server"  ID="ConfirmPassword" TextMode="Password" CssClass="form-control col-md-10" />
                   
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />

                </div>

                
                    <div class="col-md-offset-1 col-md-10">
                        <br />
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:Button runat="server" OnClick="Unnamed_Click1" Text="Update Password" CssClass="btn btn-default" />
                        <br /> <br />
                       <br />
                         <asp:Label ID="Pass"  CssClass="text-danger control-label"   runat="server"></asp:Label>
                    </div>

                </div>
            
        </div>
    </div>

</asp:Content>
