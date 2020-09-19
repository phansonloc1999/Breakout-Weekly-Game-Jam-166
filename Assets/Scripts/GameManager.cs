using UnityEngine;

namespace MyGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PaddleMovement _paddleMovement;

        [SerializeField] private BallMovement _ballMovement;

        [SerializeField] private BottomCollision _bottomCollision;

        [SerializeField] private BallThrowing _ballThrowing;

        private void Start()
        {
            SetupStartGame();

            _bottomCollision.OnCollisionWithBall += SetupStartGame;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                SetupStartGame();
            }
        }

        private void SetupStartGame()
        {
            _paddleMovement.GoToStartPosition();
            _ballMovement.SetPosOnTopOfPaddle();
            _ballMovement.ResetVelocity();
            _ballThrowing.gameObject.SetActive(true);
        }
    }
}