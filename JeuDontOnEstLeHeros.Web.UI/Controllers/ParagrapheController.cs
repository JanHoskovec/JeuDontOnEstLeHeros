using JeuDontOnEstLeHeros.Core.DataLayers;
using JeuDontOnEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeuDontOnEstLeHeros.Web.UI.Controllers
{
    public class ParagrapheController : Controller
    {
        private ParagrapheDataLayer pLayer = new ParagrapheDataLayer();
        private QuestionDataLayer qLayer = new QuestionDataLayer();

        // GET: Paragraphe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult One(int id)
        {
            Paragraphe paragraphe = pLayer.GetOne(id);
            Question question = pLayer.GetQuestion(paragraphe);
            ViewBag.Question = question;
            ViewBag.Reponses = qLayer.GetReponses(question);
            return View(paragraphe);
        }
    }
}