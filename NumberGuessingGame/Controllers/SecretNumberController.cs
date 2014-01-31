using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NumberGuessingGame.Models;
using NumberGuessingGame.ViewModels;
using MvcFlash.Core;
using MvcFlash.Core.Extensions;
using MvcFlash.Core.Messages;

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
            ViewModels.GuessViewModel gvm;

            gvm = new ViewModels.GuessViewModel();
            gvm.SecretNumber = new Models.SecretNumber();
            this.Session["gn"] = gvm;

            return View("Guess", gvm);
        }

         [HttpPost]
        public ActionResult Guess(ViewModels.GuessViewModel gvn)
        {

            

            if (this.Session["gn"] == null)
            {
                Flash.Instance.Push(new SimpleMessage() { Title = "Error", MessageType = "danger", Content = "Your session has timed out, please start from the beginning" });
                // redirect to Index()
                return View("Index");
            }

            var gn = this.Session["gn"] as ViewModels.GuessViewModel;

            if (ModelState.IsValid)
            {
                try
                {
                    var outcome = gn.SecretNumber.MakeGuess(gvn.Guess);

                    if (outcome == Outcome.OldGuess)
                    {
                        System.Diagnostics.Debug.WriteLine("Old guess!");
                        Flash.Instance.Warning("Old guess", "You have already guessed on number " + gvn.Guess);
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Flash.Instance.Push(new SimpleMessage() { Title = "Error", MessageType = "danger", Content = "The number must be in the range of 1-100" });
                }
            }
            else
            {
                foreach (var value in ModelState.Values) {
                    List<string> errors = new List<string>();
                    foreach (var error in value.Errors) {
                        errors.Add(error.ErrorMessage);
                    }
                    Flash.Instance.Push(new SimpleMessage() { Title = "Error", MessageType = "danger", Content = "Something went wrong", Data = errors });
                }
            }
                       
            return View("Guess", gn);
        }

    }
}
