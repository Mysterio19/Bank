namespace Bank.DAL.Abstract
{
    public interface IFormulaEntity : IRangeEntity
    {
        decimal Money { get; set; }

        decimal Percent { get; set; }
    }
}