using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Cognitive;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {   
            // cargar una imagen
            PictureProvider provider = new PictureProvider();
            IPicture image = provider.GetPicture(@"..\..\..\luke.jpg");

            

            IFilter Negative = new FilterNegative();
            IFilter Post = new FilterPostImage();
            IFilter Grey = new FilterGreyscale();
            IFilter blur = new FilterBlurConvolution();
            IFilter face = new Filterface();


            IPipe pipeNull = new PipeNull();
            
            IPipe pipe2 = new PipeSerial(Negative, pipeNull);

            IPipe pipe3 = new PipeSerial(Post, pipeNull);
            

            IPipe pipeCoditional = new PipeCond(face,pipe3,pipe2);

            IPipe pipe1 = new PipeSerial(face, pipeCoditional);

            IPicture processedImage = pipe1.Send(image);


            provider.SavePicture(processedImage, @"..\..\..\beer2.jpg");
        }
    }
}
