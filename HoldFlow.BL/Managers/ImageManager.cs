using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HoldFlow.BL.Managers
{
    public class ImageManager : Manager<Image>, IImageManager
    {
        private readonly Cloudinary _cloudinary;

        public ImageManager(IOptions<CloudinarySettings> config, IImageRepository repository) : base(repository)
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }




        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {


            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),

                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    //Transformation = new Transformation(),
                    Folder = "HoldFlowImages"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<VideoUploadResult> AddVideoAsync(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = "HoldFlowVideos",
                    EagerAsync = true,
                    EagerTransforms = new List<Transformation>()
                    {
                        new EagerTransformation().Width(300).Height(300).Crop("fill").AudioCodec("none"),
                        new EagerTransformation().Width(160).Height(100).Crop("fill").Gravity("south").AudioCodec("none"),
                    }
                };
                uploadResult = await _cloudinary.UploadLargeAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}