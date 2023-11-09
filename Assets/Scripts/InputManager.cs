using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private ObjectScaler objectScaler;
    [SerializeField] private BulletController bulletCntrl;
    private Bullet bullet;

    private bool isScaling = false; 
    public static bool CanTouch = true;

    private void Start()
    {
        bullet = bulletCntrl.InitializeBullet();
        bullet.gameObject.SetActive(false);
    }

    void Update()
    {


#if UNITY_ANDROID && !UNITY_EDITOR
        HandleAndroidInput();
#else
        HandleMouseInput();
#endif

        if (isScaling)
        {
            objectScaler.UpdateSize();
        }
    }

    private void HandleAndroidInput()
    {
        if (!CanTouch) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                bullet = bulletCntrl.InitializeBullet();
                bullet.gameObject.SetActive(true);
                objectScaler.StartScaling();
                isScaling = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                objectScaler.StopScaling();
                isScaling = false;
                bullet.PullBall(DoorController.Instance.transform);
                CircleIndicatorChecker.Instance?.InvoleShrinkMaxEvent();
            }
        }
    }

    private void HandleMouseInput()
    {
        if (!CanTouch) return;

        if (Input.GetMouseButtonDown(0))
        {
            bullet = bulletCntrl.InitializeBullet();
            bullet.gameObject.SetActive(true);
            objectScaler.StartScaling();
            isScaling = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            objectScaler.StopScaling();
            isScaling = false;
            bullet.PullBall(DoorController.Instance.transform);
            CircleIndicatorChecker.Instance?.InvoleShrinkMaxEvent();
        }
    }
}
