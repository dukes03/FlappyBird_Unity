using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class LayerParallux : MonoBehaviour
{
    public List<GameObject> listParallux;
    public Vector2 startPos;
    public float endPos = -14;
    public float speed = 2;
    private List<Tween> tween = new List<Tween>();
    void Start()
    {
        for (int i = 0; i < listParallux.Count; i++)
        {
            initStartMove(i);
        }

    }

    private void initStartMove(int index)
    {
        tween.Add(Tween.PositionX(listParallux[index].transform, endValue: endPos, duration: Getduration(index), Ease.Linear));
        tween[index].OnComplete(() => ResetParallux(index));
    }
    private void StartMove(int index)
    {
        tween[index] = Tween.PositionX(listParallux[index].transform, endValue: endPos, duration: Getduration(index), Ease.Linear);
        tween[index].OnComplete(() => ResetParallux(index));
    }
    private void ResetParallux(int index)
    {
        listParallux[index].transform.position = new Vector2(startPos.x, listParallux[index].transform.position.y);
        StartMove(index);
    }
    private float Getduration(int index)
    {
        return Vector2.Distance(listParallux[index].transform.position, new Vector2(endPos, transform.position.y)) / speed;
    }
    public void StopMove(bool IsStop)
    {
        foreach (Tween item in tween)
        {
            item.isPaused = IsStop;
        }
    }
}