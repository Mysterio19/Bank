using System.Collections.Generic;

namespace Bank.Web.ViewModels
{
    public class OverallViewModel
    {
        public OverallViewModel()
        {
            Cards = new List<CardViewModel>();
        }
        
        public List<CardViewModel> Cards { get; set; }   
    }
}