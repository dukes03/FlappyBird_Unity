using UnityEngine;
using PrimeTween;
public class PipeObstacle : MonoBehaviour
{
    [SerializeField] GameObject toppipe;
    [SerializeField] float gap; // Distance between top and bottom
    public float betweenPipe;// Distance between pipes
    [SerializeField] float height;//Height of the gap, measured from the center
    public Vector2 rangeRnd;// Random height range [min,max]
    public Vector2 pointEnd;// Pos [End,Start]    
    public Vector2 pointStart;// Pos [End,Start]
    public float speed = 2;
    public void InitPipe()
    {
        height = Random.Range(rangeRnd.x, rangeRnd.y);
        transform.position += Vector3.up * height;
        toppipe.transform.localPosition = new Vector2(0, 6.29f + gap);
        Tween.PositionX(transform, pointEnd.x, Getduration(), Ease.Linear).OnComplete(() => ReInitPipe());
    }
    public void ReInitPipe()
    {
        transform.position = new Vector2(pointStart.x + betweenPipe, 0); ;
        toppipe.transform.localPosition = new Vector2(0, 6.29f);
        Tween.Delay(0.1f, () => InitPipe());

    }
    private float Getduration()
    {
        return Vector2.Distance(transform.position, new Vector2(pointEnd.x, transform.position.y)) / speed;
    }

    public void FadeOut()
    {
        Tween.StopAll(transform);
        Tween.PositionY(transform, -12, 1f);
        Tween.PositionY(toppipe.transform, 24, 1.2f).OnComplete(() => Destroy(this.gameObject));
    }
}
