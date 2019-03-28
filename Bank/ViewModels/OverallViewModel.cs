using System.Collections.Generic;

namespace Bank.Web.ViewModels
{
    public class OverallViewModel
    {
        public OverallViewModel()
        {
            Cards = new List<CardViewModel>();
            Deposits = new List<DepositModel>();
            Loans = new List<LoanModel>();
        }
        
        public List<CardViewModel> Cards { get; set; }
        public List<DepositModel> Deposits { get; set; }
        public List<LoanModel> Loans { get; set; }
    }
}