using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentist.Application.Features.Mediator.Results.SliderCardResults
{
    public class GetSliderCardQueryResult
    {
        //card1
        public int SliderCardId { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        //card2
        public string Icon2 { get; set; }
        public string Title2 { get; set; }
        public string Subtitle2 { get; set; }
        public string day1 { get; set; }
        public string day2 { get; set; }
        public string day3 { get; set; }
        public string Hour1 { get; set; }
        public string Hour2 { get; set; }
        public string Hour3 { get; set; }
        //card3
        public string Icon3 { get; set; }
        public string Title3 { get; set; }
        public string Subtitle3 { get; set; }
        public string Description3 { get; set; }
    }
}
