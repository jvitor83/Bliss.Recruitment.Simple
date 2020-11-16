using Bliss.Recruitment.Simple.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Recruitment.Simple.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecruitmentContext _recruitmentContext;

        public UnitOfWork(RecruitmentContext recruitmentContext)
        {
            _recruitmentContext = recruitmentContext;
        }

        public void Save()
        {
            _recruitmentContext.SaveChanges();
        }
    }

}
