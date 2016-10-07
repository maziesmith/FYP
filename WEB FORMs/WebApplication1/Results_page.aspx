<%@ Page Title="Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results_page.aspx.cs" Inherits="WebApplication1.Results_page" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <h3 style="width: 100%; text-align:center; height: 5%">Search Results&nbsp;&nbsp;<small><small><asp:LinkButton runat="server" OnClick="Unnamed_Click" >Download Results</asp:LinkButton></small></small></h3>
  
<asp:Table  ID="aspTable" runat="server" HorizontalAlign="Center" CssClass="table " Width="40%"  BackColor="White">
    <asp:TableHeaderRow EnableTheming="true" HorizontalAlign="Center">
        <asp:TableHeaderCell HorizontalAlign="Center" >#</asp:TableHeaderCell>
        <asp:TableHeaderCell HorizontalAlign="Center">Protein&nbsp;ID</asp:TableHeaderCell>
        <asp:TableHeaderCell HorizontalAlign="Center">Score</asp:TableHeaderCell>
        <asp:TableHeaderCell HorizontalAlign="Center">No of Modifications</asp:TableHeaderCell>
        <asp:TableHeaderCell Visible="false" HorizontalAlign="Center">Detailed</asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>
   
</asp:Content>
