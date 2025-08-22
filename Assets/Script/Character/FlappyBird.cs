using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    [SerializeField] private float mass = 100;
    [SerializeField] private float gravity = 10;
    [SerializeField] private float velocityFly = 7.5f;
    [SerializeField] private List<GameObject> Hand;//List = [HandFront,  HandBack] 
    private float timeFallState;
    Tween tween;
    bool isAlive = true;

    private Rigidbody2D rigidbody2D;

    public void Init()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Physics2D.gravity = Vector2.down * gravity;
        rigidbody2D.mass = mass;
        timeFallState = velocityFly / gravity;
        rigidbody2D.linearVelocityY = velocityFly;
        isAlive = true;
    }
    public void FlyInto()
    {
        Tween.StopAll(transform);
        transform.position = new Vector2(-5, 1.3f);
        tween = Tween.Position(transform, new Vector2(-1.9f, 0), 1f, Ease.InOutQuad).OnComplete(Init);
        Tween.Rotation(transform, endValue: new Vector3(0f, 0f, 0f), duration: 0.5f);
    }
    public void Fly()
    {
        if (isAlive)
        {
            SoundManager.instance.PlaySound("jump", 0);
            rigidbody2D.linearVelocityY = velocityFly;
            tweenRotation(15, timeFallState).OnComplete(Fall);
        }

    }
    public void Fall()
    {
        // Tween.Rotation(transform, endValue: new Vector3(0f, 0f, -90f), duration: timeFallState);
        tweenRotation(-90, timeFallState * 3);
    }
    public Tween tweenRotation(int rotationZ, float duration)
    {
        Stoptween();
        tween = Tween.Rotation(transform, endValue: new Vector3(0f, 0f, rotationZ), duration: duration);
        return tween;
    }
    public void Stoptween()
    {
        if (tween.isAlive)
            tween.Stop();
    }
    public void Dead()
    {
        Stoptween();
        GameManager.instance.StopAll();
        Physics2D.gravity = Vector2.zero;
        rigidbody2D.linearVelocityY = 0;
        isAlive = false;
        SoundManager.instance.PlaySound("hurt", 0);
        Tween.Delay(duration: 0.5f, () =>
       {
           SoundManager.instance.PlaySound("laser", 0);
           Tween.PositionY(transform, endValue: transform.position.y + 2, duration: 1, ease: Ease.InOutSine).OnComplete(() => Tween.PositionY(transform, endValue: -6, duration: 2, ease: Ease.InOutSine)); SoundManager.instance.PlaySound("laser", 0); ;
           // Rotate 'transform' from the current rotation to (0, 90, 0) in 1 second
           Tween.Rotation(transform, endValue: Quaternion.Euler(0, 0, 180), duration: 0.75f).OnComplete(() => GameManager.instance.GameOver());
       }
        );


    }
    public void ReSpawn()
    {
        Stoptween();
        Init();
        Tween.SetPausedAll(true, onTarget: transform);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (isAlive && collision.tag == "Obstacles")
        {
            Dead();
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (isAlive && collision.tag == "Score")
        {
            SoundManager.instance.PlaySound("pickup", 0);
            GameManager.instance.Scoring();
        }
    }
}
