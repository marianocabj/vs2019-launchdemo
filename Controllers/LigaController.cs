using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VS2019LaunchDemoFinale.Bussiness;
using VS2019LaunchDemoFinale.Bussiness.Interfaces;
using VS2019LaunchDemoFinale.Models;

namespace VS2019LaunchDemoFinale.Controllers
{
	public class LigaController : Controller
	{
		private readonly ILigaNegocio _ligaNegocio;

		public LigaController(ILigaNegocio ligaNegocio)
		{
			_ligaNegocio = ligaNegocio;
		}

		// GET: Liga
		public ActionResult Index()
		{
			Liga liga = _ligaNegocio.GetLiga();
			return View(liga);
		}

		// GET: Liga/Details/5
		[Route("Liga/Details/{key}")]
		public ActionResult Details(string key)
		{
			if (key == null)
			{
				return NotFound();
			}
			Club club = _ligaNegocio.GetClub((string)key);
			if (club == null)
			{
				return NotFound();
			}
			return View(club);
		}

		// GET: Liga/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Liga/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind("Key,Name,Code")] Club club)
		{
			if (ModelState.IsValid)
			{
				_ligaNegocio.CrearClub(club);

				return RedirectToAction(nameof(Index));
			}
			return View(club);
		}

		// GET: Liga/Edit/5
		[Route("Liga/Edit/{key}")]
		public ActionResult Edit(string key)
		{
			if (key == null)
			{
				return NotFound();
			}

			//CODE CLEANUP
			string peter = "Mr Stark I don't feel so good :(";

			Club club = _ligaNegocio.GetClub((string)key);


			//Tools menu > Options > Text Editor > C# > Code Style > General
			if (club == null)
			{
				return NotFound();
			}
			return View(club);
		}

		// POST: Liga/Edit/5
		[Route("Liga/Edit/{key}")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(string key, [Bind("Key,Name,Code")] Club club)
		{
			if (key != club.Key)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{

				try
				{
					// TODO: Add update logic here
					_ligaNegocio.ActualizarClub(club);


					return RedirectToAction(nameof(Index));
				}
				catch
				{
					return View(club);
				}
			}
			return View(club);

		}

		// GET: Liga/Edit/5
		public ActionResult EditName()
		{
			Liga liga = _ligaNegocio.GetLiga();
			if (liga == null)
			{
				return NotFound();
			}
			return View(liga);
		}

		// POST: Liga/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditName([Bind("Name")] Liga liga)
		{
			if (liga.Name == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{

				try
				{
					// TODO: Add update logic here
					_ligaNegocio.ActualizarNombreLiga(liga.Name);


					return RedirectToAction(nameof(Index));
				}
				catch
				{
					return View(liga);
				}
			}
			return View(liga);

		}

		// GET: Liga/Delete/5
		[Route("Liga/Delete/{key}")]
		public ActionResult Delete(string key)
		{
			//key delete
			if (key == null)
			{
				return NotFound();
			}

			Club club = _ligaNegocio.GetClub(key);

			if (club == null)
			{
				return NotFound();
			}

			return View(club);
		}

		// POST: Liga/Delete/5
		[Route("Liga/Delete/{key}")]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string key)
		{
			try
			{
				// TODO: Add delete logic here
				Club club = _ligaNegocio.GetClub(key);

				_ligaNegocio.EliminarClub(club);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}