using UnityEngine;

public class Bullet : MonoBehaviour
{
    private object bulletPool;
    public float bulletSpeed = 10.0f; 
    private Rigidbody rb;


    public void PullBall(Transform target)
    {
        rb = GetComponent <Rigidbody>();
        Vector3 direction = (target.position - transform.position).normalized;
        rb.isKinematic = false;
        DoorController.Instance.CurrentBullet = this;
        rb.velocity = direction * bulletSpeed;
    }
    public void SetObjectPool(ObjectPool pool) => this.bulletPool = pool;
}
