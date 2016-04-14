
using System.Text;


namespace HomepageGalleryGenerator
{
    class HTMLContentGenerator : IContentGenerator
    {
        #region IContentGenerator Members

        string GenerateTable(string imagesFolder, string[] images, string alt)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\t\t\t\t\t\t\t\t<table class=\"modele\">");
            
            int size = images.Length;
            int i = 0;
            while(i < size)
            {
                builder.AppendLine("\t\t\t\t\t\t\t\t\t<tr>");

                for(int j = 0; j < 3; j++)
                {
                    if(i < size)
                    {
                        string ext, image = images[i];
                        if(image.Contains(".jpg"))
                        {
                            image = image.Replace(".jpg", "");
                            ext = ".jpg";
                        }
                        else
                        {
                            image = image.Replace(".JPG", "");
                            ext = ".JPG";
                        }

                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t<td class=\"galeria\">");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t<div>");
                        builder.Append("\t\t\t\t\t\t\t\t\t\t\t\t<a href=\"");
                        builder.Append(imagesFolder);
                        builder.Append("/");
                        builder.Append(image);
                        builder.Append(ext);
                        builder.AppendLine("\"");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tclass=\"highslide\" ");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\tonclick=\"return hs.expand(this)\">");
                        builder.Append("\t\t\t\t\t\t\t\t\t\t\t\t\t<img src=\"");
                        builder.Append(imagesFolder);
                        builder.Append("/");
                        builder.Append(image);
                        builder.Append("_small");
                        builder.Append(ext);
                        builder.Append("\"");
                        builder.Append("alt=\"");
                        builder.Append(alt);
                        builder.AppendLine("\"");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\ttitle=\"Kliknij aby powiększyć\"/>");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</a>");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"highslide-caption\">");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</div>");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t\t</div>");
                        builder.AppendLine("\t\t\t\t\t\t\t\t\t\t</td>");
                    }

                    i++;
                }

                builder.AppendLine("\t\t\t\t\t\t\t\t\t</tr>");
            }
            
            builder.AppendLine("\t\t\t\t\t\t\t\t</table>");
            return builder.ToString();
        }

        public string GenerateContent(string modelName, string scale, string producer, string description, string imagesFolder, string[] images, string alt)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\t\t\t\t\t<div id=\"content\">");
            builder.Append("\t\t\t\t\t\t<h4>");
            builder.Append(modelName);
            builder.Append(" ");
            builder.Append(scale);
            builder.Append(" ");
            builder.Append(producer);
            builder.AppendLine("</h4>");
            builder.AppendLine("\t\t\t\t\t\t<div class=\"wpis\">");
            builder.AppendLine(description);
            builder.AppendLine("\t\t\t\t\t\t</div>");
            builder.AppendLine("\t\t\t\t\t\t<h4>Galeria</h4>");
            builder.AppendLine("\t\t\t\t\t\t<div>");
            builder.AppendLine("\t\t\t\t\t\t\t<div class=\"wpis\">");
            builder.Append(this.GenerateTable(imagesFolder, images, alt));
            builder.AppendLine("\t\t\t\t\t\t\t</div>");
            builder.AppendLine("\t\t\t\t\t\t\t<div class=\"wpis\">");
            builder.Append("Jeśli chciałbyś mieć model podobny do tych, które prezentuję, ");
            builder.AppendLine("skontaktuj się ze mną. E-mail w stopce strony.");
            builder.AppendLine("\t\t\t\t\t\t\t</div>");
            builder.AppendLine("\t\t\t\t\t\t</div>");
            builder.AppendLine("\t\t\t\t\t</div>");

            return builder.ToString();
        }

        #endregion
    }
}
