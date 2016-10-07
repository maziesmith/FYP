using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testapi.Service_Layer;
using Testapi.Models;///remove me !!
using System.Threading;

namespace Testapi.Controllers
{
    public class UsersController : ApiController
    {
        Users abc = new Users();

        
        public string Get_registration(string UName, string Name, string Email, string R_Pass)
        {
            //Users abc = new Users();

            return abc.newUser(UName, Name, Email, R_Pass);


        }


       




        public string Get_Session(string id, string g)
        {

           
               if(abc.SessionCheck(id, g))
                   return "T";
               else
               {
                   return "F";
               }
        }


        public string Get_login(string id, string pass, string g)
        {
            return abc.Login(id, pass, g);

        }


        public bool Get_logout(string id, string g)
        {

           return abc.Logout(id,g);
          
        }

        //string ID, string newEmail, string newName
        public bool Get_UpdateInfo(string id, string pass, string g)
        {

            return abc.UpdateInfo(id, g, pass);
        }


        //string ID, string newPwd
        public bool Get_UpdatePassword(string id, string g)
        {
           return abc.UpdatePassword(id, g);

        }


        public bool Get_activate(string em)
         {

             return abc.activate(em);

         }


         public Class2 Get_Nothing()
         {
             Class2 xyz = new Class2();
             xyz.mass = 5;
             return xyz;

         }

        //string userid
         public user_details Get_User_information(string em)
         {
             user_details x = abc.retieve_user(em);
             x.R_Pass = "****";
             return x;

         }


         //string userid
         public List<searchlist> Get_my_searches(string em)
         {
            List<searchlist> answer=abc.retrieve_searches(em);
            return answer;

         }

        //string querrry id
         public searchview Get_viewsearch(string em)
         {
             searchview answer=abc.retrieve_searchview(em);
             return answer;

         }


    }
}
