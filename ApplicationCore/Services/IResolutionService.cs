﻿using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IResolutionService : IEntityService<Resolution>
    {
        IEnumerable<Resolution> SearchByName(string keyword);
    }
}
