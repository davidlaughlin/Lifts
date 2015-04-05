using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lifts.WebClient.ViewModels
{
    public class RosterlViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Enrollment { get; set; }
        public string RosterLink { get; set; }

        public RosterlViewModel(int id, string name, int enrollment)
        {
            Id = id;
            Name = name;
            Enrollment = enrollment;
            RosterLink = "/Roster/Detail?rosterId=" + id;
        }
    }
}