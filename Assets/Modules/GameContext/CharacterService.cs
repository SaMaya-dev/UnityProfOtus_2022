using Entities;
using UnityEngine;

public sealed class CharacterService : MonoBehaviour
{
    [SerializeField]
    private Entity character;

    public IEntity GetCharacter()
    {
        return this.character;
    }
}