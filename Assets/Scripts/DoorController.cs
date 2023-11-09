using UnityEngine;

public class DoorController : MonoBehaviour
{
    [HideInInspector] public Bullet CurrentBullet;

    public static DoorController Instance;
    [SerializeField] private Animator doorAnim;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public float openDistance = 5f; 

    private bool isOpen = false;
    private float openCooldown = 1.0f; 
    private float lastOpenTime = 0.0f;

    private void Update()
    {
        if (CurrentBullet != null)
        {
            float distance = Vector3.Distance(transform.position, CurrentBullet.transform.position);

            if (distance < openDistance && !isOpen && Time.time - lastOpenTime > openCooldown)
                OpenDoor();
            else
                CloseDoor();
        }

        if (isOpen) lastOpenTime = Time.time;
    }

    private void OpenDoor()
    {
        if(isOpen == false) doorAnim.Play("OpenDoor");

        isOpen = true;
    }
    private void CloseDoor()
    {
        if(isOpen) doorAnim.Play("CloseDoor");

        isOpen = false;
    }
}



