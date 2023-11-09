using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionDetector : MonoBehaviour
{
    [SerializeField] private ResultPanelView resultPanelView;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBall"))
        {
            resultPanelView.OpenPanel(true);
        }
    }
}
