using Elementary;
using UnityEngine;
using Zenject;


public sealed class DeathMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntBehaviour hitPoints;

        [SerializeField]
        private EventReceiver deathReceiver;

        [Inject] 
        private IGameFinisher _gameFinisher;
        
        private void OnEnable()
        {
            this.hitPoints.OnValueChanged += this.OnHitPointsChanged;
        }

        private void OnDisable()
        {
            this.hitPoints.OnValueChanged -= this.OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                this.deathReceiver.Call();
                _gameFinisher.GameOver();
            }
        }
    }
