using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class RosterDetailViewModel
    {
        public IEnumerable<AthleteViewModel> AllAthletes { get; private set; }

        public RosterDetailViewModel(IEnumerable<AthleteViewModel> athletes)
        {
            AllAthletes = athletes;
        }
    }
}