<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" EnableEventValidation="false" Inherits="WebApplication1.About" Async="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="width: 90%; height: 5%; text-align:center;">Protein Search Query </h3>
    <%--<br />--%>
    <hr />

    <div class="container ">
        <div class="row  ">
            <div class="col-md-9 col-md-offset-1">

                <%-- Search Title div 1 --%>
                <div class="row mar">
                    <label for="search_title" class="col-xs-5 col-md-2 control-label">Job Title:</label>
                    <div class="col-xs-7 col-md-10 pd-re">
                        <asp:TextBox runat="server" ID="search_title" PlaceHolder='Please write your search title.' Width="100%" TextMode="Search" CssClass="form-control pd-le pd-re"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" Font-Size="Small" ControlToValidate="search_title" CssClass="text-danger" Display="Dynamic" Font-Italic="true" ErrorMessage="*Search Title is required."></asp:RequiredFieldValidator>
                    </div>
                </div>

                <%-- Upload Data Div 2 --%>
                <div class="row mar">
                    <div class="col-md-2 col-xs-5" style="padding-right: 0px;">
                        <label class="control-label" for="File_Upload">Upload Data File(s):</label>
                    </div>
                    <div class="col-md-10 col-xs-7" style="padding-right: 19px; padding-left:9px;">
                        <asp:FileUpload ID="File_Upload" runat="server" AllowMultiple="true" Font-Size="small" Height="100%"  FileTypeRange="fasta,txt,peaklist" CssClass="form-control pd-le" />
                        <asp:RequiredFieldValidator runat="server" Font-Size="Small" ControlToValidate="File_Upload" CssClass="text-danger" Display="Dynamic" Font-Italic="true" ErrorMessage="*Please Upload File."></asp:RequiredFieldValidator>
                    </div>
                </div>


                <%--Protein MW and Database Div 3 --%>
                <div class="row mar">
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-6 col-xs-5">
                                <label class="control-label" for="pro_mass" style="padding-left: 5px;">Protein MW:</label>
                            </div>
                            <div class="col-md-6 col-xs-7">
                                <div class="input-group" style="padding-left: 9px; padding-right:5px;">
                                    <asp:TextBox runat="server" ID="pro_mass" PlaceHolder='Optional' TextMode="Search" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon" style="color:white; background-color:#AEA79F; font-weight:bold; margin:0px; padding-right:5px;" id="basic-addon2">Da</span>
                                </div>
                                <asp:CompareValidator ID="cmpmin" runat="server" Font-Size="Small" ControlToValidate="pro_mass" CssClass="text-danger" Operator="GreaterThanEqual" Display="Dynamic" Type="Double" Font-Italic="true" SetFocusOnError="true" ValueToCompare="0.0" ErrorMessage="*Value should be greater than or equal to 0."></asp:CompareValidator>

                            </div>

                        </div>
                    </div>
                    <%--  --%>
                    <div class="col-md-8">
                        <div class="row" style="padding-right: 5px;">
                            
                            <div class="col-md-3 col-xs-5">
                                <label class="control-label" style="padding-left: 35px;" for="database">Database(s):</label>
                            </div>
                            <div class="col-md-9 col-xs-7" style="padding-left:45px; ">

                                <select id="database" name="database" class="form-control" runat="server" onchange="populateSelect();">

                                    <option value="Uniprot">Swissprot</option>
                                    <option value="Viruses">-Viruses</option>
                                    <option value="Cellular">-Cellular Organisms</option>
                                    <option value="Archaea">----Archaea</option>
                                    <option value="Bacteria">----Bacteria</option>
                                    <option value="Eukaryota">----Eukaryote</option>
                                    <option value="Fungi">-------Fungi</option>
                                    <option value="Viridiplantae">-------Viridiplantae</option>
                                    <option value="Mammals">-------Mammals</option>
                                    <option value="Human">----------Human</option>
                                    <option value="Vertebrates">----------Jawless Vertebrates</option>
                                    <option value="Rodents">----------Rodents</option>
                                    

                                </select>
                            </div>
                        </div>
                    </div>
                </div>

                <%-- MS/MS Fragmentation --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-danger leftBorder">

                            <div class="panel-heading">

                                <label style="margin-left: 10px;">MS2(Tandem MS/MS):</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                            </div>
                            <div id="MS2" class="panel-body">
                                <div class="col-md-12 mar" style="padding-left: 0px; padding-top:3px; padding-bottom:0px;">

                                    <div class="col-md-4" style="padding: 0px;">
                                        <div class="col-md-6" style="padding: 0px;">
                                            <label class="control-label" style="padding-left: 5px;" for="peptide_tol">Peptide Tol:</label>
                                        </div>
                                        <div class=" col-md-6">
                                            <div class="input-group" style="padding: 0px;">
                                                <asp:TextBox ID="peptide_tol" runat="server" PlaceHolder='Range 0-1' CssClass="form-control"></asp:TextBox>
                                                <div class="input-group-btn" style="padding-right:1px;">
                                                    <button type="button" class="btn xx btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><b id='unit2'>Da</b><span class="caret"></span></button>
                                                    <ul class="dropdown-menu dropdown-menu-right">
                                                        <li onclick="$('#unit2').html('Da');"><a href="#">Da</a></li>
                                                        <li onclick="$('#unit2').html('mmu');"><a href="#">mmu</a></li>
                                                        <li onclick="$('#unit2').html('ppm');"><a href="#">ppm</a></li>
                                                        <li onclick="$('#unit2').html('%');"><a href="#">%</a></li>
                                                    </ul>
                                                </div>
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="peptide_tol" CssClass="text-danger" Display="Dynamic" ErrorMessage="*Peptide Tol is required."></asp:RequiredFieldValidator>--%>
                                                <%--<asp:CompareValidator ID="CompareValidator4" ControlToValidate="peptide_tol" CssClass="text-danger" Type="Double" Display="Dynamic" ErrorMessage="*Peptide Tol is a number." runat="server"></asp:CompareValidator>--%>
                                            </div>

                                        </div>
                                        <asp:RangeValidator ID="percentageRangeValidator" runat="server" Font-Italic="true" CssClass="text-danger" ControlToValidate="peptide_tol" Display="Dynamic" Font-Size="Small" ErrorMessage="*Value should be between 0 and 1." MaximumValue="1.00" MinimumValue="0.00" Type="Double"></asp:RangeValidator>

                                    </div>
                                    <div class="col-md-4" style="padding-left: 0px; padding-right:0px;">

                                        <div class="col-md-7 col-md-offset-1 col-xs-5" style="padding-left: 0px;">
                                            <label class="control-label" style="padding-left: 15px; text-align:right;" for="fragtype">Fragmentation Type:</label>
                                        </div>
                                        <div class="col-md-4 col-xs-7" style="padding: 0px;">
                                            <select id="fragtype" name="fragtype" class="form-control" runat="server" onchange="populateSelect();">
                                                <option selected value="*">--</option>
                                                <option value="ECD">ECD</option>
                                                <option value="ETD">ETD</option>
                                                <option value="CID">CID</option>
                                                <option value="EDD">EDD</option>
                                                <option value="BIRD">BIRD</option>
                                                <option value="HCD">HCD</option>
                                                <option value="SID">SID</option>
                                                <option value="IMD">IMD</option>
                                                <option value="NETD">NETD</option>
                                            </select>

                                        </div>
                                    </div>


                                    <div class="col-md-3 col-md-offset-1" style="padding-right: 0px;">
                                        <div id="handle" class="row" style="display: none; padding-right: 0px;">
                                            <div class="col-md-7 col-xs-5" style="text-align:left;">
                                                <label class="control-label" style="text-align:right;" id="Label7" for="HandleIons">Special Ions:</label>
                                            </div>
                                            <div class="col-md-5 col-xs-7" style="margin-left: 0px; padding-left: 0px; padding-right: 10px">
                                                <select id="HandleIons" class="form-control" onchange="asd();" runat="server">
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>







                <%-- MW Filter and Tuner Div 4 --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-danger leftBorder">
                            <div class="panel-heading">

                                <div class="radio" style="padding-left: 5px;">
                                    
                                    
                                        <label>Auto Tune Protein MW:</label>&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        
                                        <label>
                                            <input value="1" name="optionsRadios1" runat="server" id="optionsRadios3" onclick="tuner_enable();" type="radio">Yes</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input value="0" name="optionsRadios1" runat="server" id="optionsRadios4" checked="" onclick="tuner_disable();" type="radio">No</label>
                                         <label style="margin-left:17%;"></label>                               
                                    <%--<div style="margin-left:5%"></div>--%>
                                       <label> 
                                            <input name="filterDB" id="filterDB" runat="server"  style="padding-right: 0px;" value="1" onclick="MW_enable();" type="checkbox">
                                           &nbsp;&nbsp;Filter DB by Protein MW</label>
                                  
                                </div>
                            </div>
                            
                            <div class="panel-body" id="MMW" style="display: none">

                                <div id="MW_filter" class="col-md-12" style="padding-left: 0px; padding-right: 2px; padding-top:4px; padding-bottom:3px;">

                                    <div class="col-md-2 col-xs-5" style="padding-right: 0px; padding-left: 10px;">
                                        <label class="control-label" for="protein_tol">MW Filter Tol:</label>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="input-group" style="padding-right: 4px; padding-left:0px;">
                                            <asp:TextBox ID="protein_tol" runat="server" PlaceHolder='Range: 100&apos;s.' TextMode="Search" CssClass=" form-control"></asp:TextBox>

                                            <div class="input-group-btn" style="padding-right: 0px;">
                                                <button type="button" class="btn xx btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><b id='unit1'>Da</b><span class="caret"></span></button>
                                                <ul class="dropdown-menu dropdown-menu-right">
                                                    <li onclick="$('#unit1').html('Da');"><a href="#">Da</a></li>
                                                    <li onclick="$('#unit1').html('mmu');"><a href="#">mmu</a></li>
                                                    <li onclick="$('#unit1').html('ppm');"><a href="#">ppm</a></li>
                                                    <li onclick="$('#unit1').html('%');"><a href="#">%</a></li>
                                                </ul>
                                            </div>
                                            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="protein_tol" CssClass="text-danger" Display="Dynamic" ErrorMessage="*Protein MW Tol is required."></asp:RequiredFieldValidator>--%>
                                        </div>


                                    </div>
                                    <asp:CompareValidator ID="CompareValidator1" Font-Size="Small" ControlToValidate="protein_tol" Font-Italic="true" CssClass="text-danger" Type="Double" Display="Dynamic" ErrorMessage="*Protein MW Tolis a number.<br/>" runat="server"></asp:CompareValidator>

                                </div>
                            </div>

                        </div></div></div>
                   

                <%-- Denovo and Length Filter --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-danger leftBorder rightBorder">

                            <div class="panel-heading">

                                <div class="radio" style="padding: 5px;">

                                    <label>Filter Denovo Sequence Tags:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                                <label>
                                    <input name="optionsRadios2" id="optionsRadios5" runat="server" value="1" onclick="PST_enable();" type="radio">Yes</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios2" id="optionsRadios6" runat="server" value="0" onclick="PST_disable();" checked="" type="radio">No</label>

                                </div>

                            </div>
                            <div id="PST" class="panel-body" style="display: none; padding-left: 0px; padding-right: 0px;">

                                <div class="col-md-12" style="padding-left: 0px; padding-right: 0px; padding-top:4px;">


                                    <div class="col-md-12" style="padding-left: 0px;">
                                        <div class="col-md-4" style="padding-right: 0px;">
                                            <label class="control-label" style="padding-left: 0%;">
                                                <input type="checkbox" runat="server" style="padding-left: 0px;" id="length" value="1" onchange="length_enable();" />&nbsp;&nbsp;
                                               Filter by Tag Length?</label>
                                        </div>


                                        <div class="col-md-4 " style="padding-left: 0px;">
                                            <div class="col-md-7 col-md-offset-1" style="padding-left: 0px; text-align:left;">
                                                <label class="control-label" style="color: grey; padding-left:15px;" id="pst_min" for="PST_Length_min">Minimum:</label>
                                            </div>
                                            <div class="col-md-4" style="padding:0px; padding-left:5px;">
                                                <asp:DropDownList ID="PST_Length_min" runat="server" Width="110%" Enabled="false" ClientIDMode="static" CssClass="form-control">

                                                    <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                        <div class="col-md-3 col-md-offset-1" style="padding-right: 0px; padding-left:5px;">
                                            <div class="col-md-7" style="padding-left: 0px; padding-right: 0px; text-align:left;">
                                                <label class="control-label" style="color: grey;" id="pst_max" for="PST_Length_max">Maximum:</label>
                                            </div>
                                            <div class="col-md-5" style="padding-right: 0px; padding-left:0px;">
                                                <asp:DropDownList ID="PST_Length_max" runat="server" Width="100%" ClientIDMode="static" CssClass="form-control" Enabled="false">

                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="6">6</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:CompareValidator Operator="GreaterThan" Display="Dynamic" Font-Size="Small" ControlToValidate="PST_Length_max" Type="Integer" CssClass="text-danger" Font-Italic="true" ControlToCompare="PST_Length_min" runat="server" ErrorMessage="*Maximum Length should be greater than Minimum Length."></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>


                <%-- PTM Filter and Preictor --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-danger leftBorder rightBorder">

                            <div class="panel-heading">

                                <div class="radio" style="padding-left: 5px;">

                                    <label>Predict Post Translational Modifications:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios4" id="optionsRadios9" runat="server" value="1" onclick="PTM_enable();" type="radio">Yes</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios4" id="optionsRadios10" runat="server" value="0" checked="" onclick="PTM_disable()" type="radio">No</label>

                                </div>
                            </div>
                            <div id="PTM" class="panel-body" style="display: none;">
                                <div class="col-md-12 mar" style="padding-top:4px;">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-md-4 col-xs-5">
                                                    <label class="control-label" style="padding-left: 5px;" for="modifications_select">Modifications:</label>
                                                </div>
                                                <div class="col-md-8 col-xs-7" style="padding-left:13px;">
                                                    <asp:ListBox ID="modifications_select" CssClass="form-control" Rows="8" runat="server" ClientIDMode="Static" Font-Size="Small" SelectionMode="Multiple">
                                                        <asp:ListItem Value="14">Phosphorylation_Y</asp:ListItem>
                                                        <asp:ListItem Value="12">Phosphorylation_S</asp:ListItem>
                                                        <asp:ListItem Value="13">Phosphorylation_T</asp:ListItem>
                                                        <asp:ListItem Value="1">Acetylation_A</asp:ListItem>
                                                        <asp:ListItem Value="2">Acetylation_K</asp:ListItem>
                                                        <asp:ListItem Value="3">Acetylation_M</asp:ListItem>
                                                        <asp:ListItem Value="4">Acetylation_S</asp:ListItem>
                                                        <asp:ListItem Value="5">Amidation_F</asp:ListItem>
                                                        <asp:ListItem Value="6">Hydroxylation_p</asp:ListItem>
                                                        <asp:ListItem Value="7">Methylation_K</asp:ListItem>
                                                        <asp:ListItem Value="8">Methylation_R</asp:ListItem>
                                                        <asp:ListItem Value="10">O Linked Glycosylation_T</asp:ListItem>
                                                        <asp:ListItem Value="11">O Linked Glycosylation_S</asp:ListItem>
                                                        <asp:ListItem Value="9">N Linked Glycosylation_N</asp:ListItem>
                                                    </asp:ListBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-1" style="padding-left: 5%;">
                                            <div class="row mar">
                                                <%--<input type="button" id="add"   value="<span class='glyphicon glyphicon-arrow-right'></span>" class=" xx  btn btn-default " onclick="return add_mod()" />--%>
                                                <asp:LinkButton ID="Button10" runat="server" CausesValidation="false" OnClientClick="add_mod();mod_right(); return false" Text="<span class='glyphicon glyphicon-chevron-right'></span>" CssClass=" xx  btn btn-default " />
                                            </div>
                                            <div class="row mar">
                                                <asp:LinkButton ID="Button11" runat="server" CausesValidation="false" OnClientClick="remove_mod();mod_right(); return false" Text="<span class='glyphicon glyphicon-chevron-left'></span>" CssClass="btn  xx mar  btn-default " />
                                            </div>
                                            <div class="row mar">
                                                <asp:LinkButton ID="Button12" runat="server" CausesValidation="false" Text="<span class='glyphicon glyphicon-chevron-right'></span>" OnClientClick="fix_Add_Click();mod_right_fixi(); return false" CssClass="btn  xx  btn-default " />
                                            </div>
                                            <div class="row mar">
                                                <asp:LinkButton ID="Button13" runat="server" CausesValidation="false" Text="<span class='glyphicon glyphicon-chevron-left'></span>" OnClientClick="fix_Remove_Click();mod_right_fixi(); return false" CssClass="btn  xx  btn-default" />
                                            </div>

                                        </div>

                                        <div class="col-md-5">
                                            <div class="row" style="padding-bottom: 2px;">
                                                <div class="col-md-4 col-xs-5">
                                                    <label for="Variable_modifications" class="control-label">Variable Modification(s):</label>
                                                </div>
                                                <div class="col-md-8 col-xs-7" style="padding-right: 4%">
                                                    <asp:ListBox ID="Variable_modifications" runat="server" ClientIDMode="Static" Width="100%" Rows="4" CssClass="form-control" Font-Size="small" SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-top: 2px;">
                                                <div class="col-md-4 col-xs-5">
                                                    <label for="Fixed_modifications" class="control-label ">Fixed Modification(s):</label>
                                                </div>
                                                <div class="col-md-8 col-xs-7" style="padding-right: 4%">
                                                    <asp:ListBox ID="Fixed_modifications" runat="server" ClientIDMode="Static" Width="100%" Rows="4" CssClass="form-control" Font-Size="small" SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mar">
                                    <div class="col-md-6" style="padding-left: 0px; padding-top:0px;">
                                        <div class="row">
                                            <div class="col-md-4 col-xs-5">
                                                <label class="control-label" style="padding-left: 5px;" for="ptm_tol">PTM Tol:</label>

                                            </div>
                                            <div class="col-md-4 col-xs-7" style="padding-left: 10px; padding-right:15px;">
                                                <asp:TextBox ID="ptm_tol" TextMode="Search" runat="server" PlaceHolder='Range 0-1' CssClass="form-control"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ptm_tol" CssClass="text-danger" Display="Dynamic" ErrorMessage="*PTM Tol is required."></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <asp:CompareValidator ID="CompareValidator3" Font-Size="Small" ControlToValidate="ptm_tol" CssClass="text-danger" Type="Double" Display="Dynamic" Font-Italic="true" ErrorMessage="*PTM Tol is a number.<br/>" runat="server"></asp:CompareValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" Font-Size="Small" CssClass="text-danger" ControlToValidate="ptm_tol" Display="Dynamic" Font-Italic="true" ErrorMessage="*Value should be between 0 and 1." MaximumValue="1.00" MinimumValue="0.00" Type="Double"></asp:RangeValidator>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <%-- Score Weightage --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-danger leftBorder rightBorder">

                            <div class="panel-heading">

                                <div class="radio" style="padding-left: 5px;">

                                    <label>Customize Scoring Component Weights:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios6" id="optionsRadios11" runat="server" value="1" onclick="Final_score_enable();" type="radio">Yes</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>
                                    <input name="optionsRadios6" id="optionsRadios12" runat="server" value="0" checked="" onclick="Final_score_disable();" type="radio">No</label>

                                </div>

                            </div>
                            <div id="Final_score" class="panel-body" style="display: none;">
                                <div class="col-md-12 mar" style="padding: 0px; padding-top:4px;">
                                    <div class="col-md-4" style="padding: 0px;">
                                        <div class="col-md-5" style="padding-left: 0px;">
                                            <label class="control-label" style="padding-left: 10px;" for="MW_Wei">MW Score:</label>
                                        </div>
                                        <div class="col-md-7" style="padding-right: 11px; padding-left:32px;">
                                            <asp:TextBox runat="server" Placeholder='Range 0-1' ID="MW_Wei" TextMode="Search" CssClass="form-control"></asp:TextBox>

                                        </div>
                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="MW_Wei" CssClass="text-danger" Display="Dynamic" ErrorMessage="*MW Score Weightage is required."></asp:RequiredFieldValidator>--%>
                                        <asp:CompareValidator ID="CompareValidator8" Font-Size="Small" Font-Italic="true" ControlToValidate="MW_Wei" CssClass="text-danger" Type="Double" Display="Dynamic" ErrorMessage="*MW Score Weightage is a number.<br/>" runat="server"></asp:CompareValidator>
                                        <asp:RangeValidator ID="RangeValidator7" Font-Italic="true" Font-Size="Small" runat="server" CssClass="text-danger" ControlToValidate="MW_Wei" Display="Dynamic" ErrorMessage="*Value should be between 0 and 1." MaximumValue="1.00" MinimumValue="0.00" Type="Double"></asp:RangeValidator>
                                    </div>


                                    <div class="col-md-4 " style="padding-left: 0px;">
                                        <div class="col-md-7 col-md-offset-1" style="padding-left: 0px; text-align:left;">
                                            <label class="control-label" style="padding-left: 15px;" for="PST_Wei">PST Score:</label>
                                        </div>
                                        <div class="col-md-4" style="padding: 0px;">

                                            <asp:TextBox runat="server" Placeholder='Range 0-1' ID="PST_Wei" TextMode="Search" CssClass=" form-control"></asp:TextBox>

                                        </div>
                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="PST_Wei" CssClass="text-danger" Display="Dynamic" ErrorMessage="*PST Score Weightage is required."></asp:RequiredFieldValidator>--%>
                                        <asp:CompareValidator ID="CompareValidator9" Font-Italic="true" Font-Size="Small" ControlToValidate="PST_Wei" CssClass="text-danger" Type="Double" Display="Dynamic" ErrorMessage="*PST Score Weightage is a number.<br/>" runat="server"></asp:CompareValidator>
                                        <asp:RangeValidator ID="RangeValidator8" Font-Italic="true" Font-Size="Small" runat="server" CssClass="text-danger" ControlToValidate="PST_Wei" Display="Dynamic" ErrorMessage="*Value should be between 0 and 1." MaximumValue="1.00" MinimumValue="0.00" Type="Double"></asp:RangeValidator>
                                    </div>


                                    <div class="col-md-3 col-md-offset-1" style="padding: 0px;">
                                        <div class="col-md-7" style="padding: 0px; text-align:left;">
                                            <label for="Insilico_Wei" style="padding-left: 0px;" class=" control-label">Insilico Score:</label>
                                        </div>
                                        <div class="col-md-5" style="padding-right: 4px; padding-left:0px;">
                                            <asp:TextBox runat="server" ID="Insilico_Wei" Placeholder='Range 0-1' TextMode="Search" CssClass=" form-control"></asp:TextBox>

                                        </div>
                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="Insilico_Wei" CssClass="text-danger" Display="Dynamic" ErrorMessage="*Insilico Score Weightage is required."></asp:RequiredFieldValidator>--%>
                                        <asp:CompareValidator ID="CompareValidator10" ControlToValidate="Insilico_Wei" Font-Size="Small" Font-Italic="true" CssClass="text-danger" Type="Double" Display="Dynamic" ErrorMessage="*Insilico Score Weightage is a number.<br/>" runat="server"></asp:CompareValidator>
                                        <asp:RangeValidator ID="RangeValidator9" runat="server" CssClass="text-danger" Font-Size="Small" Font-Italic="true" ControlToValidate="Insilico_Wei" Display="Dynamic" ErrorMessage="*Value should be between 0 and 1." MaximumValue="1.00" MinimumValue="0.00" Type="Double"></asp:RangeValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                

                <%-- Output format and No of Output Proteins --%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-danger leftBorder">

                            <div class="panel-heading">

                                <label style="margin-left: 10px;">Output Format:</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                            </div>
                            <div id="Output" class="panel-body">

                                <div class="col-md-12" style="padding: 0px; padding-top:4px; padding-bottom:3px;">

                                    
                                    <div class="col-md-4">
                                        <div class="row">
                                            <div class="col-md-5 col-xs-5">
                                                <label class="control-label" for="No_of_outputs"># of Outputs:</label>
                                            </div>
                                            <div class="col-md-7 col-xs-7" style="padding-right: 15px; padding-left:32px;">
                                                <asp:TextBox ID="No_of_outputs" TextMode="Search" runat="server" Placeholder='# of Proteins.' CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" Font-Italic="true" ControlToValidate="No_of_outputs" CssClass="text-danger" Display="Dynamic" Font-Size="Small" ErrorMessage="*No of Outputs is required.<br/>"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Font-Italic="true" Display="Dynamic" ControlToValidate="No_of_outputs" CssClass="text-danger" runat="server" Font-Size="Small" ErrorMessage="*No of Outputs should be greater than zero." ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>


                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                <asp:HiddenField runat="server" ID="ss" ClientIDMode="Static" Value="" />
                <asp:HiddenField runat="server" ID="vari" ClientIDMode="Static" Value="" />
                <asp:HiddenField runat="server" ID="fixi" ClientIDMode="Static" Value="" />

                <%-- Buttons --%>
                <div class="row mar" style="align-items: center; text-align: center; align-content: center;">




                    <asp:Button ID="Reset_Button" runat="server" CssClass="btn btn-default" Text="Reset Form" CausesValidation="false" OnClick="Reset_Button_Click" />

                    <asp:Button runat="server" ID="trigger" ClientIDMode="Static" OnClick="load_def" CssClass="btn btn-info" Font-Size="small" CausesValidation="false" Text="Load Default Parameters"></asp:Button>
                    <asp:Button runat="server" Text="Start Search" CssClass="btn btn-primary" ID="Button2" OnClick="Button2_Click" CausesValidation="true" />

                </div>

                <asp:Label ID="stat" runat="server" Text=""></asp:Label>


                <%--col-md-8 --%>
            </div>
            <%-- row --%>
        </div>
        <%-- conatiner --%>
    </div>
</asp:Content>
