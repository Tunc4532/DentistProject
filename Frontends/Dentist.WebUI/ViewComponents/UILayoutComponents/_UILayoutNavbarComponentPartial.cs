﻿using Microsoft.AspNetCore.Mvc;

namespace Dentist.WebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
