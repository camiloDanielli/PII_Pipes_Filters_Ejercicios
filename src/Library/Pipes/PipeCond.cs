using System;
using CompAndDel;
using CompAndDel.Filters;

public class PipeCond : IPipe
{
    private IPipe PipeTrue;
    private IPipe PipeFalse;

    private IFilter Filtro;
    public PipeCond(IFilter filter, IPipe pipeTrue, IPipe pipeFalse)
    {
        this.PipeTrue = pipeTrue;
        this.PipeFalse = pipeFalse;
        this.Filtro = filter;
    }

    public IPicture Send(IPicture picture)
    {
        // Determinamos cuál de los dos filtros usaremos
        
            picture = Filtro.Filter(picture);

            if (Filtro is Filterface && (Filtro as Filterface).DetectedFace)
            {
                return PipeTrue.Send(picture);
            }
            return PipeFalse.Send(picture); // Aplica el filtro si no hay cara
    }
}