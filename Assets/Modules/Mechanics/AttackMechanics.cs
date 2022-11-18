using Elementary;
using UnityEngine;


public sealed class AttackMechanics : MonoBehaviour
{
    [SerializeField] private EventReceiver attackReceiver;

    [SerializeField] private TimerBehaviour countdown;

    [SerializeField] private IntBehaviour damage;

    [Space] [SerializeField] private EventReceiver_Int enemyTakeDamageReceiver;

    private void OnEnable()
    {
        this.attackReceiver.OnEvent += this.OnRequiestAttack;
    }

    private void OnDisable()
    {
        this.attackReceiver.OnEvent -= this.OnRequiestAttack;
    }

    private void OnRequiestAttack()
    {
        if (this.countdown.IsPlaying)
        {
            return;
        }

        //Нанесение урона противнику: 
        if (enemyTakeDamageReceiver)
            this.enemyTakeDamageReceiver.Call(this.damage.Value);

        //Запуск перезарядки:
        this.countdown.ResetTime();
        this.countdown.Play();
    }
}