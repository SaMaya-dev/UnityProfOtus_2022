using Elementary;
using UnityEngine;

public class ShootMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReceiver shotReceiver;

    [SerializeField] 
    private BulletShooter bulletShooter;
    
    [SerializeField] 
    private Transform bulletSpawnPoint;

    [SerializeField] private Vector3 shotVector;
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
