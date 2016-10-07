using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Models;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text;
using Testapi.Engine;
using System.IO.Compression;

namespace Testapi.Repository
{

    public class DBConnect
    {
        private MySqlConnection connection;

        public static string TestSessionValue
        {

            get
            {
                object value = HttpContext.Current.Session["TestSessionValue"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["TestSessionValue"] = value;
            }
        }

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = "Data Source=localhost;" +
                "Initial Catalog=proteomics;" +
                "User id= abdulrehman;" +
                "Password=dbadmin1@BIRL;";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {

            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public string Registeration(string ID, string pwd, string name, string email, string g)
        {
            string s = "You are Registered!";

            string query = "INSERT INTO user VALUES('" + ID + "','" + name + "','" + email + "','" + pwd + "','" + 0 + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    //Execute command
                    cmd.ExecuteNonQuery();
                    string query3 = "INSERT INTO session VALUES('" + ID + "','" + g + "', now() , Null);";
                    MySqlCommand cmd2 = new MySqlCommand(query3, connection);
                    cmd2.ExecuteNonQuery();
                    Directory.CreateDirectory(@"C:\inetpub\wwwroot\API\Peaklists\" + ID);
                }
                catch (MySqlException e)
                {
                    s = e.Message;
                }
                //close connection
                this.CloseConnection();
            }
            return s;
        }


        //Update statements
        public bool UpdatePassword(string newPassword, string ID)
        {
            bool x;
            string query = "UPDATE user SET Password='" + newPassword + "' WHERE UserId='" + ID + "'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                    x = true;
                }
                catch
                {
                    x = false;


                }

                //close connection
                this.CloseConnection();
                return x;
            }

            else
                return false;
        }

        public bool UpdateInfo(string newEmail, string ID, string newName)
        {
            bool x;
            string query = "UPDATE user SET Email='" + newEmail + "', Name='" + newName + "' WHERE UserId='" + ID + "'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();
                    x = true;
                }
                catch
                {
                    x = false;


                }

