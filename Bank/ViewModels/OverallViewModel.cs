using System.Collections.Generic;

namespace Bank.Web.ViewModels
{
    public class OverallViewModel
    {
        public OverallViewModel()
        {
            Cards = new List<CardViewModel>();
            Deposits = new List<DepositModel>();
        }
        
        public List<CardViewModel> Cards { get; set; }
        public List<DepositModel> Deposits { get; set; }
    }
}