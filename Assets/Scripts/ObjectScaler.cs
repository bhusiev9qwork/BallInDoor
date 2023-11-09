using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{

    [SerializeField] private float maxSize; 
    [SerializeField] private float growthRate; 

    private float currentSize; 
    private bool isGrowing = false; 

    [SerializeField] private GameObject traectoryIndicator;
    [SerializeField] private GameObject scaleIndicator;
    private GameObject objectToScale; 

    private float initialScaleIndicatorSize; 
    private float initialSize; 
    private float remainingIndicatorSize; 

    private float initialTraectoryIndicatorSize; 
    private float traectoryScaleCoefficient; 

    private void Start()
    {
        initialScaleIndicatorSize = scaleIndicator.transform.localScale.x; 
        remainingIndicatorSize = initialScaleIndicatorSize; 
        initialTraectoryIndicatorSize = traectoryIndicator.transform.localScale.x; 
        traectoryScaleCoefficient = 1f;
    }

    public void InitializeObjectToScale(GameObject obj)
    {
        objectToScale = obj;
        initialSize = objectToScale.transform.localScale.x; 
        currentSize = initialSize; 
    }

    public void StartScaling() => isGrowing = true;

    public void StopScaling() => isGrowing = false;

    public void UpdateSize()
    {
        StartCoroutine(ScaleObject());
    }

       private IEnumerator ScaleObject()
        {
            while (isGrowing && objectToScale != null && currentSize < maxSize && remainingIndicatorSize > 0f)
            {
                float sizeDelta = growthRate * Time.deltaTime/2;

                //  Limit the size so as not to exceed the remaining size of the indicator ball
                sizeDelta = Mathf.Min(sizeDelta, remainingIndicatorSize);

                // Increase the current size
                currentSize += sizeDelta;

                // Proportional reduction of the indicator ball
                float scaleRatio = currentSize / maxSize;
                CircleIndicatorChecker.Instance?.InvoleShrinkMaxEvent();
                remainingIndicatorSize -= sizeDelta * scaleRatio;

                // Proportional change in the size of the indicator trajectory
                traectoryScaleCoefficient = Mathf.Min(traectoryScaleCoefficient, maxSize / initialSize); // Ограничиваем коэффициент
                float traectorySize = Mathf.Lerp(remainingIndicatorSize, initialTraectoryIndicatorSize, scaleRatio);
            
             
                traectoryIndicator.transform.localScale = new Vector3(traectorySize*4, traectoryIndicator.transform.localScale.y, traectoryIndicator.transform.localScale.z);

                objectToScale.transform.localScale = new Vector3(currentSize, currentSize, currentSize);

                scaleIndicator.transform.localScale = new Vector3(remainingIndicatorSize, remainingIndicatorSize, remainingIndicatorSize);

                yield return null;
            }
        }


}






