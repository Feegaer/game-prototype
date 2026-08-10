namespace Assets.Scripts.Interfaces
{
    public interface IInteractable
    {
        void Interact();
        string InteractionPrompt { get; }
    }
}
