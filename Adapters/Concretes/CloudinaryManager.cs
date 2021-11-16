using System;
using System.Diagnostics;
using Adapters.Abstracts;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Adapters.Concretes
{
    public class CloudinaryManager : ICloudinaryService
    {
        private static Account account = new Account(
            "karaca",
            "799467644461433",
            "a7Jl4-35MHxgLtC6QR40y8zrSwo");

        private Cloudinary cloudinary = new Cloudinary(account);

        public void GetFileDescription()
        {
            // Get the file version for the notepad.
            FileVersionInfo myFileVersionInfo =
                FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\\");

            // Print the file description.
            Console.WriteLine("File description: " + myFileVersionInfo.FileDescription);

        }
        public ImageUploadResult uploadImage(ImageUploadParams image)
        {
            return cloudinary.Upload(image);
        }
    }
}
