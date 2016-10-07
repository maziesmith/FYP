<%@ Page Title="Record" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QueryList.aspx.cs" Inherits="WebApplication1.QueryList" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 style="width: 100%; text-align:center; height: 5%">Search Record</h3>
 
       
    <asp:Table  ID="Query_table" HorizontalAlign="Center" runat="server" CssClass="table " Width="50%" BackColor="White">
    <asp:TableHeaderRow EnableTheming="true"  >
       <asp:TableHeaderCell>#</asp:TableHeaderCell>
        <asp:TableHeaderCell>Search Title</asp:TableHeaderCell>
        <asp:TableHeaderCell>Date</asp:TableHeaderCell>
        <asp:TableHeaderCell Visible="false">Qid</asp:TableHeaderCell>
      
    </asp:TableHeaderRow>
    </asp:Table>
    <br />
</asp:Content>
