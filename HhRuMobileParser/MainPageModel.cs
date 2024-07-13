using Models.Http;
using Models.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HhRuMobileParser
{
    public sealed class MainPageModel : ObservableObject
    {
        private readonly VacanciesRequesterAndExtractorFromHttpResponse _vacanciesRequesterAndExtractorFromHttpResponse;

        public IAsyncCommand ImportVacanciesCommand { get; set; }

        public bool IsNotBusy { get; set; } = true;

        public MainPageModel(VacanciesRequesterAndExtractorFromHttpResponse vacanciesRequesterAndExtractorFromHttpResponse)
        {
            _vacanciesRequesterAndExtractorFromHttpResponse = vacanciesRequesterAndExtractorFromHttpResponse;
            ImportVacanciesCommand = new AsyncCommand(ImportVacancies);
        }

        public List<Item> Items { get; set; } = new();

        public async Task ImportVacancies()
        {
            IsNotBusy = false;
            OnPropertyChanged(nameof(IsNotBusy));
            var items = new List<Item>();
            Items = new List<Item>();
            OnPropertyChanged(nameof(Items));

            var csharpQueryUrlEncoded = HttpUtility.UrlEncode("C#");

            IEnumerable<Item> vacancies1;
            int page = 0;
            do
            {
                vacancies1 = await _vacanciesRequesterAndExtractorFromHttpResponse.GetVacanciesResponseObjectViaHttpQuery(csharpQueryUrlEncoded, experience: "noExperience", schedule: "remote", page: page);
                items.AddRange(vacancies1);
                page++;
            }
            while (vacancies1.Count() > 0);

            IEnumerable<Item> vacancies2;
            page = 0;
            do
            {
                vacancies2 = await _vacanciesRequesterAndExtractorFromHttpResponse.GetVacanciesResponseObjectViaHttpQuery(csharpQueryUrlEncoded, experience: "between1And3", schedule: "remote", page: page);
                items.AddRange(vacancies2);
                page++;
            }
            while (vacancies2.Count() > 0);

            IEnumerable<Item> vacancies3;
            page = 0;
            do
            {
                vacancies3 = await _vacanciesRequesterAndExtractorFromHttpResponse.GetVacanciesResponseObjectViaHttpQuery(csharpQueryUrlEncoded, experience: "between1And3", schedule: "fullDay", areaId: 71, page: page);
                items.AddRange(vacancies3);
                page++;
            }
            while (vacancies3.Count() > 0);

            IEnumerable<Item> vacancies4;
            page = 0;
            do
            {
                vacancies4 = await _vacanciesRequesterAndExtractorFromHttpResponse.GetVacanciesResponseObjectViaHttpQuery(csharpQueryUrlEncoded, experience: "noExperience", schedule: "fullDay", areaId: 71, page: page);
                items.AddRange(vacancies4);
                page++;
            }
            while (vacancies4.Count() > 0);

            IsNotBusy = true;
            Items = items;
            OnPropertyChanged(nameof(IsNotBusy));
            OnPropertyChanged(nameof(Items));
        }
    }
}
