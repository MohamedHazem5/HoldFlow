using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace HoldFlow.BL.Interfaces
{
    public interface IImageManager : IManager<Image>
    {

        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<VideoUploadResult> AddVideoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
