using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private ObjectPool obstaclePool;
    private bool collisionOccurred = false;
    private float destroyDelay = .3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionOccurred) return; 

        if (collision.gameObject.CompareTag("PlayerBall"))
        {
            VFXManager.Instance?.PlayEffect(EffectType.ExplosionObstacle, transform);
            collisionOccurred = true; 

            Invoke("DestroyObject", destroyDelay);
        }
    }
    private void DestroyObject()
    {
        gameObject.SetActive(false);
        obstaclePool.ReturnPooledObject(gameObject);

    }
    public void SetObjectPool(ObjectPool pool) => this.obstaclePool = pool;
}
