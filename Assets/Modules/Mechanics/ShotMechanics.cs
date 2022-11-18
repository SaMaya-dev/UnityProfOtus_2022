using Elementary;
using UnityEngine;

public class ShotMechanics : MonoBehaviour
{
    [SerializeField]
    private EventReciever_Vector shotReceiver;

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

    private void OnShotEvent(Vector3 v)
    {
        var bullet = CreateBullet();
        bullet.gameObject.SetActive(true);
        bullet.AddForce(v, ForceMode.Impulse);
    }

    private Rigidbody CreateBullet()
    {
        return Instantiate(bulletTemplate, bulletTemplate.transform.parent);
    }

}
