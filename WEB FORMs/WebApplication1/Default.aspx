<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" Async="true" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="width: 100%; height: 5%; text-align: center;">Perceptron: A Top Down High Performance Protein Search Engine</h3>
    <hr />
   
    <div class="Container">

        <div id="sss" class="col-md-12">
            <div>

                <label style="margin-left: 5px; font-size: medium; font-family: Arial; font-weight: normal; text-align: justify; padding-right:20px;" class="control-label">
                    Proteins play a central role in cellular metabolic processes and proteomic anomalies can give rise to a wide range of disorders such as cancer and diabetes. 
                        The development in proteomics has facilitated accurate protein identification creating avenues for improved disease prevention and diagnoses. 
                        Proteomics is a multifaceted and ever-expanding domain of biology and relishes the limelight as it is an emerging interdisciplinary area of research. 
                        “Bottom-up” proteome analysis incorporates peptides constituting a protein while “top-down” proteomics directly analyzes intact proteins thereby providing
                        accurate intact protein molecular weight, high sequence coverage and an enhanced prediction of post-translational modifications. 
                        <br />
                    <br />

                    In top-down proteomics (TDP), intact proteins are first ionized using soft ionization techniques followed by injection into the high resolution mass spectrometer (MS) 
                        for measurement of their molecular weights [14,15]. The ionized proteins experience guided deflections during flight in ratio to their individual molecular weights and hence 
                        the mathematical proportionality between ion deflection and mass can be used to compute the protein’s molecular weight. The initial measurement of a protein’s monoisotopic mass
                        (MS1) is followed by mass measurements of its fragmentation products (MS2) which gives us its unique spectrum. The analysis of MS1/MS2 data can assist in sequencing of proteins present in the sample. 
                        <br />
                    <br />



                    Perceptron is a top-down protein search engine implemented in the .NET framework as a web application. 
                        The application is deployed on a high performance GPU
                        server for high performance gains and NVIDIAs CUDA toolkit
                        is used for implementing the core search routines of the search engine.
                        Perceptron is open source, open architecture and freely available tool that provides an intuitively designed search environment for identifying proteins. 
                        The salient features are: (i) multiple data file format support including mzXML, MGF and flat text files,  (ii) a novel intact protein mass tuner 
                        employing an intensity weighted sliding window strategy, (iii) extracted de novo peptide sequence tags assistance in intensity, calculated error and frequency based scoring,
                         (iv) binding site prediction based on dbPTM dataset for identification of post-translational modifications, (v) intensity weighted in silico fragment comparisons, and
                        (vi) a customizable multifactorial scoring scheme.
                        Perceptron can be employed in development and benchmarking of novel top-down proteomics algorithms. Moreover, it can assist proteomics instructors for education and training purposes. 
                        Perceptron being next generation high resolution and high performance protein search engine will open great ventures in not only medicine but also in the fields of forensics, drug discovery, agriculture and petroleum.
                    
                </label>
                 <br />
    <hr />

            </div>

        </div>


    </div>
   
</asp:Content>
