using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Core.Utilities.Results;

namespace Adapters.Abstracts
{
    public interface ICloudinaryService
    {
       ImageUploadResult uploadImage(ImageUploadParams image);
    }
}
