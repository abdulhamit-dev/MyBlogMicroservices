using Minio;
using Minio.DataModel.Args;
using SharedLib.Dtos;

namespace ImageStoreAPI.Services;

public class ImageService : IImageService
{
    private readonly IMinioClient _minioClient;
    private readonly IConfiguration _configuration;

    public ImageService(IMinioClient minioClient, IConfiguration configuration)
    {
        _minioClient = minioClient;
        _configuration = configuration;
    }

    public async Task<Response<string>> UploadImage(IFormFile file)
    {
    
        var bucketName = "image";
        var objectName = file.FileName;

        using (var stream = file.OpenReadStream())
        {
            var putObjectArgs = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length);

            await _minioClient.PutObjectAsync(putObjectArgs);
        }
        var url = $"http://localhost:9000/image/{objectName}";

        return Response<string>.Success(url, 200);
    }
}
