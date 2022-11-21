using Elementary;
using UnityEngine;

public class ShotMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReciever_Vector shotReceiver;

    [SerializeField] 
    private BulletShooter bulletShooter;
    
    [SerializeField] 
    private Transform bulletSpawnPoint;
    
    private void OnEnable()
    {
        shotReceiver.OnEvent += OnShotEvent;
    }

    private void OnDisable()
    {
        shotReceiver.OnEvent -= OnShotEvent;
    }

    private void OnShotEvent(Vector3 v)
    {
        bulletShooter.Shoot(v, bulletSpawnPoint);
    }
}
