﻿using ApplicationCore.Repositories;
using Common.GenericRepository;
using Common.Service;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ProducerMovieService : EntityService<ProducerMovie>, IProducerMovieService
    {
        private readonly IProducerMovieRepository _repository;
        public ProducerMovieService(IProducerMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
