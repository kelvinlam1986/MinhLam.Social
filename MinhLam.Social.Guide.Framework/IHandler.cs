namespace MinhLam.Social.Guide.Framework
{
    public interface IHandler<T> where T: IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
