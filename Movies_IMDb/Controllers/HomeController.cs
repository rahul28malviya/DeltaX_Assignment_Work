using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies_IMDb.Models;

namespace Movies_IMDb.Controllers
{
    public class HomeController : Controller
    {
        DataAccessLayer.dbHelper db = new DataAccessLayer.dbHelper();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditMovie()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AddNewMovi()
        {
            // ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Movie()
        {
            return View();
        }
        public JsonResult AddMovie(Movie addMovie)
        {
            if (addMovie.Poster == null)
            {
                return Json("Movie Poster is required", JsonRequestBehavior.AllowGet);
            }
            addMovie.Poster = addMovie.Poster.Replace("data:image/jpeg;base64,", "");
            byte[] bytes = Convert.FromBase64String(addMovie.Poster);
            string imgName = addMovie.MovieName.Replace(" ", "") + ".jpeg";

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (Bitmap bm2 = new Bitmap(ms))
                {

                    bm2.Save("c:\\Upload\\" + imgName,
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }

            addMovie.Poster = imgName;


            string jsonResult = string.Empty;

            if (string.IsNullOrEmpty(addMovie.MovieName))
                return Json("Movie Name is required", JsonRequestBehavior.AllowGet);

            if (string.IsNullOrEmpty(addMovie.Plot))
                return Json("Movie Plot is required", JsonRequestBehavior.AllowGet);

            if (addMovie.DateOfRelease == DateTime.MinValue)
                return Json("Date of Release is required", JsonRequestBehavior.AllowGet);

            if (addMovie.ProducerId <= 0)
                return Json("Please Select Producer", JsonRequestBehavior.AllowGet);

            if (addMovie.ActorId == null)
                return Json("Please Select Actor", JsonRequestBehavior.AllowGet);

            try
            {
                db.AddNewMovie(addMovie);
                jsonResult = "Inserted";
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                jsonResult = "Failed";
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditMovies(Movie editMovie)
        {
            string jsonResult = string.Empty;

            if (editMovie.MovieId <= 0)
                return Json("Please Select Movie Id", JsonRequestBehavior.AllowGet);

            if (string.IsNullOrEmpty(editMovie.Plot))
                return Json("Please Select Movie Plot", JsonRequestBehavior.AllowGet);
            try
            {
                db.EditMovieDetail(editMovie);
                jsonResult = "Updated";
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                jsonResult = "Failed";
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PoluateMovies()
        {
            try
            {
                DataSet ds = db.GetRecord("SelectMovies");
                List<Movie> MoviesList = new List<Movie>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    MoviesList.Add(new Movie
                    {
                        MovieId = Convert.ToInt32(dr["MovieId"]),
                        MovieName = dr["MovieName"].ToString(),
                        YearOfRelease = Convert.ToDateTime(dr["DateOfRelease"]).Year,
                        Plot = dr["Plot"].ToString(),
                        Poster = "c:\\Upload\\" + dr["Poster"].ToString()
                    });
                }
                return Json(MoviesList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult AddProducer(Producer producer)
        {
            string jsonResult = string.Empty;
            try
            {
                db.AddNewProducer(producer);
                jsonResult = "Inserted";
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                jsonResult = "Failed";
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddActor(Actor actor)
        {
            string jsonResult = string.Empty;
            try
            {
                db.AddNewActor(actor);
                jsonResult = "Inserted";
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                jsonResult = "Failed";
            }
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProducers()
        {
            try
            {
                DataSet ds = db.GetRecord("SelectProducers");
                List<Producer> ProducerList = new List<Producer>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ProducerList.Add(new Producer
                    {
                        ProducerId = Convert.ToInt32(dr["ProducerId"]),
                        ProducerName = dr["ProducerName"].ToString()
                    });
                }
                return Json(ProducerList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public JsonResult GetActors()
        {
            try
            {
                DataSet ds = db.GetRecord("SelectActors");
                List<Actor> ActorList = new List<Actor>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ActorList.Add(new Actor
                    {
                        ActorId = Convert.ToInt32(dr["ActorId"]),
                        ActorName = dr["ActorName"].ToString()
                    });
                }
                return Json(ActorList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}