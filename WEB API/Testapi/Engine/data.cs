﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Testapi.Engine
{
    public class data
    {
        //! data class
        /*!
         * This class is used in MW_Module class and is used for storing Protein ID, Sequence, MW and its theoretical fragments in CPersistant Dictionary
         * 
         */
        public data()  /*!< default constructor */
		{
            ID = "xx";
			Seq = "xx";
			MW = -1.1;
            Insilico = "xx";
            InsilicoR = "xx";
			
		}

        public data(string i, string s, double m, string d, string d1)    /*!< Parameterized constructor */
        {
            ID = i;
            Seq = s;
            MW = m;
            Insilico = d;
            InsilicoR = d1;

        }
        
        public string ID { get; set; }          /*!< ID: Member Variable */
        public string Insilico { get; set; }    /*!< Insilico: Member Variable */
        public string InsilicoR { get; set; }   /*!< InsilicoR: Member Variable */
        public string Seq { get; set; }         /*!< Seq: Member Variable */
        public double MW { get; set; }          /*!< MW: Member Variable */

    }
}