using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ImmutableList<Content>> GetAllAsync()
        {
            var contents = await _contentRepository.GetAllAsync();
            return contents;
        }

        

    }
}