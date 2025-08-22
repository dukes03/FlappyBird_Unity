using PrimeTween;
using UnityEngine;

public class BgParallux : MonoBehaviour
{
    private Vector2 startPos;
    private float endPos = -14;
    private float speed = 2;
    private Tween tween;

    public void SetupBgParallux(Vector2 _startPos, float _endPos, float _speed)
    {
        startPos = _startPos;
        endPos = _endPos;
        speed = _speed;
        StartMove();
    }
    private void StartMove()
    {
        tween = Tween.PositionX(transform, endValue: endPos, duration: Getduration(), Ease.Linear);
        tween.OnComplete(() => ResetParallux());
    }
    private void ResetParallux()
    {
        transform.position = new Vector2(startPos.x, transform.position.y);
        StartMove();
    }
    private float Getduration()
    {
        return Vector2.Distance(transform.position, new Vector2(endPos, transform.position.y)) / speed;
    }
    public void StopMove(bool IsStop)
    {
        tween.isPaused = IsStop;
    }

}
