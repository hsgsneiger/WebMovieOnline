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
    public class TagMovieService : EntityService<TagMovie>, ITagMovieService
    {
        private readonly ITagMovieRepository _repository;
        public TagMovieService(ITagMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Guid> GetIdTagByMovieId(Guid movieId)
        {
            return _repository.GetIdTagByMovieId(movieId);
        }

        public TagMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _repository.FindBy2Id(movieId, modelId);
        }
    }
}