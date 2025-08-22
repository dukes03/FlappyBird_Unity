using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject prefabPipe;
    [SerializeField] List<PipeObstacle> listPipe;
    [SerializeField] List<LayerParallux> listParallux;
    [SerializeField] int Score = 0;
    [SerializeField] Vector2 pointEnd;// Pos [End,Start]    
    [SerializeField] Vector2 pointStart;// Pos [End,Start]
    [SerializeField] float betweenPipe;// Distance between pipes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            listPipe.Add(Instantiate(prefabPipe, pointStart + Vector2.right * betweenPipe * i, new Quaternion()).GetComponent<PipeObstacle>());
            listPipe[i].pointStart = pointStart;
            listPipe[i].pointEnd = pointEnd;
            listPipe[i].betweenPipe = 3 * betweenPipe - Vector2.Distance(pointStart, pointEnd);
            listPipe[i].InitPipe();
        }
    }
    public void StopAll()
    {
        for (int i = 0; i < listPipe.Count; i++)
        {
            Tween.StopAll(listPipe[i].transform);
        }
        for (int i = 0; i < listParallux.Count; i++)
        {
            listParallux[i].StopMove(true);
        }
    }
    public void GameOver()
    {
        for (int i = 0; i < listPipe.Count; i++)
        {
            listPipe[i].FadeOut();
        }

    }
    public void Scoring()
    {
        Score += 1;
        Debug.Log(Score);
    }

}
