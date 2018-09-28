using JeuDontOnEstLeHeros.Core.DataLayers;
using JeuDontOnEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeuDontOnEstLeHeros.Web.UI.Controllers
{
    public class HomeController : Controller
    { 

        private EspeceDataLayer eLayer = new EspeceDataLayer();
        private AvatarDataLayer aLayer = new AvatarDataLayer();

        private List<SelectListItem> AvailableSpecies()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            List<Espece> especes = eLayer.GetAll();
            foreach (var item in especes)
            {
                myList.Add(new SelectListItem { Text = item.Nom, Value = item.Id.ToString() });
            }
            return myList;
        }

        public ActionResult CreateAvatar()
        {
            ViewBag.Options = this.AvailableSpecies();
            Avatar emptyAvatar = new Avatar();

            return View(emptyAvatar);
        }

        [HttpPost]
        public ActionResult CreateAvatar(Avatar avatar)
        {
            ViewBag.Options = this.AvailableSpecies();
            aLayer.Save(avatar);
            Session["Avatar"] = avatar;
            return RedirectToRoute(new { Controller = "Paragraphe", Action = "One", id = "1" });
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SelectAvatar()
        {
            return View(new SelectId { Id = 0 });
        }

        [HttpPost]
        public ActionResult SelectAvatar(SelectId select)
        {
            try
            {
                Avatar avatar = aLayer.GetOne(select.Id);
                Session["Avatar"] = avatar;
                return RedirectToRoute(new { Controller = "Paragraphe", Action = "One", id = "1" });

            }
            catch(InvalidOperationException ex)
            {
                Session["errMessage"] = "Le numéro que vous avez choisi ne se trouve pas dans la base de données.";
                return RedirectToAction("Error");
            }
            catch(Exception ex)
            {
                Session["errMessage"] = ex.Message;
                return RedirectToAction("Error");
            }

        }

    }
}