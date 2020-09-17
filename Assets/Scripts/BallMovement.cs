using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _velocity;

    [SerializeField] private Transform _paddleTransform;

    [SerializeField] private float _yOffsetToPaddle;

    public Vector2 Velocity { get => _velocity; set => _velocity = value; }

    private void Start()
    {
        GoToPaddle();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + Velocity.x * Time.deltaTime, transform.position.y + Velocity.y * Time.deltaTime, transform.position.z);
    }

    public void SetVelocity(Vector2 newVelocity)
    {
        Velocity = newVelocity;
    }

    public void GoToPaddle()
    {
        transform.position = new Vector3(_paddleTransform.position.x, _paddleTransform.position.y + _yOffsetToPaddle, transform.position.z);
    }
}