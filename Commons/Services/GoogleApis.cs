using System;
using System.Threading.Tasks;
using System.
namespace Commons.Services
{
    public class GoogleApis
    {
        public GoogleApis()
        {
			public async Task<String> UploadImage(IFormFile image, long id)
			{
				var imageAcl = PredefinedObjectAcl.PublicRead;

				var imageObject = await _storageClient.UploadObjectAsync(
					bucket: _bucketName,
					objectName: id.ToString(),
					contentType: image.ContentType,
					source: image.InputStream,
					options: new UploadObjectOptions { PredefinedAcl = imageAcl }
				);

				return imageObject.MediaLink;
			}
        }
    }
}
