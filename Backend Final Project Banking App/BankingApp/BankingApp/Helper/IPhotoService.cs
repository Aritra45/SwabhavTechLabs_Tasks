using CloudinaryDotNet.Actions;

namespace BankingApp.Helper
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}
