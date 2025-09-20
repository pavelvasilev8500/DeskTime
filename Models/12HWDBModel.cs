using DeskTime.Models._12HoursWeatherModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskTime.Models
{
    public class _12HWDBModel
    {
        [Key]
        public int Id { get; set; }
        public _12HWeatherModel WeatherModel { get; set; }

    }
}
