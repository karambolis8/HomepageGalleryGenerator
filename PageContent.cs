using System.Collections.Generic;

namespace HomepageGalleryGenerator
{
    public class PageContent
    {
        public string Model { get; set; }

        public int Scale { get; set; }

        public string Producer { get; set; }

        public string Description { get; set; }

        public string ImagesDirectory { get; set; }

        public string [] ImagesList { get; set; }

        public string AltDescription { get; set; }

        public string WebsiteImageDir { get; set; }

        public string HtmlFile { get; set; }
    }
}