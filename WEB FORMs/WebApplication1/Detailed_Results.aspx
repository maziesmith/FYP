<%@ Page Title="Detailed Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detailed_Results.aspx.cs" Inherits="WebApplication1.Detailed_Results" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 style="width: 60%; height: 5%">Search Results - Detailed View &nbsp;&nbsp;<small><small><a href="Results_page.aspx">[Go back to Results page]</a></small></small></h3>

    <hr />

    <div class="col-md-8" style="padding-left: 0px;">
        <div class="col-md-6" style="padding-left: 0px;">
            <div class="col-md-5" style="padding-left: 0px;">
                <label class="control-label">Protein ID:</label>
            </div>
            <div class="col-md-7" style="padding-left: 0px;">
                <asp:Label runat="server" CssClass="control-label" ClientIDMode="Static" ID="text1"></asp:Label>&nbsp;&nbsp;
                <asp:HyperLink runat="server" CssClass="control-label" Target="_blank" ID="head"></asp:HyperLink>
            </div>
        </div>
        <div class="col-md-6" style="padding-left: 0px;">
            <div class="col-md-3" style="padding-left: 0px;">
                <label class="control-label">Rank:</label>
            </div>
            <div class="col-md-9" style="padding-left: 0px;">
                <asp:Label runat="server" ID="rank1" ClientIDMode="Static" CssClass="control-label"></asp:Label>
                <%--<label runat="server" class="control-label" id="rank"></label>--%>
            </div>
        </div>
    </div>


    <div class="col-md-8" style="padding-left: 0px;">
        <div class="col-md-6" style="padding-left: 0px;">
            <div class="col-md-5" style="padding: 0px;">
                <label class="control-label">Molecular Weight:</label>
            </div>
            <div class="col-md-7" style="padding-left: 0px;">
                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="MW1"></asp:Label>
                <%--<label runat="server" class="control-label" id="MW"></label>--%>
            </div>
        </div>
        <div class="col-md-6" style="padding-left: 0px;">
            <div class="col-md-3" style="padding-left: 0px;">
                <label class="control-label">Score:</label>
            </div>
            <div class="col-md-9" style="padding-left: 0px;">
                <asp:Label runat="server" ClientIDMode="Static" ID="Score1" CssClass="control-label"></asp:Label>
                <%--<label runat="server" class="control-label" id="Score"></label>--%>
            </div>
        </div>
    </div>


    <br />
    <br />

    <div class="row">
        <div class="col-md-11">
            <div class="panel panel-danger leftBorder">

                <div class="panel-heading">

                    <label style="margin-left: 5px;">Scoring Components:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                </div>
                <div id="MS2" class="panel-body">



                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-3" style="padding-left: 0px;">
                            <div class="col-md-4" style="padding-left: 0px;">
                                <label class="control-label">MW Score:</label>
                            </div>
                            <div class="col-md-8" style="padding-left: 0px;">
                                <asp:Label runat="server" CssClass="control-label" ClientIDMode="Static" ID="MW_S1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="MW_S"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-3" style="padding-left: 5px;">
                            <div class="col-md-4" style="padding-left: 0px;">
                                <label class="control-label">PST Score:</label>
                            </div>
                            <div class="col-md-8" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" ID="PST1" CssClass="control-label"></asp:Label>
                                <%--<label runat="server" class="control-label" id="PST"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-3" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px;">
                                <label class="control-label">Insilico Score:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" ID="Insilico1" CssClass="control-label"></asp:Label>
                                <%--<label runat="server" class="control-label" id="Insilico"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-3" style="padding-left: 5px;">
                            <div class="col-md-8" style="padding-left: 0px;">
                                <label class="control-label">PTM Prediction Score:</label>
                            </div>
                            <div class="col-md-4" style="padding-left: 0px;">
                                <asp:Label runat="server" CssClass="control-label" ID="PTM1" ClientIDMode="Static"></asp:Label>
                                <%--<label runat="server" class="control-label" id="PTM"></label>--%>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-11">
            <div class="panel panel-danger leftBorder">

                <div class="panel-heading">

                    <label style="margin-left: 5px;">Engine Run Time:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                </div>
                <div id="MS1" class="panel-body">



                    <div class="col-md-12" style="padding-left: 0px;">

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-4" style="padding-left: 0px;">
                                <label class="control-label">Total:</label>
                            </div>
                            <div class="col-md-8" style="padding-left: 3px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="Total1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="Total"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 5px;">
                            <div class="col-md-4" style="padding-left: 0px;">
                                <label class="control-label">MW module:</label>
                            </div>
                            <div class="col-md-8" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="MWM1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="MWM"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 10px;">
                                <label class="control-label">PST Module:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="PSTM1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="PSTM"></label>--%>
                            </div>
                        </div>




                    </div>


                    <div class="col-md-12" style="padding-left: 0px;">





                        <div class="col-md-4" style="padding: 0px;">
                            <div class="col-md-4" style="padding: 0px;">
                                <label class="control-label">Insilico Module:</label>
                            </div>
                            <div class="col-md-8" style="padding: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="InsM1"></asp:Label>
                                <%--<label runat="server" class="control-label" style="padding: 0px;" id="InsM"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 5px;">
                            <div class="col-md-4" style="padding-left: 0px;">
                                <label class="control-label">PTM Module:</label>
                            </div>
                            <div class="col-md-8" style="padding-left: 0px;">
                                <asp:Label runat="server" ClientIDMode="Static" CssClass="control-label" ID="PTMM1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="PTMM"></label>--%>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 0px;">
                            <div class="col-md-5" style="padding-left: 0px; text-align: right;">
                                <label class="control-label">MW Tuner Module:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 0px;">
                                <asp:Label runat="server" CssClass="control-label" ClientIDMode="Static" ID="TunerM1"></asp:Label>
                                <%--<label runat="server" class="control-label" id="TunerM"></label>--%>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="col-md-11">
            <div class="panel panel-danger leftBorder">


                <div class="panel-heading">

                    <div class="radio" style="padding: 5px;">

                        <label>View Search Parameters:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios2" id="han" runat="server" value="1" onclick="document.getElementById('Param').style.display = 'block';" type="radio">Yes</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios2" id="na" runat="server" value="0" onclick="document.getElementById('Param').style.display = 'none';" checked="" type="radio">No</label>

                    </div>

                </div>
                <div id="Param" style="display: none" class="panel-body">



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
                            <div class="col-md-5" style="padding: 0px; width: auto;">
                                <label class="control-label">Filter DB by MW:</label>
                            </div>
                            <div class="col-md-7" style="padding-left: 32px; width: auto;">
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



    <asp:Table ID="aspTable1" ClientIDMode="Static" runat="server" CssClass="asptable table col-md-11 pad" Width="95%" HorizontalAlign="left" GridLines="None" BackColor="White">
    </asp:Table>


    <br />
    <br />
    <div style="text-align: center;" class="col-md-10 col-lg-10 col-sm-10 col-xs-10">
        <label id="ss" style="text-align: center;">*Colored block shows where Experimental Peptide Fragment matches Theoretical Peptide Fragment.
            <br />
        </label>

    </div>
</asp:Content>
