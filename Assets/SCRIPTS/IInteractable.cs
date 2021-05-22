using System.Collections;

public interface IInteractable
{
    void Interact(CharacterEntity entity);
    string GetTextLabel();

    bool IsInteractionAllowed(CharacterEntity entity);
    
}