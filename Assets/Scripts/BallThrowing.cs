using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowing : MonoBehaviour
{
    [SerializeField] private Vector2 _mousePointingDirection;

    public Vector2 MousePointingDirection { get => _mousePointingDirection; set => _mousePointingDirection = value; }

    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private BallThrowing _directionArrow;

    [SerializeField] private float _initialBallVelocityVectorLength;

    [SerializeField] private BallCollision _ballCollision;

    public delegate void ThrowingBallCompleteHandler();

    public event ThrowingBallCompleteHandler OnThrowingBallComplete;

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

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _ballMovement.SetVelocity(_directionArrow.MousePointingDirection * _initialBallVelocityVectorLength);

            _directionArrow.CleanUp();

            OnThrowingBallComplete?.Invoke();
        }
    }

    public void CleanUp()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.parent.rotation = new Quaternion(0, 0, 0, 0);

        gameObject.SetActive(false);
    }
}
