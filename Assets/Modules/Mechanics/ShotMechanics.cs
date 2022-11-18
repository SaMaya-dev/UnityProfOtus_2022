using Elementary;
using UnityEngine;

public class ShotMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReceiver shotReceiver;

    [SerializeField] 
    private Rigidbody bulletTemplate;
    
    private void Awake()
    {
        bulletTemplate.gameObject.SetActive(false);
    }

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
        var bullet = CreateBullet();
        bullet.gameObject.SetActive(true);
        bullet.AddForce(Vector3.forward * 30, ForceMode.Impulse);
    }

    private Rigidbody CreateBullet()
    {
        return Instantiate(bulletTemplate, bulletTemplate.transform.parent);
    }

}
