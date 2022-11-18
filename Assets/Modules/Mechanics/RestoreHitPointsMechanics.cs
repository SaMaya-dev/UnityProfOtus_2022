using Elementary;
using UnityEngine;

namespace Teacher.Architecture.Mechanics
{
    public sealed class RestoreHitPointsMechanics : MonoBehaviour
    {
        [SerializeField]
        private EventReceiver_Int takeDamageReceiver;

        [SerializeField]
        private IntBehaviour hitPoints;

        [SerializeField]
        private TimerBehaviour delay;

        [SerializeField]
        private PeriodBehaviour restorePeriod;

        private void OnEnable()
        {
            this.takeDamageReceiver.OnEvent += this.OnDamageTaken;
            this.delay.OnFinished += this.OnDelayEnded;
            this.restorePeriod.OnPeriodEvent += this.OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver.OnEvent -= this.OnDamageTaken;
            this.delay.OnFinished -= this.OnDelayEnded;
            this.restorePeriod.OnPeriodEvent -= this.OnRestoreHitPoints;
        }

        private void OnDamageTaken(int damage)
        {
            //Сброс задержки:
            this.delay.ResetTime();
            if (!this.delay.IsPlaying)
            {
                this.delay.Play();
            }
            
            this.restorePeriod.Stop();
        }

        private void OnDelayEnded()
        {
            this.restorePeriod.Play();
        }

        private void OnRestoreHitPoints()
        {
            this.hitPoints.Assign(hitPoints.Value+1);
            if (this.hitPoints.Value >= 5)
            {
                this.restorePeriod.Stop();
            }
        }
    }
}