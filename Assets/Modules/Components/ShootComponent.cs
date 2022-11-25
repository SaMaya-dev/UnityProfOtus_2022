using Elementary;
using UnityEngine;

public class ShootComponent : MonoBehaviour, IShootComponent
{
    [SerializeField] private EventReceiver shootReceiver;
    
    public void Shoot()
    {
        shootReceiver.Call();
    }
}