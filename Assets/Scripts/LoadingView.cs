using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class LoadingView : MonoBehaviour
{
    public TextMeshProUGUI header;
    [SerializeField] private Slider loadingBar;

    public float fillDuration = 1f;

    public static LoadingView Instance;
    private void Awake()
    {
        Instance = this;
        StartCoroutine(UpdateLoadingView());
    }

    public async Task AnimateProgressBar(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float value = Mathf.Lerp(startValue, endValue, t);
            loadingBar.value = value;

            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }

        loadingBar.value = endValue;
        
        if (loadingBar.value == 1f) Close();
    }


    public async Task RunAsyncWithProgressBar(Task task, float startValue, float endValue, float duration)
    {
        await AnimateProgressBar(startValue, endValue, duration);
        await task;

    }
    private IEnumerator UpdateLoadingView()
    {
        header.text = "NEW MATCH";
        StringBuilder stringBuilder = new(header.text);

        while (loadingBar.value < 1)
        {
            yield return new WaitForSeconds(0.2f);
            stringBuilder.Append("!");
            if (stringBuilder.Length > 11)
            {
                stringBuilder.Length = 8;
            }
            header.text = stringBuilder.ToString();
        }
    }

    public void Close()
    {

        gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
}
