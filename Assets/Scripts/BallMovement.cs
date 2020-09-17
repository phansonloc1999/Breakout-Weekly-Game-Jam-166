using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector2 _velocity;

    private void Start()
    {
        _velocity = new Vector2(0, -2);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + _velocity.x * Time.deltaTime, transform.position.y + _velocity.y * Time.deltaTime, transform.position.z);
    }

    public void SetVelocity(Vector2 newVelocity)
    {
        _velocity = newVelocity;
    }
}