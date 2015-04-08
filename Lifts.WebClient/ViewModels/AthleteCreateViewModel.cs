using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class AthleteCreateViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        

        public IEnumerable<RosterViewModel> Rosters { get; private set; }

        public AthleteCreateViewModel()
        {
            
        }

        public AthleteCreateViewModel(IEnumerable<RosterViewModel> rosters)
        {
            Rosters = rosters;

        }

        public int Weight { get; set; }

        public int Height { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}