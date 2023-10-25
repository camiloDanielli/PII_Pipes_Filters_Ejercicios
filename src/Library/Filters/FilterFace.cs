using System.IO;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class Filterface : IFilter
    {
        public bool DetectedFace { get; private set; }

    public IPicture Filter(IPicture image)
    {
        CognitiveFace cognitiveFace = new CognitiveFace();

        PictureProvider provider = new PictureProvider();
        provider.SavePicture(image, @"..\..\sendedImage.jpg");
        string path = File.Exists(@"../../sendedImage.jpg") ? @"../../sendedImage.jpg" : @"sendedImage.jpg";

        cognitiveFace.Recognize(path);

        DetectedFace = cognitiveFace.FaceFound;

        return (image);
    }
    }
}