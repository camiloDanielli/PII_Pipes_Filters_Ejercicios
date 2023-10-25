using System.IO;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    public class FilterPostImage : IFilter
    {
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, @"..\..\..\sendedImage.jpg");

            
            string path = File.Exists(@"../../../sendedImage.jpg") ? @"../../sendedImage.jpg" : @"sendedImage.jpg";
            var twitter = new TwitterImage();
            twitter.PublishToTwitter("PII Camilo danielli images", path);


            // Devuelve la imagen original sin cambios.
            return image;
        }
    }
}