using Elementary;
using UnityEngine;
using Zenject;

public class ShootMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReceiver shotReceiver;
    
    [SerializeField] 
    private Transform bulletSpawnPoint;

    [SerializeField] private Vector3 shotVector;
    
    [Inject]
    private BulletShooter bulletShooter;
    private void OnEnable()
    {
        shotReceiver.OnEvent += OnShotEvent;
    }

    private void OnDisable()
    {
        shotReceiver.OnEvent -= OnShotEvent;
    }

    private void OnShotEvent()
    {
        bulletShooter.Shoot(shotVector, bulletSpawnPoint);
    }
}
