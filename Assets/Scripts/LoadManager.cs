using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private LoadingView loadingView;

    public static LoadManager Instance;
    private void Awake() => Init();

    private  void Init()
    {
        loadingView.gameObject.SetActive(true);
        float animationDuration = 1.0f;
        float startValue = 0f;
        float endValue = 1.0f;

        var tasks = new List<Task>
        {
            loadingView.RunAsyncWithProgressBar(Task.Run(() =>
                PrepareLevelData()), startValue, endValue, animationDuration),
        };
        Task.WhenAll(tasks);
        InputManager.CanTouch = true;

       
    }
    private void PrepareLevelData()
    {
        //TODO
    }
}
