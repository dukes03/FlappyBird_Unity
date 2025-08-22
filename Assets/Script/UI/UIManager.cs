using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] ScorePanel HighScorePanel;
    [SerializeField] ScorePanel GameOverPanel;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject InGamePanel;
    [SerializeField] TextMeshProUGUI TextScoreInGame;
    public void UpdateScoreInGame(int score)
    {
        TextScoreInGame.text = score.ToString();
    }
    public void OpenMenu()
    {
        GameManager.instance.LogoIn();
        OpnePanel(UIManager.UI_State.Menu);
    }
    public void InGame()
    {
        OpnePanel(UIManager.UI_State.InGame);
        UpdateScoreInGame(0);
    }
    public void OpenHighScore()
    {
        GameManager.instance.LogoOut();
        OpnePanel(UIManager.UI_State.HighScore);
    }
    public void OpenGameOver()
    {
        OpnePanel(UIManager.UI_State.GameOver);
    }

    public void OpnePanel(UIManager.UI_State uI_State)
    {
        SoundManager.instance.PlaySound("pickup", 0);
        HighScorePanel.ShowPanel(false);
        GameOverPanel.ShowPanel(false);
        MenuPanel.SetActive(false);
        InGamePanel.SetActive(false);
        switch (uI_State)
        {
            case UI_State.InGame:
                InGamePanel.SetActive(true);
                break;
            case UI_State.Menu:
                MenuPanel.SetActive(true);
                break;
            case UI_State.GameOver:
                GameOverPanel.ShowPanel(true);
                GameOverPanel.ShowScore();
                GameOverPanel.ShowTextHighScore();
                break;
            case UI_State.HighScore:
                HighScorePanel.ShowPanel(true);
                HighScorePanel.ShowTextHighScore();
                break;
            default:
                break;
        }
    }

    public enum UI_State
    {
        Menu,
        InGame,
        GameOver,
        HighScore
    }
}
