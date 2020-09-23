using UnityEngine;

namespace MyGame
{
    [ExecuteInEditMode]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PaddleMovement _paddleMovement;

        [SerializeField] private BallMovement _ballMovement;

        [SerializeField] private BottomCollision _bottomCollision;

        [SerializeField] private BallThrowing _ballThrowing;

        private void Start()
        {
            SetupPaddleAndBall();

            _bottomCollision.OnCollisionWithBall += SetupPaddleAndBall;

            _ballThrowing.OnThrownBall += ReEnablePaddleMovement;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                SetupPaddleAndBall();
            }
        }

        private void SetupPaddleAndBall()
        {
            _paddleMovement.GoToStartPosition();
            _ballMovement.SetPosOnTopOfPaddle();
            _ballMovement.ResetVelocity();
            _ballThrowing.gameObject.SetActive(true);
            _paddleMovement.SetEnabled(false);
            _paddleMovement.SetEnabled(false);
        }

        public void ReEnablePaddleMovement()
        {
            _paddleMovement.SetEnabled(true);
        }
    }
}