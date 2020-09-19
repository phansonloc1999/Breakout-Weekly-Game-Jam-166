using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private PaddleMovement _paddleMovement;

    [Header("Velocity Scaling")]
    [SerializeField] private float _lastVelocityScale;
    [SerializeField] private float _speedUpVelocityScale;
    [SerializeField] private float _slowDownVelocityScale;

    [SerializeField] private BoxCollider2D _paddleCenterCollider;

    [SerializeField] private BoxCollider2D _paddleOuterCollider;

    [SerializeField] private Transform _paddleTransform;

    private bool _hasPrevCollisionInSameFrame;

    private void Start()
    {
        _hasPrevCollisionInSameFrame = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_hasPrevCollisionInSameFrame && other.tag != "Bottom")
        {
            _lastVelocityScale = 1.0f; // Default no scale at all

            var dx = 0f;
            var dy = 0f;

            if (other.tag == "PaddleOuter" || other.tag == "PaddleCenter")
            {
                if (other.tag == "PaddleOuter" && _paddleMovement.IsMoving) _lastVelocityScale = _speedUpVelocityScale;
                if (other.tag == "PaddleCenter") _lastVelocityScale = _slowDownVelocityScale;

                dx = Mathf.Abs(transform.position.x - _paddleTransform.position.x) - (_paddleOuterCollider.bounds.size.x * 2 + _paddleCenterCollider.bounds.size.x) / 2;
                dy = Mathf.Abs(transform.position.y - _paddleTransform.position.y) - (_paddleOuterCollider.bounds.size.y + _paddleCenterCollider.bounds.size.y) / 2;
            }
            else
            {
                dx = Mathf.Abs(transform.position.x - other.transform.position.x) - other.bounds.size.x / 2;
                dy = Mathf.Abs(transform.position.y - other.transform.position.y) - other.bounds.size.y / 2;
            }

            if (dx > dy)
            {
                SideBouncing();
            }

            if (dx < dy)
            {
                TopBottomBouncing();
            }

            _hasPrevCollisionInSameFrame = true;

            StartCoroutine(ResetHasPrevCollisionInSameFrame());
        }
    }

    private IEnumerator ResetHasPrevCollisionInSameFrame()
    {
        yield return new WaitForEndOfFrame();

        _hasPrevCollisionInSameFrame = false;
    }

    private void SideBouncing()
    {
        _ballMovement.SetVelocity(new Vector2(-_ballMovement.Velocity.x * _lastVelocityScale, _ballMovement.Velocity.y * _lastVelocityScale));
    }

    private void TopBottomBouncing()
    {
        _ballMovement.SetVelocity(new Vector2(_ballMovement.Velocity.x * _lastVelocityScale, -_ballMovement.Velocity.y * _lastVelocityScale));
    }
}
