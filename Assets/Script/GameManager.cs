using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject prefabPipe;
    [SerializeField] List<PipeObstacle> listPipe;
    [SerializeField] List<LayerParallux> listParallux;
    [SerializeField] int Score = 0;
    [SerializeField] int HighScore = 0;
    [SerializeField] Vector2 pointEnd;// Pos [End,Start]    
    [SerializeField] Vector2 pointStart;// Pos [End,Start]
    [SerializeField] float betweenPipe;// Distance between pipes
    [SerializeField] FlappyBird flappyBird;
    void Start()
    {

        flappyBird.gameObject.SetActive(false);
        listParalluxStopMove(true);
    }
    public void StartGame()
    {
        Score = 0;
        UIManager.instance.InGame();
        flappyBird.gameObject.SetActive(true);
        flappyBird.FlyInto();
        for (int i = 0; i < 3; i++)
        {
            listPipe.Add(Instantiate(prefabPipe, pointStart + Vector2.right * betweenPipe * i, new Quaternion()).GetComponent<PipeObstacle>());
            listPipe[i].pointStart = pointStart;
            listPipe[i].pointEnd = pointEnd;
            listPipe[i].betweenPipe = 3 * betweenPipe - Vector2.Distance(pointStart, pointEnd);
            listPipe[i].InitPipe();
        }
        listParalluxStopMove(false);
    }
    public void StopAll()
    {
        for (int i = 0; i < listPipe.Count; i++)
        {
            Tween.StopAll(listPipe[i].transform);
        }
        listParalluxStopMove(true);
    }
    private void listParalluxStopMove(bool _bool)
    {
        for (int i = 0; i < listParallux.Count; i++)
        {
            listParallux[i].StopMove(_bool);
        }
    }
    public void GameOver()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
        }
        UIManager.instance.OpenGameOver();
        for (int i = 0; i < listPipe.Count; i++)
        {
            listPipe[i].FadeOut();
        }
        listPipe = new List<PipeObstacle>();

    }
    public void Scoring()
    {
        Score += 1;
        UIManager.instance.UpdateScoreInGame(Score);
    }
    public int GetScore()
    {
        return Score;
    }
    public int GetHighScore()
    {
        return HighScore;
    }

}
