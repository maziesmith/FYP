<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Account.Login" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Login</h2>
     <h4>Use a local account to log in.</h4>
    <div class="row">
        <div class="container">

            <div class="form-horizontal">
               
                <hr />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>

                <div class="form-group">

                    <div>
                        <asp:Label runat="server" CssClass="col-md-2 control-label"  AssociatedControlID="text">User&nbsp;Name:</asp:Label>
                        <asp:TextBox runat="server" ID="text" CssClass="form-control col-md-10" TextMode="SingleLine" />
                    </div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="text" CssClass="text-danger" ErrorMessage="The User Id field is required." />

                </div>

                <div class="form-group">
                    <div >
                        <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control col-md-10" />
                    </div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger col-md-10" ErrorMessage="The password field is required." />
                </div>


                
                    <div class="col-md-offset-1 col-md-10">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                        <br /><br />
                        <asp:Label runat="server" ID="login_stat"></asp:Label>
                    </div>
             
                   <div class="form-group">
                      
                <asp:HyperLink runat="server" NavigateUrl="~/Account/Register.aspx" ID="RegisterHyperLink" CssClass="btn btn-derfault" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
            <p id="testing" />
                   </div>
                </div>
        </div>
    </div>


    








    <script>
        var uri = "http://203.135.63.101/shifaa/api/users/Get_login/mani/123";

        function login()
        {
        
            var id = $('#text').val();
            var pwd = $('#Password').val();
        
            id = "mani";
            pwd = "123";

       


            $.getJSON(uri)
                    .done(function (data) {
                        $('#testing').text(data.toString());
                    })
                    .fail(function (jqXHR, textStatus, err) {
                        $('#testing').text(uri + "/" + id + "/" + pwd + '--Error: ' + err);
                    });
        }

        </script>





</asp:Content>
