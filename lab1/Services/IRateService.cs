using lab1.Entities;

namespace lab1.Services;

public interface IRateService
{
    public Task<IEnumerable<Rate>?> GetRates(DateTime date);
}
