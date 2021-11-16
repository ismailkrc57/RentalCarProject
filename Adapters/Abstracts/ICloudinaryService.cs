using CloudinaryDotNet.Actions;

namespace Adapters.Abstracts
{
    public interface ICloudinaryService
    {
       ImageUploadResult uploadImage(ImageUploadParams image);
    }
}
