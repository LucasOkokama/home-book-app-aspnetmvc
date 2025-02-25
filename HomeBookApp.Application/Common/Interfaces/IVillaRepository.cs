﻿using HomeBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookApp.Application.Common.Interfaces
{
    public interface IVillaRepository: IRepository<Villa>
    {
        void Update(Villa entity);
    }
}
