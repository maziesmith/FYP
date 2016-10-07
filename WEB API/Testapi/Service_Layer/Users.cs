using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Repository;
using Testapi.Models;

namespace Testapi.Service_Layer
{
    public class Users
    {

       public string newUser(string UName, string Name, string Email, string R_Pass)
        {
            DBConnect abc = new DBConnect();
            Guid g = Guid.NewGuid();

            return abc.Registeration(UName, R_Pass, Name, Email, g.ToString());

        }

       public string Login(string id, string pass, string g)
       {

           DBConnect abc = new DBConnect();
          


           return abc.login(id.ToString(), pass.ToString(), g);
       }



       public bool activate(string email)
       {
           DBConnect abc = new DBConnect();
           return abc.activate(email);


       }

       public bool SessionCheck(string id, string g)
       {

           DBConnect abc = new DBConnect();



           return abc.Session_validator(id,g);
       }


       public bool Logout(string id, string g)
       {


           DBConnect db = new DBConnect();

          
           return db.logout(id, g);

       }


       public bool UpdateInfo(string ID, string newName, string newEmail)
       {

           DBConnect db = new DBConnect();

           return db.UpdateInfo(newEmail, ID, newName);
       }


       public bool UpdatePassword(string ID, string pwd)
       {

           DBConnect db = new DBConnect();

           return db.UpdatePassword(pwd, ID);

       }


       public user_details retieve_user(string userid)
       {

           DBConnect db = new DBConnect();

           return db.Get_user(userid);

       }


       public List<searchlist> retrieve_searches(string userid)
       {
           DBConnect db = new DBConnect();

           return db.retrieve_searches_db(userid);

       }


       public searchview retrieve_searchview(string userid)
       {
           DBConnect db = new DBConnect();

           return db.retrieve_searchview_db(userid);

       }


    }
}