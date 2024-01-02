using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using SharedLib.Dtos;
using TextSearchAPI.Models;
using TextSearchAPI.Repository;

namespace TextSearchAPI.Services
{
    public class ContentService:IContentService
    {
        private readonly ContentRepository _contentRepository;

        public ContentService(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<Content> SaveAsync(Content content)
        {
            var responseProduct = await _contentRepository.SaveAsync(content);
            if (responseProduct == null)
            {
                // return ResponseDto<ProductDto>.Fail(new List<string> { "kayıt esnasında bir hata meydana geldi." }, System.Net.HttpStatusCode.InternalServerError);
            }
            return responseProduct;
        }

        public async Task<Response<ImmutableList<Content>>> GetAllAsync()
        {
            var contents = await _contentRepository.GetAllAsync();
            return Response<ImmutableList<Content>>.Success(contents, 200);
        }

        public async Task<Response<ImmutableList<Content>>> SearchAsync(string searchText)
        {
            var contents = await _contentRepository.SearchAsync(searchText);
            return Response<ImmutableList<Content>>.Success(contents, 200);
        }
    }
}