using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private PaddleMovement _paddleMovement;

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
        var otherGameObjectSpriteSize = other.GetComponent<SpriteRenderer>().sprite.bounds.size;

        var contactPoints = new ContactPoint2D[1];
        other.GetContacts(contactPoints);

        if (contactPoints[0].point.y >= other.transform.position.y + otherGameObjectSpriteSize.y / 2)
        {
            if (other.tag == "Paddle")
            {
                float velocityScale = 1f;
                if (_paddleMovement.IsMoving) velocityScale = 2.0f;

                _ballMovement.SetVelocity(new Vector2(_ballMovement.Velocity.x * velocityScale, -_ballMovement.Velocity.y * velocityScale));
            }
        }
    }
}
