using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ResultPanelView : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> outcomeTexts;

    public void OpenPanel(bool isWin)
    {
        if (gameObject.activeInHierarchy) return;
        InputManager.CanTouch = false;
        gameObject.SetActive(true);
        SetOutcome(isWin);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    private void SetOutcome(bool isWin)
    {
        outcomeTexts[1].gameObject.SetActive(!isWin);
        outcomeTexts[0].gameObject.SetActive(isWin);
    }
 
}
