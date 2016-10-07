using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SQLite;

namespace Testapi.Engine
{
    public class Database
    {
        public static SQLiteConnection m_dbConnection;
        public static int x = 0;

        public static void CreateDatabse()
        {
            if (x == 0)
            {
                m_dbConnection = new SQLiteConnection("Data Source=:memory:;Version=3;");
                m_dbConnection.Open();

                string sql = @"CREATE TABLE IF NOT EXISTS
						    Database(ProteinID		    VARCHAR(12)				PRIMARY KEY		 NOT NULL,
									Sequence			VARCHAR(33000)	 NOT NULL,
									MW			        DECIMAL(10,5)	 NOT NULL,
                                    Insilico			VARCHAR(33000)	 NOT NULL
									);CREATE INDEX IDLookup ON Database(ProteinID,MW )";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                x++;
            }

        }

        public static void DelData()
        {



            string sql = @"Delete from Database";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

        }

        public static void InsertData(data data1)
        {

            //m_dbConnection.Open();
            string sql = @"INSERT INTO  Database (ProteinID, Sequence, MW,Insilico) VALUES ('" + data1.ID + "','" + data1.Seq + "'," + data1.MW + ",'" + data1.Insilico + "')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
           
            //m_dbConnection.Close();

        }

        public static void InsertData1(data data1)
        {

            //m_dbConnection.Open();
            string sql = @"INSERT INTO  Database (ProteinID, Sequence, MW,Insilico) VALUES ('" + data1.ID + "','" + data1.Seq + "'," + data1.MW + ",'" + data1.Insilico + "')";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            //m_dbConnection.Close();

        }




        public static List<data> GetData(double tol, double MolW)
        {
            List<data> dat = new List<data>();
            data data1 = new data();

            //  m_dbConnection.Open();
          // using( SQLiteTransaction ss = m_dbConnection.BeginTransaction())
           // {           

            string sql = @"SELECT ProteinID,Sequence,MW,Insilico FROM Database WHERE MW < " + (MolW + 50) + " AND MW > " + (MolW - tol) + " order by MW;";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data1 = new data();
                data1.ID = (string)reader["ProteinID"];
                data1.Seq = (string)reader["Sequence"];
                data1.MW = Convert.ToDouble(reader["MW"]);
                data1.Insilico = (string)reader["Insilico"];
                dat.Add(data1);
            }
        //   ss.Commit();
         //       } 
            //   m_dbConnection.Close();
            return dat;
        }

        public static int count()
        {
            int num = -1;
            //  m_dbConnection.Open();
            string sql = @"SELECT COUNT(*) FROM Database;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            var c = command.ExecuteScalar();
            if (c != null)
                num = Convert.ToInt32(c);
            //num = reader;
            //return num;



            return num;
        }

    }
}