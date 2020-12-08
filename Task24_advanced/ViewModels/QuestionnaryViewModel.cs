using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task24_advanced.ViewModels
{
    public class QuestionnaryViewModel
    {
        public QuestionnaryViewModel(string name, string surname, string telephone, string gender, string paper, string online)
        {
            this.Name = name;
            this.Surname = surname;
            this.Telephone = telephone;
            this.Gender = gender;
            this.Paper = paper;
            this.Online = online;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Gender { get; set; }
        public string Paper { get; set; }
        public string Online { get; set; }
    }
}