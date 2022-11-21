using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] 
    private Bullet bulletTemplate;
    private SimplePool pool;
    private WaitForSeconds delayBeforeGoBackToPool = new WaitForSeconds(2f);
    private void Awake()
    {
        bulletTemplate.gameObject.SetActive(false);
        pool = new SimplePool(FactoryBulletMethod);
    }
    
    public void Shoot(Vector3 v, Transform spawnPoint)
    {
        var bullet = CreateBullet();
        bullet.Init(v, spawnPoint.position);
        StartCoroutine(WaitAndGoBackToPool(bullet));
    }
    
    private Bullet CreateBullet()
    {
        var result = pool.GetObject() as Bullet;
        return result;
    }

    private IEnumerator WaitAndGoBackToPool(Bullet bulletObject)
    {
        yield return delayBeforeGoBackToPool;
        
        pool.ReleaseObject(bulletObject);
        bulletObject.Dispose();
    }
    
    object FactoryBulletMethod() => Instantiate(bulletTemplate, bulletTemplate.transform.parent);
    
}
