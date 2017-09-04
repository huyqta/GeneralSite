using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Google.Apis.Storage.v1;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminSite.Helpers
{
    public class GoogleApis
    {
        IConfiguration _configuration;
        string bucketName = "huyquan-images";

        public GoogleApis(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string UploadFile(string destinationName, string resourcePath, string contentType)
        {
            GoogleCredential credential = GoogleCredential.FromStream(new FileStream("ImageStorage-3f0620d7367a.json", FileMode.Open));
			credential.CreateScoped(new string[] { StorageService.Scope.DevstorageFullControl });
			var storage = StorageClient.Create();
            UploadObjectOptions option = new UploadObjectOptions()
            {
                PredefinedAcl = PredefinedObjectAcl.PublicRead,
            };
            var fileUploaded = storage.UploadObject(bucketName, destinationName, contentType, new FileStream(resourcePath, FileMode.Create), option);
            return fileUploaded.SelfLink;
		}
    }
}
