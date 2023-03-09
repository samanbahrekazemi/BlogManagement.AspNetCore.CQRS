namespace Core.Interfaces
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }
}
