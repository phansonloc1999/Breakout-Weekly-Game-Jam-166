using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowDirectionArrow : MonoBehaviour
{
    [SerializeField] private Vector2 _mousePointingDirection;

    public Vector2 MousePointingDirection { get => _mousePointingDirection; set => _mousePointingDirection = value; }

    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private BallThrowDirectionArrow _directionArrow;

    [SerializeField] private float _initialBallVelocityVectorLength;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        MousePointingDirection = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        ).normalized;

        transform.up = MousePointingDirection;

        transform.parent.up = MousePointingDirection;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _ballMovement.SetVelocity(_directionArrow.MousePointingDirection * _initialBallVelocityVectorLength);

            this.enabled = false;
            _directionArrow.CleanUp();
        }
    }

    public void CleanUp()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.parent.rotation = new Quaternion(0, 0, 0, 0);

        gameObject.SetActive(false);
    }
}
