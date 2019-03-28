using Bank.DAL.Models;
using Bank.Web.Resources;

namespace Bank.Web.ViewModels
{
    public class LoanModel
    {
        public double Money { get; set; }

        public double Percent { get; set; }

        public string ExpDate { get; set; }

        public string CreationDate { get; set; }

        public int? CardId { get; set; }


        public static LoanModel From(Loan entity)
        {
            return new LoanModel
            {
                Money = entity.Money,
                Percent = entity.Percent,
                ExpDate = entity.ExpDate.ToString(CommonResources.DateFormat),
                CreationDate = entity.CreationDate.ToString(CommonResources.DateFormat),
                CardId = entity.CardId
            };
        }
        
        
        public Loan To(LoanModel model)
        {
            return new Loan
            {
                Money = model.Money,
                Percent = model.Percent,
                CardId = model.CardId
            };
        }
        
    }
}