using Modules.Components;
using UnityEngine;
using Zenject;

namespace Modules.GameContext
{
    public class CharacterDeathObserver : MonoBehaviour
    {
        [Inject]
        private CharacterService characterService;
        
        [Inject]
        private IGameGameEventReceiver gameGameEventReceiver;
        

        private void OnEnable()
        {
            characterService.GetCharacter().Get<IDeathComponent>().OnDeath += OnCharacterDied;
        }

        private void OnCharacterDied()
        {
            gameGameEventReceiver.GameOver();
        }
    }
}