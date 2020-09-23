using UnityEngine;

public class PaddleRootInteraction : MonoBehaviour
{
    [SerializeField] private BallCollision _ballCollision;

    [SerializeField] private BallMovement _ballMovement;

    [SerializeField] private GameObject _throwDirectionArrow;

    [SerializeField] private PaddleMovement _paddleMovement;

    [SerializeField] private BallThrowing _ballThrowing;

    [SerializeField] private SuperRabbit _superRabbit;

    [SerializeField] private int MAX_OCCURANCE_TIMES;

    private bool _isActive;

    public bool IsActive { get => _isActive; set => _isActive = value; }

    private int _occuranceTimesLeft;

    private void Start()
    {
        _isActive = false;

        _ballCollision.OnCollidedWithRootBrick += Begin;
        _ballCollision.OnCollidedWithPaddle += Setup;
        _ballThrowing.OnThrownBall += CleanUp;
    }

    private void Setup()
    {
        if (_isActive && _occuranceTimesLeft > 0)
        {
            _ballMovement.SetVelocity(Vector2.zero);
            _ballMovement.SetPosOnTopOfPaddle();
            _throwDirectionArrow.SetActive(true);
            _paddleMovement.SetEnabled(false);

            _superRabbit.StopMoving();

            _occuranceTimesLeft--;
        }
    }

    private void CleanUp()
    {
        if (IsActive)
        {
            _throwDirectionArrow.SetActive(false);
            _paddleMovement.SetEnabled(true);

            if (_occuranceTimesLeft <= 0) End();
        }
    }

    private void Begin()
    {
        _isActive = true;
        _occuranceTimesLeft = 5;
    }

    private void End()
    {
        _isActive = false;
    }
}