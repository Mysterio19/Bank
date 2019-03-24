using System.Collections.Generic;

namespace Bank.Web.ViewModels
{
    public class OverallModel
    {
        public OverallModel()
        {
            Cards = new List<CardModel>();
        }
        
        public List<CardModel> Cards { get; set; }   
    }
}