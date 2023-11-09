using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleIndicatorChecker : MonoBehaviour
{
    [SerializeField] private ResultPanelView resultPanelView;
    public event System.Action ShrinkMaxEvent;

    [SerializeField] private float minSize;

    public static CircleIndicatorChecker Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        ShrinkMaxEvent += CheckSize;
    }
    private void OnDestroy() => ShrinkMaxEvent = null;
    public void InvoleShrinkMaxEvent() => ShrinkMaxEvent?.Invoke();

    private void  CheckSize()
    {
        if(gameObject.transform.localScale.x< minSize)
        {
            InputManager.CanTouch = false;
            resultPanelView.OpenPanel(false);
        }
    }

}
