namespace eShop.Modules;

public abstract class Response
{
    protected Guid _correlationId;
    public Guid GetCorrelationId() => _correlationId;

    public Response(Guid correlationId)
    {
        _correlationId = correlationId;
    }
}
