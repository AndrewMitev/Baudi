namespace Baudi.Services.Data.Contracts
{
    using System.Linq;

    public interface ITestServices
    {
        IQueryable Get();
    }
}
