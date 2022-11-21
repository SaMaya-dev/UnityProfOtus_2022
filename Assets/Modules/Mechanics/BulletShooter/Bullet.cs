using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 direction, Vector3 startPoint)
    {
        transform.SetPositionAndRotation(startPoint, Quaternion.identity);
        gameObject.SetActive(true);
        rb.AddForce(direction, ForceMode.Impulse);
    }
    
    public void Dispose()
    {
        transform.localPosition = Vector3.zero;
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
