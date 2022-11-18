using Elementary;
using UnityEngine;

namespace Teacher.Architecture.Mechanics
{
    public sealed class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField]
        private EventReceiver_Int takeDamageReceiver;

        [SerializeField]
        private IntBehaviour hitPoints;

        private void OnEnable()
        {
            this.takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            hitPoints.Assign(hitPoints.Value - damage);
        }
    }
}