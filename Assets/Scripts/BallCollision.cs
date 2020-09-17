using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private PaddleMovement _paddleMovement;

    [SerializeField] private float _velocityScale;

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
        _velocityScale = 1f; // Default is no scale at all
        if (other.tag == "Paddle" && _paddleMovement.IsMoving) _velocityScale = 1.2f;

        var dx = Mathf.Abs(transform.position.x - other.transform.position.x) - other.bounds.size.x / 2;
        var dy = Mathf.Abs(transform.position.y - other.transform.position.y) - other.bounds.size.y / 2;

        if (dx > dy)
            _ballMovement.SetVelocity(new Vector2(-_ballMovement.Velocity.x * _velocityScale, _ballMovement.Velocity.y * _velocityScale));

        if (dx < dy)
            _ballMovement.SetVelocity(new Vector2(_ballMovement.Velocity.x * _velocityScale, -_ballMovement.Velocity.y * _velocityScale));
    }
}
