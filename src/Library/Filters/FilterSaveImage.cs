using System;
using CompAndDel;

public class FilterSaveImage : IFilter
{
    private string outputPath;

    public FilterSaveImage(string outputPath)
    {
        this.outputPath = outputPath;
    }

    public IPicture Filter(IPicture image)
    {
        // Guardar la imagen en el outputPath
        PictureProvider provider = new PictureProvider();
        provider.SavePicture(image, outputPath);

        // Devolver la imagen sin cambios para que la secuencia continúe
        return image;
    }
}