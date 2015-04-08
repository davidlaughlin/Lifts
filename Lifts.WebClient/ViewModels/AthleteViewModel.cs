using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class AthleteViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string AthleteLink { get; set; }

        public AthleteViewModel(int id, string firstName, string lastName, DateTime dateOfBirth, int height, int weight)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Height = height;
            Weight = weight;
            AthleteLink = "/Athlete/Skills?athleteId=" + id;
        }
    }
}