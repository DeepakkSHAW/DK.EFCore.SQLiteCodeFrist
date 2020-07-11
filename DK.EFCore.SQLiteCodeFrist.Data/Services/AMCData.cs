using DK.EFCore.SQLiteCodeFrist.DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DK.EFCore.SQLiteCodeFrist.Data.Services
{
    public class AMCData : IAMCData
    {
        private AMCDBContext _ctx;
        public AMCData(AMCDBContext context)
        {
            _ctx = context;
        }

        //public AMCData() { _ctx = new AMCDBContext("DataBase Path"); }
        //public AMCData() { _ctx = new AMCDBContext(); }
        public async Task<IEnumerable<AMC>> GetAMCSAsync()
        {
            try
            {
                var quary = from c in _ctx.AMCs select c;
                return await quary.ToListAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<bool> AddAMCSAsync(AMC amc)
        {
            bool vResult = false;
            try
            {
                if (_ctx.AMCs.Where(e => e.AMCTitle == amc.AMCTitle).Count() == 0)
                {
                    _ctx.Add(amc);
                    var i = await _ctx.SaveChangesAsync();
                    if (i == 0) vResult = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
            return vResult;
        }
    }
}
