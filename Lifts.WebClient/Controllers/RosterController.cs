﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lifts.Data;
using Lifts.Data.Repositories;
using Lifts.WebClient.ActionResults;
using Lifts.WebClient.ViewModels;

namespace Lifts.WebClient.Controllers
{
    public class RosterController : BaseController
    {
        private readonly IRosterRepository _rosterRepository;
        private readonly IAthleteRepository _athleteRepository;

        public RosterController(IRosterRepository rosterRepository, IAthleteRepository athleteRepository)
        {
            _rosterRepository = rosterRepository;
            _athleteRepository = athleteRepository;
        }

        // GET: Roster
        public ActionResult Index()
        {
            List<RosterlViewModel> rosterViewModels =new List<RosterlViewModel>();
            List<Roster> rosters = _rosterRepository.All().ToList();
            foreach (Roster roster in rosters)
            {
                rosterViewModels.Add(new RosterlViewModel(roster.Id, roster.Name, roster.RosterAthletes.Count()));
            }

            RosterListViewModel viewModel = new RosterListViewModel(rosterViewModels);

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Detail(int rosterId)
        {
            List<AthleteViewModel> athleteViewModels = new List<AthleteViewModel>();
            Roster roster = _rosterRepository.Find(each => each.Id == rosterId).FirstOrDefault();
            if (roster == null)
            {
                return new HttpNotFoundResult();
            }

            foreach (RosterAthlete athlete in roster.RosterAthletes)
            {
                athleteViewModels.Add(new AthleteViewModel(athlete.AthleteId, athlete.Athlete.FirstName, athlete.Athlete.LastName));
            }

            RosterDetailViewModel viewModel = new RosterDetailViewModel(athleteViewModels);

            if (Request.IsAjaxRequest())
            {
                return new JsonNetResult(viewModel);
            }

            return View(viewModel);
        }
    }
}