using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Models
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string Title { get; set; }
        public string Coach { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
