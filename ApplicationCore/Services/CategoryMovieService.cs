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
    public class CategoryMovieService : EntityService<CategoryMovie>, ICategoryMovieService
    {
        private readonly ICategoryMovieRepository _repository;
        public CategoryMovieService(ICategoryMovieRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ICollection<Guid> GetIdCategoryByMovieId(Guid movieId)
        {
            return _repository.GetIdCategoryByMovieId(movieId);
        }

        public CategoryMovie FindBy2Id(Guid movieId, Guid modelId)
        {
            return _repository.FindBy2Id(movieId, modelId);
        }
    }
}
