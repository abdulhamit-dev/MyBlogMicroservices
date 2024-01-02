using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using SharedLib.Dtos;
using TextSearchAPI.Models;

namespace TextSearchAPI.Services
{
    public interface IContentService
    {
        public Task<Content> SaveAsync(Content content);
        public Task<Response<ImmutableList<Content>>> GetAllAsync();
        public Task<Response<ImmutableList<Content>>> SearchAsync(string searchText);
    }
}