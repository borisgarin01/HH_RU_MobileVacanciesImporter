using MvvmHelpers;
using SQLite;

namespace HhRuMobileParser.Models.DTOs
{
    [Table("Vacancies")]
    public class Vacancy
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string Address { get; set; }
        public string Responsibility { get; set; }
        public string Requirement { get; set; }
        public string VacancyURL { get; set; }
        public string CompanyURL { get; set; }
        public string CompanyName { get; set; }
    }
}
