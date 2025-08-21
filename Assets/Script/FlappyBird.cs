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

    private Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Physics2D.gravity = Vector2.down * gravity;
        rigidbody2D.mass = mass;
        timeFallState = velocityFly / gravity;
    }
    public void Fly()
    {
        rigidbody2D.linearVelocityY = velocityFly;
        tweenRotation(15, timeFallState).OnComplete(() => Fall());
    }
    public void Fall()
    {
        Tween.Rotation(transform, endValue: new Vector3(0f, 0f, -90f), duration: timeFallState);
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
}
