﻿using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
