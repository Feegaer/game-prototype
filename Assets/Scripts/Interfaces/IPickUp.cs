namespace Assets.Scripts.Interfaces
{
    public interface IPickUp : IInteractable
    {
        ItemType ItemType { get; }
    }
}