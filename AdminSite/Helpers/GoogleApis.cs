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
        string bucketName = Commons.ConstantUploadPath.BUCKET_NAME;
        string googleStorageHost = Commons.ConstantUploadPath.GOOGLE_STORAGE_HOST;

        public GoogleApis(IConfiguration configuration)
        {
            _configuration = configuration;

            GoogleCredential credential = GoogleCredential.FromStream(new FileStream("ImageStorage-3f0620d7367a.json", FileMode.Open));
            credential.CreateScoped(new string[] { StorageService.Scope.DevstorageFullControl });
        }

        public string UploadFile(string destinationName, string contentType, Stream file, string destinationFolder)
        {   
			var storage = StorageClient.Create();
            UploadObjectOptions option = new UploadObjectOptions()
            {
                PredefinedAcl = PredefinedObjectAcl.PublicRead,
            };
            
            var fileUploaded = storage.UploadObject(bucketName, destinationFolder + destinationName, contentType, file, option);
            return string.Format("{0}{1}/{2}", googleStorageHost, bucketName, fileUploaded.Name);
            // Default path: https://storage.googleapis.com/ + <bucket_name> + / + Name
        }

        public bool CheckFileExist(string imageUrl)
        {
            var storage = StorageClient.Create();
            var fileName = imageUrl.Replace(googleStorageHost + bucketName, "");
            return storage.GetObject(bucketName, fileName) != null;
        }
    }
}
