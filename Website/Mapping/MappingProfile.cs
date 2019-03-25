﻿using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Identity;
using Website.Models;
using Website.ViewModel;

namespace Website.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapFromEntitiesToViewModels();
            CreateMapFromViewModelsToEntites();
        }

        private void CreateMapFromViewModelsToEntites()
        {
            CreateMap<UpdateUserViewModel, ApplicationUser>();
            CreateMap<NewsViewModel, News>();
            CreateMap<MoviesViewModel, Movie>();
        }

        private void CreateMapFromEntitiesToViewModels()
        {
            CreateMap<ApplicationUser, UpdateUserViewModel>();
            CreateMap<News, NewsViewModel>();
            CreateMap<Movie, MoviesViewModel>();
        }
    }
}