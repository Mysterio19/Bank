using Bank.DAL.Abstract;

namespace Bank.BL.Providers
{
    public interface IFormulaProvider : IProvider
    {
        decimal GetResult(IFormulaEntity entity);
    }
}