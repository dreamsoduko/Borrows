using System;
using System.Collections.Generic;

namespace Borrows.Models
{
    public partial class Nmhmemp
    {
        public string EmpId { get; set; }
        public string EmpCode { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleEng { get; set; }
        public string FirstNameEng { get; set; }
        public string LastNameEng { get; set; }
        public string NickName { get; set; }
        public string WorkingStatus { get; set; }
        public string OrgUnitName { get; set; }
        public string OrgUnitCode { get; set; }
        public string LevelCode { get; set; }
        public string LevelTh { get; set; }
        public string LevelEn { get; set; }
        public string PositionName { get; set; }
        public byte[] ImageContent { get; set; }
        public string ChiefId { get; set; }
        public string OrgDepName { get; set; }
        public string CardId { get; set; }
        public string Aduser { get; set; }
        public string Adpass { get; set; }
        public string SkypeName { get; set; }
        public string SkypePass { get; set; }
        public string EmailUser { get; set; }
        public string EmailPass { get; set; }
        public string CitrixUser { get; set; }
        public string CitrixPass { get; set; }
        public string Tel { get; set; }
    }
}
