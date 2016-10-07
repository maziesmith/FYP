<%@ Page Title="Detailed Record" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query_Record.aspx.cs" Inherits="WebApplication1.Query_Record" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 style="width: 100%; text-align: center; height: 5%">Search Record - Detailed View</h3>
    <br />
   
    
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-danger leftBorder" >


                <div class="panel-heading">

                    <div class="radio" style="padding: 5px;">

                        <label style="font-size:large;">Search Parameters</label>
                               
                    </div>

                </div>
                <div id="Param"  class="panel-body">



                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Search Title:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_Search1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_Search"></label>--%>
                            </div>
                        </div>


                        <div class="col-md-8" style="padding: 0px;">
                            <div class="col-md-2" style="padding: 0px;">
                                <label class="control-label">Data File:</label>
                            </div>
                            <div class="col-md-10" style="padding-left: 24px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_Data1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_Data"></label>--%>
                            </div>
                        </div>

                    </div>




                    <div class="col-md-12" style="padding-left: 0px;">


                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Database:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_DB1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_DB"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Peptide Tol:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_PT1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_PT"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label class="control-label">Unit:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 10px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_PTU1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_PTU"></label>--%>
                            </div>
                        </div>

                    </div>


                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label id="P_FRGL" runat="server" class="control-label">Frag. Type:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_FRG1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_FRG"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label id="P_SIL" runat="server" class="control-label">Speial Ions:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_SI1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_SI"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label class="control-label"># of Outputs:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 10px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_NO1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_NO"></label>--%>
                            </div>
                        </div>

                    </div>


                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Autotune:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_AU1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_AU"></label>--%>
                            </div>
                        </div>


                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px; width: auto;">
                                <label id="P_MTL" runat="server" style="padding: 0px;" class="control-label">MW Tol:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 90px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_MT1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_MT"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label id="P_MTUL" runat="server" class="control-label">Unit:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 10px;">
                                <asp:Label runat="server" CssClass="control-label" ClientIDMode="Static" ID="P_MTU1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_MTU"></label>--%>
                            </div>
                        </div>





                    </div>


                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label class="control-label">Filter DB by MW:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_FDB1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_FDB"></label>--%>
                            </div>
                        </div>


                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Protein Mass:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_ProMass1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_ProMass"></label>--%>
                            </div>
                        </div>

                    </div>

                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Extract PSTs:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_EPT1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_EPT"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label id="P_MINL" runat="server" class="control-label">Min PST Len:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_MIN1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_MIN"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label runat="server" id="P_MAXL" class="control-label">Max PST Len:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 10px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_MAX1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_MAX"></label>--%>
                            </div>
                        </div>

                    </div>


                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Predict PTMs:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" CssClass="control-label" ClientIDMode="Static" ID="P_PTM1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_PTM"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label id="P_NOSL" runat="server" class="control-label"># of Mods:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_NOS1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_NOS"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label id="P_PTMTL" runat="server" class="control-label">PTM Tol:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 10px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_PTMT1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_PTMT"></label>--%>
                            </div>
                        </div>

                    </div>



                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">MW Score Weight:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_MWSW1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_MWSW"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">PST Score Weight:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="P_PSTW1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_PSTW"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-5" style="padding: 0px;">
                                <label class="control-label">Insilico Score Weight:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 10px;">
                                <asp:Label runat="server" CssClass="control-label" ClientIDMode="Static" ID="P_INSW1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="P_INSW"></label>--%>
                            </div>
                        </div>

                    </div>


                </div>
            </div>

        </div>
    </div>



    <br />
    <%--<asp:Table  ID="Query_table" runat="server" HorizontalAlign="Center" CssClass="table " Width="70%" BackColor="White">
    <asp:TableHeaderRow EnableTheming="true"  >
        <asp:TableHeaderCell>Parameter</asp:TableHeaderCell>
        <asp:TableHeaderCell>Value</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    </asp:Table>
    <br />--%>
    <h4 style="text-align: center; font-size:large;">Results List</h4>

    <asp:Table ID="Result_table" HorizontalAlign="Center" runat="server" CssClass="table " Width="50%" BackColor="White">
        <asp:TableHeaderRow EnableTheming="true">
            <asp:TableHeaderCell>#</asp:TableHeaderCell>
            <asp:TableHeaderCell>Protein&nbsp;Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Score</asp:TableHeaderCell>
            <asp:TableHeaderCell>No of Modifications</asp:TableHeaderCell>
            <asp:TableHeaderCell Visible="false" HorizontalAlign="Center">Detailed</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
