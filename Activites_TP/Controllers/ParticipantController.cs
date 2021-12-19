using Activites_TP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient; 

namespace Activites_TP.Controllers
{
    public class ParticipantController : Controller
    {
        private string connectionString;
        public IConfiguration configuration;

        public ParticipantController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // GET: ParticipantController
        public ActionResult Index()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            List<Participant> listeParticipant;

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getListeParticipant";
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();
            listeParticipant = new List<Participant>();
            while (reader.Read())
            {
                Participant P = new Participant();
                P.id = reader.GetInt32("Id_participant");
                P.nom_participant = reader.GetString("Nom_participant");
                P.adresse_participant = reader.GetString("Adresse_participant");
                P.id_activite = reader.GetInt32("Id_activite");

                listeParticipant.Add(P);
                
            }
            conn.Close();
            return View(listeParticipant);
        }

            // GET: ParticipantController/Details/5
            public ActionResult Details(int id)
            {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader reader;
            Participant D = new Participant();
           

            connectionString = configuration.GetConnectionString("defaultConnection");
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "detailParticipant";
            cmd.Parameters.Add(new SqlParameter("@Id", id));
            cmd.Connection = conn;

            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                D.id = reader.GetInt32("Id_participant");
                D.nom_participant = reader.GetString("Nom_participant");
                D.adresse_participant = reader.GetString("Adresse_participant");
                D.id_activite = reader.GetInt32("Id_activite");
               

            }
            conn.Close();
            return View(D);
        }

            // GET: ParticipantController/Create
            public ActionResult Create()
            {
            Participant p = new Participant();
                return View(p);
            }

            // POST: ParticipantController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Participant p)
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
                cmd.CommandText = "AddParticipant";
               
                cmd.Parameters.Add(new SqlParameter("@Param1", p.nom_participant));
                cmd.Parameters.Add(new SqlParameter("@Param2", p.adresse_participant));
                cmd.Parameters.Add(new SqlParameter("@Param3", p.id_activite));
                cmd.Connection = conn;

                conn.Open();
                int  rowCount = cmd.ExecuteNonQuery();
                conn.Close();
                return RedirectToAction(nameof(Index));
               
                }
                catch
                {
                    
                    return View();
                }
            }

    
    }
    }
