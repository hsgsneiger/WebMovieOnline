﻿using Common.GenericRepository;
using Infrastructure.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Repositories
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        ICollection<Movie> GetAllFeatureMovies();

        ICollection<Movie> GetAllSeriesTV();

        ICollection<Movie> SearchMovieByName(string name);

        ICollection<Movie> SearchMovieByNameAndType(string name, bool isSeriesTV);
    }
}