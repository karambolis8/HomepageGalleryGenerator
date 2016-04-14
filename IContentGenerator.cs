using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomepageGalleryGenerator
{
    interface IContentGenerator
    {
        string GenerateContent(string modelName, string scale, string producer, string description, string imagesFolder, string[] images, string alt);
    }
}
