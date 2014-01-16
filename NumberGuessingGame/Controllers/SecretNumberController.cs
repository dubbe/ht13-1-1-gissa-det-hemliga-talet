using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NumberGuessingGame.Models;
using NumberGuessingGame.ViewModels;

namespace NumberGuessingGame.Controllers
{
    public class SecretNumberController : Controller
    {
        //
        // GET: /SecretNumber/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Game()
        {
            if (this.Session["gn"] == null)
            {
               this.Session["gn"] = new Models.GuessedNumber();
            }

            var gn = this.Session["gn"];
            return View();
        }

         [HttpPost]
        public ActionResult Guess(ViewModels.GuessViewModel gvn)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Valid");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("InValid");
            }

            return View();
        }

    }
}
