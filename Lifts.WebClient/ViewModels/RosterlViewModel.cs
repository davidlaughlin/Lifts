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
        public string RosterViewLink { get; private set; }
        public string RosterSkillsLink { get; private set; }

        public RosterlViewModel(int id, string name, int enrollment)
        {
            Id = id;
            Name = name;
            Enrollment = enrollment;
            RosterViewLink = "/Roster/Detail?rosterId=" + id;
            RosterSkillsLink = "/Roster/Skills?rosterId=" + id;
        }
    }
}