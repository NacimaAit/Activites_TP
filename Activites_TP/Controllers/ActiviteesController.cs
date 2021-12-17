using Activites_TP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Activites_TP.Controllers
{
    public class ActiviteesController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        public ActiviteesController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // prcedure getListeActivite
        // GET: ActiviteesController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Activite> listeActivites;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getListeActivite";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeActivites = new List<Activite>();
            while (reader.Read())
            {
                Activite A = new Activite();
                A.Id_activite = reader.GetInt32("Id_activite");
                A.Nom_activite = reader.GetString("Nom_activite");
                A.Duree = reader.GetInt32("Duree");
                A.Cout = reader.GetInt32("Cout");
                A.Nombre_vote = reader.GetInt32("Nombre_vote");
                listeActivites.Add(A);

            }
            conn.Close();
            return View(listeActivites);
           
        }

        // GET: ActiviteesController/Details/5
        public ActionResult Details(int Id)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Activite B = new Activite();
            //Activite B = null;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "detailActivite";
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            
            while (reader.Read())
                {
                    
                    B.Id_activite = reader.GetInt32("Id_activite");
                    B.Nom_activite = reader.GetString("Nom_activite");
                    B.Cout = reader.GetInt32("Cout");
                    B.Duree = reader.GetInt32("Duree");
                    B.Nombre_vote = reader.GetInt32("Nombre_vote");                      

                }
            conn.Close();
            return View(B);
                     
        }

        // GET: ActiviteesController/Create
        public ActionResult Create()
        {
            Activite b = new Activite(); 
            return View(b);
        }

        // POST: ActiviteesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activite B)
        {
            try
            {
                //Add insert 
                SqlConnection conn;
                SqlCommand cmd;
                connectionString = configuration.GetConnectionString("defaultConnection");
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddActivites";
               // cmd.Parameters.Add(new SqlParameter("@Id_activite", B.Id_Activite));
                cmd.Parameters.Add(new SqlParameter("@Nom_activite", B.Nom_activite));
                cmd.Parameters.Add(new SqlParameter("@Duree", B.Duree));
                cmd.Parameters.Add(new SqlParameter("@Cout", B.Cout));
                cmd.Parameters.Add(new SqlParameter("@Nombre_vote", B.Nombre_vote));
                
                conn.Open();
                int rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
                return View();
                
            }

        }

        // GET: ActiviteesController/Edit/5
        public ActionResult Edit(int Id)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Activite B = new Activite();
            //Activite B = null;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EditGetActivite";
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                B.Id_activite = reader.GetInt32("Id_activite");
                B.Nom_activite = reader.GetString("Nom_activite");
                B.Cout = reader.GetInt32("Cout");
                B.Duree = reader.GetInt32("Duree");
                B.Nombre_vote = reader.GetInt32("Nombre_vote");

            }
            //Activite Edition = B.Find(p => p.Id == Id);


            conn.Close();
            return View(B);
        }

        //// POST: ActiviteesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit( Activite B)
        //{
        //    try
        //    {
        //    //    //todo : Add insert logic here
        //    //    SqlConnection conn;
        //    //    SqlCommand cmd;

        //    //    connectionString = configuration.GetConnectionString("defaultConnection");
        //    //    conn = new SqlConnection(connectionString);
        //    //    cmd = new SqlCommand();
        //    //    cmd.CommandType = CommandType.StoredProcedure;
        //    //    cmd.CommandText = "EditPostActivite";
        //    //    cmd.Parameters.Add(new SqlParameter("@Id", B.Id_activite));
        //    //    cmd.Parameters.Add(new SqlParameter("@Nom_activite", B.Nom_activite));
        //    //    cmd.Parameters.Add(new SqlParameter("@Duree", B.Duree));
        //    //    cmd.Parameters.Add(new SqlParameter("@Cout", B.Cout));
        //    //    cmd.Parameters.Add(new SqlParameter("@Nombre_vote", B.Nombre_vote));
        //    //    cmd.Connection = conn;

        //    //    var old = B.Find(p => p.Id == Edition.Id);
        //    //    B.Remove(old);
        //    //    B.Add(Edition);
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //catch
        //    //{
        //    //    return View();
        //    //}
        //}

        // GET: ActiviteesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActiviteesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
