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
        private IGameEventReceiver _gameEventReceiver;
        

        private void OnEnable()
        {
            characterService.GetCharacter().Get<IDeathComponent>().OnDeath += OnCharacterDied;
        }
        
        private void OnDisable()
        {
            characterService.GetCharacter().Get<IDeathComponent>().OnDeath -= OnCharacterDied;
        }

        private void OnCharacterDied()
        {
            _gameEventReceiver.GameOver();
        }
    }
}