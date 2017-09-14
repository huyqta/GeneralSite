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
using System.Collections.Generic;

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

        public IList<Google.Apis.Storage.v1.Data.Object> GetAllProductImages()
        {
            var storage = StorageClient.Create();
            
            StorageService storageService = storage.Service;
            ObjectsResource.ListRequest request = storageService.Objects.List(bucketName);
            request.Delimiter = "/";
            request.Prefix = "shop-khh/category/"; //delimiter is any sub-folder name. E.g : "2010/"
            Google.Apis.Storage.v1.Data.Objects response = request.Execute();
            if (response.Prefixes != null)
            {
                return response.Items;
            }
            return null;
        }

        public IList<Google.Apis.Storage.v1.Data.Object> GetAllProductImagesByCategory(string prefix)
        {
            var storage = StorageClient.Create();

            StorageService storageService = storage.Service;
            ObjectsResource.ListRequest request = storageService.Objects.List(bucketName);
            request.Delimiter = "/";
            request.Prefix = prefix; //delimiter is any sub-folder name. E.g : "2010/"
            Google.Apis.Storage.v1.Data.Objects response = request.Execute();
            if (response.Items != null)
            {
                return response.Items;
            }
            return null;
        }

        public IList<string> GetAllCategories()
        {
            var storage = StorageClient.Create();

            StorageService storageService = storage.Service;
            ObjectsResource.ListRequest request = storageService.Objects.List(bucketName);
            request.Delimiter = "/";
            request.Prefix = "shop-khh/category/"; //delimiter is any sub-folder name. E.g : "2010/"
            Google.Apis.Storage.v1.Data.Objects response = request.Execute();
            if (response.Prefixes != null)
            {
                return response.Prefixes;
            }
            return null;
        }
    }
}
