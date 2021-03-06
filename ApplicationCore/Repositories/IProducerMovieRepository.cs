﻿using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IProducerMovieRepository : IGenericRepository<ProducerMovie>
    {
        ICollection<Guid> GetIdProducerByMovieId(Guid movieId);

        ProducerMovie FindBy2Id(Guid movieId, Guid modelId);
    }
}
