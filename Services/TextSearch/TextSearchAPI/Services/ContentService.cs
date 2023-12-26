using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using TextSearchAPI.Models;
using TextSearchAPI.Repository;

namespace TextSearchAPI.Services
{
    public class ContentService
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
            // return ResponseDto<ProductDto>.Success(responseProduct.CreateDto(), HttpStatusCode.Created);




        }

        public async Task<ImmutableList<Content>> GetAllAsync()
        {


            var contents = await _contentRepository.GetAllAsync();
            return contents;
            // var productListDto = new List<Content>();



            // foreach (var x in products)
            // {

            //     if (x.Feature is null)
            //     {
            //         productListDto.Add(new ProductDto(x.Id, x.Name, x.Price, x.Stock, null));

            //         continue;
            //     }


            //     productListDto.Add(new ProductDto(x.Id, x.Name, x.Price, x.Stock, new ProductFeatureDto(x.Feature.Width, x.Feature!.Height, x.Feature!.Color.ToString())));





            // }



            // return ResponseDto<List<ProductDto>>.Success(productListDto, HttpStatusCode.OK);

        // return cont

        }


    }
}