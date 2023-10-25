using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using SixLabors.ImageSharp.Formats.Bmp;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {   
            // cargar una imagen
            PictureProvider provider = new PictureProvider();
            IPicture image = provider.GetPicture(@"..\..\..\beer.jpg");
            IPipe pipeNull = new PipeNull();
            IFilter Filto1 = new FilterNegative();
            IPipe pipe2 = new PipeSerial(Filto1, pipeNull);
            IFilter Filto2 = new FilterGreyscale();
            IPipe pipe1 = new PipeSerial(Filto2, pipe2);

            IPicture processedImage = pipe1.Send(image);


            provider.SavePicture(processedImage, @"..\..\..\beer1.jpg");
        }
    }
}