                //close connection
                this.CloseConnection();
                return x;
            }

            else
                return false;
        }

        //Login
        public string login(string id, string pwd, string g)
        {
            string s = "login";

            string query = "select * from user where UserId='" + id + "'and Password='" + pwd + "' and Verified = 1;";

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        s = "Login Successfull!";
                        reader.Close();





                        //Guid g = Guid.NewGuid();

                        //HttpContext.Current.Session["name"] = g.ToString();

                        //System.Web.HttpContext.Current.Session = new object();
                        //System.Web.HttpContext.Current.Session.Add("guid",g);
                        // TestSessionValue = g.ToString();
                        string query3 = "INSERT INTO session VALUES('" + id + "','" + g + "', now() , Null);";
                        //string query2 = "update logindata set guid ='" + g + "'where id ='" + id + "';";
                        MySqlCommand cmd2 = new MySqlCommand(query3, connection);
                        cmd2.ExecuteNonQuery();
                    }
                    else
                        s = "Incorrect Username or Password!";
                    connection.Close();
                }
                catch (Exception e)
                {
                    s = e.Message;
                }
            }
            else
            {
                s = "connection failed!";
            }



            return s;
        }




        public string getEmail(string id)
        {
            string query = "select Email from user where UserId='" + id + "';";
            string s;
            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        s = reader[0].ToString();
                    }
                    else
                        s = "Incorrect Username or Password!";
                    connection.Close();
                }
                catch (Exception e)
                {
                    s = e.Message;
                }
            }
            else
            {
                s = "connection failed!";
            }

            return s;
        }



        //Decrypt Password
        private string Decrypt_Password(string encryptpassword)
        {
            string pwdstring = string.Empty;
            UTF8Encoding encode_pwd = new UTF8Encoding();
            Decoder Decode = encode_pwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpassword);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            pwdstring = new String(decoded_char);
            return pwdstring;
        }

        //Activate Account
        public bool activate(string email)
        {
            string s = "login";
            string mail = Decrypt_Password(email);
            string query = "select * from user where Email='" + mail + "';";

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        s = "Login Successfull!";



                        reader.Close();

                        query = "UPDATE user SET Verified=" + 1 + " where Email='" + mail + "';";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteReader();


                    }
                    else
                        s = "Incorrect Username or Password!";
                    connection.Close();
                }
                catch (Exception e)
                {
                    s = e.Message;
                }
            }
            else
            {
                s = "connection failed!";
            }


            if (s == "Login Successfull!")
                return true;
            else
                return false;
        }

        //Contains unmodified left Insilico masses
        public void Ileft(string PID, double MW, string Ions)
        {
            string query3 = "INSERT INTO leftions VALUES";
            query3 += "('" + PID + "'," + MW + ",'" + Ions + "');";
            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd2 = new MySqlCommand(query3, connection);
                cmd2.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Contains unmodified right Insilico masses
        public void Iright(string PID, double MW, string Ions)
        {
            string query3 = "INSERT INTO rightions VALUES";
            query3 += "('" + PID + "'," + MW + ",'" + Ions + "');";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd2 = new MySqlCommand(query3, connection);
                cmd2.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Store results
        public string store_results(Results res,string abcd, int file_id)
        {
            string s = "You are Registered!";

            Guid res_ID;
            string query;
            string query3;
            string Header_tag = "";
            if (this.OpenConnection() == true)
            {
                string query0 = "INSERT INTO timings VALUES('" + res.querryID + "','" + res.times.insilico_time + "','" + res.times.ptm_time + "','" + res.times.tuner_time + "','" + res.times.mw_filter_time + "','" + res.times.pst_time + "','" + res.times.total_time + "','"+abcd+"');";
                MySqlCommand cmd1 = new MySqlCommand(query0, connection);
                try
                {
                    cmd1.ExecuteNonQuery();

                    for (int i = 0; i < res.final_prot.Count; i++)
                    {
                        res_ID = Guid.NewGuid();
                        if (res.final_prot[i].header[0] == '>')
                        {
                            if (res.final_prot[i].header.Contains('|'))
                                Header_tag = res.final_prot[i].header.Substring(4, 6);
                            else
                                Header_tag = res.final_prot[i].header.Substring(1, res.final_prot[i].header.Length - 1);
                        }
                        else
                            Header_tag = res.final_prot[i].header;


                        query = "INSERT INTO results VALUES('" + res_ID.ToString() + "','" + res.querryID + "','" + Header_tag + "','" + res.final_prot[i].sequence + "'," + res.final_prot[i].est_score + "," + res.final_prot[i].insilico_score + ","
                           + res.final_prot[i].ptm_score + "," + res.final_prot[i].score + "," + res.final_prot[i].MW_score + "," + res.final_prot[i].MW + ","+  file_id + ")";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();



                        MySqlCommand cmd2;
                        string temp = "";
                        if (res.final_prot[i].ptm_particulars != null)
                        {

                            for (int j = 0; j < res.final_prot[i].ptm_particulars.Count; j++)
                            {
                                for (int kk = 0; kk < res.final_prot[i].ptm_particulars[j].AA.Count; kk++)
                                {
                                    temp = temp + res.final_prot[i].ptm_particulars[j].AA[kk];
                                }
                                query3 = "INSERT INTO ptm_sites VALUES('" + res_ID.ToString() + "'," + res.final_prot[i].ptm_particulars[j].i + "," + res.final_prot[i].ptm_particulars[j].score + ","
                                    + res.final_prot[i].ptm_particulars[j].mod_weight + ",'" + res.final_prot[i].ptm_particulars[j].mod_name + "','" + res.final_prot[i].ptm_particulars[j].site + "','" + temp + "');";
                                //string query2 = "update logindata set guid ='" + g + "'where id ='" + id + "';";
                                cmd2 = new MySqlCommand(query3, connection);
                                cmd2.ExecuteNonQuery();
                            }
                        }

                        //////////////////////////////////////
                        string Match_left = String.Join(",", res.final_prot[i].insilico_details.peaklist_mass_left.Select(x => x.ToString()).ToArray());

                        string Match_right = String.Join(",", res.final_prot[i].insilico_details.peaklist_mass_right.Select(x => x.ToString()).ToArray());



                        query3 = "INSERT INTO insilico_matches_left VALUES ('" + res_ID.ToString() + "','" + Match_left + "')";

                        cmd2 = new MySqlCommand(query3, connection);
                        cmd2.ExecuteNonQuery();


                        query3 = "INSERT INTO insilico_matches_right VALUES ('" + res_ID.ToString() + "','" + Match_right + "')";


                        cmd2 = new MySqlCommand(query3, connection);
                        cmd2.ExecuteNonQuery();




                    }
                     
                }
                catch (MySqlException e)
                {
                    s = e.Message;
                }
                this.CloseConnection();
            }





            return s;
        }

        //Validate Session
        public bool Session_validator(string id, string g)
        {
            bool s = false;

            string query = "select * from session where UserId='" + id + "'and SessionId='" + g + "';";

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        s = true;
                        reader.Close();
                    }
                    else
                        s = false;

                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    s = false;
                }

            }

            return s;
        }

        //Validate ID
        public bool valid_id(string id)
        {
            bool s = false;
            string query = "select * from user where UserId='" + id + "';";
            //Session["guid"] = Guid.NewGuid();
            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        s = false;
                    else
                        s = true;
                    connection.Close();
                }
                catch
                {
                    s = false;
                }
            }




            return s;
        }

        //Logout
        public bool logout(string ID, string guid)
        {
            bool success = true;
            if (this.OpenConnection() == true)
            {

                try
                {
                    string query = "update session set EndTime = now() where UserId = '" + ID + "' and SessionID='" + guid + "'";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    success = false;
                }

                return success;
            }
            else
                return false;


        }

        //Store Query parameters
        public int queryStore(QuerryParameters param)
        {
            bool success = false;

            if (this.OpenConnection() == true)
            {

                try
                {


                    string filename = string.Join("<", param.peakListFile);
                    success = true;
                    string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                    string query1 = "INSERT INTO query VALUES('" + param.queryid + "','" + param.userID + "','" + param.title + "','" + param.protDB + "','" + param.outputFormat + "','" + param.insilico_frag_type + "','" + param.filterDB + "','" + param.ptm_tolerance + "','"
             + param.MWTolUnit + "','" + param.MW_tolerance + "','" + param.hopThreshhold + "','" + param.minimum_est_length + "','" + param.maximum_est_length + "','" + param.GUI_mass + "','" + param.HandleIons + "'," + param.autotune + ",'" + filename  + "','" + param.fileType +
             "','" + param.hopTolUnit + "'," + param.MW_sweight + "," + param.PST_sweight + "," + param.Insilico_sweight + "," + param.NumberOfOutputs + "," + param.denovo_allow + "," + param.ptm_allow + ",'" + dateTime + "')";


                    MySqlCommand cmd = new MySqlCommand(query1, connection);
                    cmd.ExecuteNonQuery();

                    string query2;
                    for (int i = 0; i < param.ptm_code_var.Count; i++)
                    {
                        query2 = "INSERT INTO variable_modifications VALUES('" + param.queryid + "','" + param.ptm_code_var[i] + "')";
                        cmd = new MySqlCommand(query2, connection);
                        cmd.ExecuteNonQuery();
                    }


                    string query3;
                    for (int i = 0; i < param.ptm_code_fix.Count; i++)
                    {
                        query3 = "INSERT INTO fixed_modifications VALUES('" + param.queryid + "','" + param.ptm_code_fix[i] + "')";
                        cmd = new MySqlCommand(query3, connection);
                        cmd.ExecuteNonQuery();
                    }



                    string query6 = "INSERT INTO server_status VALUES('" + param.queryid + "','" + param.userID + "',0" + ")";
                    cmd = new MySqlCommand(query6, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string x = e.Message;
                    success = false;

                }

            }

            this.CloseConnection();

            if (success == false)
                return -1;
            else return 1;////

        }

        //Stores Server Status
        public List<Job> serverStatus()
        {
            List<Job> result = new List<Job>();
            Job temp = new Job();

            string query = "select * from server_status;";

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {


                        temp.qid = reader.GetValue(0).ToString();
                        temp.uid = reader.GetValue(1).ToString();
                        temp.progress = reader.GetValue(2).ToString();
                        result.Add(temp);
                    }

                    reader.Close();

                }

                catch { }
            }
            return result;

        }

        //Returns Progress
        public int Get_Progress(string qid)
        {
            string query = "select progress from server_status where qID='" + qid + "';";
            int progress = 0;

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        progress = Convert.ToInt32(reader.GetValue(0));
                        reader.Close();
                    }
                    else
                        progress = -1;

                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    progress = -1;
                }

            }

            return progress;

        }

        //Retrieve list of all searches by specific user
        public List<searchlist> retrieve_searches_db(string userid)
        {
            List<searchlist> results = new List<searchlist>();
            searchlist temp = new searchlist();
            string query = "SELECT QueryId, SearchTitle, date, PeakListFileAddress FROM proteomics.query where UserId='" + userid + "';";


            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //MySqlDataReader reader = cmd.ExecuteReader();

                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            temp = new searchlist();
                            temp.qid = Reader["QueryId"].ToString();
                            temp.title = Reader["SearchTitle"].ToString();
                            temp.date = Reader["date"].ToString();
                            temp.file = Reader["PeakListFileAddress"].ToString();
                            results.Add(temp);
                        }
                    }


                    connection.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }

            return results;

        }

        //Sets the progress of Querry
        public int Set_Progress(string qid, int p)
        {
            string query = "UPDATE server_status SET progress=" + p + " Where qID='" + qid + "';";
            int succcess = 1;

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        succcess = Convert.ToInt32(reader.GetValue(0));
                        reader.Close();
                    }
                    else
                        succcess = -1;


                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    succcess = -1;
                }

                connection.Close();

            }

            return succcess;

        }

        //Returns User Details
        public user_details Get_user(string uid)
        {
            user_details u_d = new user_details();

            string query = "select * from user WHERE UserId='" + uid + "';";

            if (this.OpenConnection() == true)
            {

                try
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        u_d.UName = reader.GetValue(0).ToString();
                        u_d.Name = reader.GetValue(1).ToString();
                        u_d.Email = reader.GetValue(2).ToString();
                        u_d.R_Pass = reader.GetValue(2).ToString();
                    }
                    else
                    {
                        u_d.Name = "not found";
                        u_d.Email = "not found";
                        u_d.R_Pass = "not found";
                    }





                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return u_d;
        }




        string Decompress(string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }




        //Returns Search History of specific query ie. search parameters and Results
        public searchview retrieve_searchview_db(string qid)
        {
            searchview result = new searchview();
            QuerryParameters qp = new QuerryParameters();
            Results r = new Results();
            string[] QIDArr = qid.Split('z');
            qid = QIDArr[0];
            int file_id = Convert.ToInt32(QIDArr[1]);

            string query1 = "SELECT * FROM proteomics.query where QueryId='" + qid + "';";
            string queryT = "SELECT * FROM proteomics.timings where querry_ID='" + qid + "';";

            if (this.OpenConnection() == true)
            {
                try
                {
                    using (MySqlTransaction trans = connection.BeginTransaction())
                    {


                        MySqlCommand cmd = new MySqlCommand(queryT, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            r.times.insilico_time = reader.GetValue(1).ToString();
                            r.times.ptm_time = reader.GetValue(2).ToString();
                            r.times.tuner_time = reader.GetValue(3).ToString();
                            r.times.mw_filter_time = reader.GetValue(4).ToString();
                            r.times.pst_time = reader.GetValue(5).ToString();
                            r.times.total_time = reader.GetValue(6).ToString();
                            r.times.file = reader.GetValue(7).ToString();

                        }
                        reader.Close();



                        cmd = new MySqlCommand(query1, connection);
                        reader = cmd.ExecuteReader();


                        if (reader.Read())
                        {
                            qp.queryid = reader.GetValue(0).ToString();
                            qp.userID = reader.GetValue(1).ToString();
                            qp.title = reader.GetValue(2).ToString();
                            qp.protDB = reader.GetValue(3).ToString();
                            qp.outputFormat = Convert.ToInt32(reader.GetValue(4));
                            qp.insilico_frag_type = reader.GetValue(5).ToString();
                            qp.filterDB = Convert.ToInt32(reader.GetValue(6));

                            qp.ptm_tolerance = Convert.ToDouble(reader.GetValue(7));
                            qp.MWTolUnit = reader.GetValue(8).ToString();
                            qp.MW_tolerance = Convert.ToDouble(reader.GetValue(9));
                            qp.hopThreshhold = Convert.ToDouble(reader.GetValue(10));

                            qp.minimum_est_length = Convert.ToInt32(reader.GetValue(11));
                            qp.maximum_est_length = Convert.ToInt32(reader.GetValue(12));
                            // public double pst_tolerance;
                            qp.GUI_mass = Convert.ToDouble(reader.GetValue(13));
                            qp.HandleIons = reader.GetValue(14).ToString();
                            qp.autotune = Convert.ToInt32(reader.GetValue(15));


                            qp.peakListFile = reader.GetValue(16).ToString().Split('<');
                            qp.fileType = reader.GetValue(17).ToString();
                            // public double peptideTol;

                            //added
                            qp.hopTolUnit = reader.GetValue(18).ToString();


                            qp.MW_sweight = Convert.ToDouble(reader.GetValue(19));
                            qp.PST_sweight = Convert.ToDouble(reader.GetValue(20));
                            qp.Insilico_sweight = Convert.ToDouble(reader.GetValue(21));

                            qp.NumberOfOutputs = Convert.ToInt32(reader.GetValue(22));
                            /////
                            qp.denovo_allow = Convert.ToInt32(reader.GetValue(23));
                            qp.ptm_allow = Convert.ToInt32(reader.GetValue(24));



                        }

                        reader.Close();
                        query1 = "SELECT fixed_mod FROM fixed_modifications where QuerryId='" + qid + "';";
                        cmd = new MySqlCommand(query1, connection);
                        using (reader = cmd.ExecuteReader())
                        {
                            qp.ptm_code_fix = new List<int>();
                            while (reader.Read())
                            {
                                qp.ptm_code_fix.Add(Convert.ToInt32(reader["fixed_mod"]));

                            }
                        }

                        reader.Close();
                        query1 = "SELECT variable_mod FROM variable_modifications where QuerryId='" + qid + "';";
                        cmd = new MySqlCommand(query1, connection);
                        using (reader = cmd.ExecuteReader())
                        {
                            qp.ptm_code_var = new List<int>();
                            while (reader.Read())
                            {
                                qp.ptm_code_var.Add(Convert.ToInt32(reader["variable_mod"]));

                            }
                        }
                        reader.Close();
                        // SELECT * FROM proteomics.results Where Querry_ID = 'fe29e39e-97ee-4f5e-9cab-4d414b5e902a' ORDER BY score DESC LIMIT 3;



                        string query2 = "SELECT * FROM results where Querry_ID='" + qid + "' AND file_ID = "+file_id + " ORDER BY score DESC LIMIT " + qp.NumberOfOutputs + ";";
                        cmd = new MySqlCommand(query2, connection);
                        r.querryID = qid;
                        r.final_prot = new List<proteins>();
                        proteins temp_prot = new proteins();
                        List<string> resid = new List<string>();

                        using (reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                temp_prot = new proteins();
                                resid.Add(reader.GetValue(0).ToString());
                                temp_prot.header = reader.GetValue(2).ToString();
                                temp_prot.sequence = reader.GetValue(3).ToString();
                                temp_prot.est_score = Convert.ToDouble(reader.GetValue(4));
                                temp_prot.insilico_score = Convert.ToDouble(reader.GetValue(5));
                                temp_prot.ptm_score = Convert.ToDouble(reader.GetValue(6));
                                temp_prot.score = Convert.ToDouble(reader.GetValue(7));
                                temp_prot.MW_score = Convert.ToDouble(reader.GetValue(8));
                                temp_prot.MW = Convert.ToDouble(reader.GetValue(9));

                                r.final_prot.Add(temp_prot);

                            }
                        }
                        reader.Close();




                        Sites temp_site = new Sites();
                        string tempaa;
                        for (int i = 0; i < resid.Count; i++)
                        {
                            query2 = "SELECT * FROM ptm_sites where result_id='" + resid[i] + "';";
                            cmd = new MySqlCommand(query2, connection);
                            using (reader = cmd.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    temp_site = new Sites();
                                    temp_site.i = Convert.ToInt32(reader.GetValue(1));
                                    temp_site.score = Convert.ToInt32(reader.GetValue(2));
                                    temp_site.mod_weight = Convert.ToInt32(reader.GetValue(3));
                                    temp_site.mod_name = reader.GetValue(4).ToString();
                                    temp_site.site = Convert.ToChar(reader.GetValue(5));
                                    tempaa = reader.GetValue(6).ToString();

                                    for (int j = 0; j < tempaa.Length; j++)
                                    {
                                        temp_site.AA.Add(tempaa[j]);
                                    }


                                    r.final_prot[i].ptm_particulars.Add(temp_site);



                                }
                            }

                        }
                        reader.Close();
                        ///////////



                        //temp_p.insilico_details.insilico_mass_left = dataPs[3].Split(',').Select(t => double.Parse(t)).ToList<double>();

                        string xx;
                        for (int i = 0; i < resid.Count; i++)
                        {

                            query2 = "SELECT matched_peak_left FROM insilico_matches_left where result_id='" + resid[i] + "';";



                            cmd = new MySqlCommand(query2, connection);
                            using (reader = cmd.ExecuteReader())
                            {


                                temp_site = new Sites();

                                if (reader.Read())
                                {
                                    xx = reader.GetValue(0).ToString();

                                    r.final_prot[i].insilico_details.peaklist_mass_left = xx.Split(',').Select(t => double.Parse(t)).ToList<double>();
                                }

                            }




                            query2 = "SELECT Ions FROM leftions where ProteinID='" + r.final_prot[i].header + "';";



                            cmd = new MySqlCommand(query2, connection);
                            using (reader = cmd.ExecuteReader())
                            {


                                temp_site = new Sites();

                                if (reader.Read())
                                {
                                    xx = reader.GetValue(0).ToString();
                                    xx = Decompress(xx);
                                    r.final_prot[i].insilico_details.insilico_mass_left = xx.Split(',').Select(t => double.Parse(t)).ToList<double>();
                                }



                            }



                        }
                        reader.Close();

                        //////////////////////////////////////////////////////////////





                        for (int i = 0; i < resid.Count; i++)
                        {

                            query2 = "SELECT matchedpeak_right FROM insilico_matches_right where result_id='" + resid[i] + "';";



                            cmd = new MySqlCommand(query2, connection);
                            using (reader = cmd.ExecuteReader())
                            {


                                temp_site = new Sites();

                                if (reader.Read())
                                {
                                    xx = reader.GetValue(0).ToString();

                                    r.final_prot[i].insilico_details.peaklist_mass_right = xx.Split(',').Select(t => double.Parse(t)).ToList<double>();
                                }

                            }




                            query2 = "SELECT Ions FROM rightions where ProteinID='" + r.final_prot[i].header + "';";



                            cmd = new MySqlCommand(query2, connection);
                            using (reader = cmd.ExecuteReader())
                            {


                                temp_site = new Sites();

                                if (reader.Read())
                                {
                                    xx = reader.GetValue(0).ToString();
                                    xx = Decompress(xx);
                                    r.final_prot[i].insilico_details.insilico_mass_right = xx.Split(',').Select(t => double.Parse(t)).ToList<double>();

                                }


                            }



                        }
                        reader.Close();

                        //////////////////////////////////////////////////////////////













                        //for (int i = 0; i < resid.Count; i++)
                        //{
                        //    query2 = "SELECT * FROM insilico_mass_right where result_id='" + resid[i] + "';";
                        //    cmd = new MySqlCommand(query2, connection);
                        //    using (reader = cmd.ExecuteReader())
                        //    {

                        //        while (reader.Read())
                        //        {
                        //            temp_site = new Sites();
                        //            r.final_prot[i].insilico_details.insilico_mass_right.Add(Convert.ToDouble(reader.GetValue(1)));
                        //            r.final_prot[i].insilico_details.peaklist_mass_right.Add(Convert.ToDouble(reader.GetValue(2)));


                        //        }
                        //    }

                        //}
                        //reader.Close();



                        ////////////
                        result.param = qp;
                        result.result = r;








                        trans.Commit();
                        connection.Close();
                    }
                }


                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

            }


            // result.result.final_prot = result.result.final_prot.OrderByDescending(o => o.score).ToList();
            return result;

        }
    }
}