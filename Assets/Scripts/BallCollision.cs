using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private PaddleMovement _paddleMovement;

    [SerializeField] private float _velocityScale;

    private bool _hasPrevCollisionInSameFrame;

    private void Start()
    {
        _hasPrevCollisionInSameFrame = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_hasPrevCollisionInSameFrame)
        {
            _velocityScale = 1f; // Default no scale at all
            if (other.tag == "Paddle" && _paddleMovement.IsMoving) _velocityScale = 1.2f;

            var dx = Mathf.Abs(transform.position.x - other.transform.position.x) - other.bounds.size.x / 2;
            var dy = Mathf.Abs(transform.position.y - other.transform.position.y) - other.bounds.size.y / 2;

            if (dx > dy)
                _ballMovement.SetVelocity(new Vector2(-_ballMovement.Velocity.x * _velocityScale, _ballMovement.Velocity.y * _velocityScale));

            if (dx < dy)
                _ballMovement.SetVelocity(new Vector2(_ballMovement.Velocity.x * _velocityScale, -_ballMovement.Velocity.y * _velocityScale));

            _hasPrevCollisionInSameFrame = true;

            StartCoroutine(ResetHasPrevCollisionInSameFrame());
        }
    }

    private IEnumerator ResetHasPrevCollisionInSameFrame()
    {
        yield return new WaitForEndOfFrame();

        _hasPrevCollisionInSameFrame = false;
    }
}
