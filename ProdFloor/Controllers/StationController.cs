﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProdFloor.Models;
using ProdFloor.Models.ViewModels;
using ProdFloor.Models.ViewModels.Stations;

namespace ProdFloor.Controllers
{
    [Authorize(Roles = "Admin,TechAdmin,ProductionAdmin")]
    public class StationController : Controller
    {
        private IItemRepository itemprepo;
        private ITestingRepository testingrepo;
        private ItemController itemController;
        private UserManager<AppUser> userManager;
        public int PageSize = 7;

        public StationController(ITestingRepository repo, 
            IItemRepository repo2,
            ItemController item,
            UserManager<AppUser> userMrg)
        {
            testingrepo = repo;
            itemprepo = repo2;
            itemController = item;
            userManager = userMrg;
        }

        public ViewResult Add()
        {
            return View("Edit", new Station());
        }

        public IActionResult List(StationListViewModel viewModel, int page = 1, int totalitemsfromlastsearch = 0)
        {
            if (viewModel.CleanFields) return RedirectToAction("List");
            IQueryable<Station> stations = testingrepo.Stations.Where(m => m.Label != "-").AsQueryable();

            if (viewModel.JobTypeID > 0) stations = stations.Where(m => m.JobTypeID == viewModel.JobTypeID);
            if (!string.IsNullOrEmpty(viewModel.Label)) stations = stations.Where(m => m.Label.Contains(viewModel.Label));

            viewModel.TotalItems = testingrepo.Stations.Count();

            int TotalItemsSearch = stations.Count();
            if (page == 1)
            {
                totalitemsfromlastsearch = TotalItemsSearch;
            }
            else if (TotalItemsSearch != totalitemsfromlastsearch)
            {
                totalitemsfromlastsearch = TotalItemsSearch;
                page = 1;
            }
            viewModel.Stations = new List<Station>();
            viewModel.Stations = stations.OrderBy(p => p.Label).Skip((page - 1) * 5).Take(5).ToList();
            viewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = 5,
                TotalItemsFromLastSearch = totalitemsfromlastsearch,
                TotalItems = stations.Count()
            };
            return View(viewModel);
        }

        public ViewResult Edit(int ID) =>
            View(testingrepo.Stations
                .FirstOrDefault(j => j.StationID == ID));

        [HttpPost]
        public IActionResult Edit(Station station)
        {
            if (ModelState.IsValid)
            {
                testingrepo.SaveStation(station);
                TempData["message"] = $"{station.Label} has been saved...{station.StationID}";
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(station);
            }
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            bool admin = GetCurrentUserRole("Admin").Result;

            if (!admin)
            {
                TempData["alert"] = $"alert-danger";
                TempData["message"] = $"You don't have permissions, contact to your admin";

                return RedirectToAction("List");
            }

            Station deletedStation = testingrepo.DeleteStation(ID);

            if (deletedStation != null)
            {
                TempData["message"] = $"{deletedStation.Label} was deleted";
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult SeedXML(string buttonImportXML)
        {
            string resp = buttonImportXML;
            itemController.ImportXML(HttpContext.RequestServices, resp);
            return RedirectToAction(nameof(List));
        }

        private async Task<bool> GetCurrentUserRole(string role)
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);

            bool isInRole = await userManager.IsInRoleAsync(user, role);

            return isInRole;
        }
    }
}