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
                P.Id = reader.GetInt32("Id_participant");
                P.Nom_participant = reader.GetString("Nom_participant");
                P.Adresse_participant = reader.GetString("Adresse_participant");
                P.Id_activite = reader.GetInt32("Id_activite");

                listeParticipant.Add(P);
                
            }
            conn.Close();
            return View(listeParticipant);
        }

            // GET: ParticipantController/Details/5
            public ActionResult Details(int id)
            {
                return View();
            }

            // GET: ParticipantController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: ParticipantController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(IFormCollection collection)
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

            // GET: ParticipantController/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: ParticipantController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, IFormCollection collection)
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

            // GET: ParticipantController/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: ParticipantController/Delete/5
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
