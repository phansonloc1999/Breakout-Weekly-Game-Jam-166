using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollision : MonoBehaviour
{
    public delegate void CollisionWithBallHandler();
    public event CollisionWithBallHandler OnCollisionWithBall;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            OnCollisionWithBall?.Invoke();
        }
    }
}
