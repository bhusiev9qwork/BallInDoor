using UnityEngine;

public class BulletController : MonoBehaviour
{
   [SerializeField] private ObjectPool bulletPool;
   [SerializeField] private ObjectScaler objectScaler;

    [SerializeField] private Transform startPos;
    public Bullet InitializeBullet()
    {
        var obj = bulletPool.GetPooledObject();

        var bullet = obj.GetComponent<Bullet>();
        bullet.SetObjectPool(bulletPool);

        objectScaler.InitializeObjectToScale(obj);

        obj.transform.position = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
        obj.transform.SetParent(bulletPool.transform);
        obj.SetActive(true);

        return obj.GetComponent<Bullet>();
    }
}
