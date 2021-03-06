﻿using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ITagService: IEntityService<Tag>
    {
        ICollection<Tag> SearchTagByName(string nameTag);
    }
}
