using Bliss.Recruitment.Simple.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecruitmentContext _recruitmentContext;

        public UnitOfWork(RecruitmentContext recruitmentContext)
        {
            _recruitmentContext = recruitmentContext;
        }

        public async Task Save()
        {
            await _recruitmentContext.SaveChangesAsync();
        }
    }

}
