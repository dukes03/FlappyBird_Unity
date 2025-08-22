using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextScore;
    [SerializeField] TextMeshProUGUI TextHighScore;
    [SerializeField] Button buttonMenu;
    [SerializeField] Button buttonRestart;

    void Start()
    {
        buttonMenu.onClick.AddListener(UIManager.instance.OpenMenu);
        if (buttonRestart != null)
        {
            buttonRestart.onClick.AddListener(UIManager.instance.InGame);
        }
    }

    public void ShowScore()
    {
        if (TextScore != null)
        {
            TextScore.text = GameManager.instance.GetScore().ToString();
        }
    }
    public void ShowTextHighScore()
    {
        if (TextHighScore != null)
        {
            TextHighScore.text = GameManager.instance.GetHighScore().ToString();
        }
    }
    public void ShowPanel(bool IsShow)
    {
        gameObject.SetActive(IsShow);
    }
}
