﻿using Sunrise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.DataAccess.Repository.IRepository
{
    public interface IPreviousSchoolRepository : IRepository<PreviousSchool>
    {
        void Update(PreviousSchool previousSchool);
    }
}
