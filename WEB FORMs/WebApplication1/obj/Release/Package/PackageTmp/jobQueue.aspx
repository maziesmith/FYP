<%@ Page Title="JobQueue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="jobQueue.aspx.cs" Inherits="WebApplication1.jobQueue" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div style="align-content:center; text-align:center;">
    <asp:Image runat="server" ImageUrl="http://gdurl.com/GXkP" ImageAlign="AbsMiddle" Width="40%" />
    <br />
    <br />
    <asp:Label runat="server" Font-Size="X-Large" Font-Bold="false">Thank You for using Perceptron!<br /></asp:Label>
   <asp:Label runat="server" Font-Size="Medium"  Font-Bold="false"> You data has been submitted to Perceptron's server. The search results will be sent back to you via email<br /> as soon as they are computed.
    Kindly check your email adress with which you registered.</asp:Label>
        </div>
</asp:Content>
