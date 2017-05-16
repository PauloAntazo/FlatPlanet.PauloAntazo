using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlatPlanet.JosePauloAntazo.MVCApp.ViewModel
{
    public class CounterViewModel
    {
        [Range(0,9,ErrorMessage = "Max 10 value only.")] //works likes index 
        
        public int Count { get; set; }
    }
}