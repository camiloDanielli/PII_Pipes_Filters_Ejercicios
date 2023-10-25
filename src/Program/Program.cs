using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {   
            // cargar una imagen
            PictureProvider provider = new PictureProvider();
            IPicture image = provider.GetPicture(@"..\..\..\luke.jpg");
            IPipe pipeNull = new PipeNull();
            IFilter Filtro0 = new FilterNegative();
            IPipe pipe3 = new PipeSerial(Filtro0, pipeNull);
            IFilter Filtro1 = new FilterPostImage();
            IPipe pipe2 = new PipeSerial(Filtro1, pipe3);
            IFilter Filtro2 = new FilterGreyscale();
            IPipe pipe1 = new PipeSerial(Filtro2, pipe2);

            IPicture processedImage = pipe1.Send(image);


            provider.SavePicture(processedImage, @"..\..\..\luke2.jpg");
        }
    }
}