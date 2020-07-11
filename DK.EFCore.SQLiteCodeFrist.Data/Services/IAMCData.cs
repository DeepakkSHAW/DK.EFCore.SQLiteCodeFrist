using DK.EFCore.SQLiteCodeFrist.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DK.EFCore.SQLiteCodeFrist.Data.Services
{
    public interface IAMCData
    {
        Task<bool> AddAMCSAsync(AMC amc);
        Task<IEnumerable<AMC>> GetAMCSAsync();
    }
}