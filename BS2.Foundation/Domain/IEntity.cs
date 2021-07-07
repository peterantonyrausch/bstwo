namespace BS2.Foundation.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}