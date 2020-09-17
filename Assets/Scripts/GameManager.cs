using UnityEngine;

namespace MyGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PaddleMovement _paddleMovement;

        [SerializeField] private BallMovement _ballMovement;

        private void Start()
        {
            SetupStartGame();
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
        }
    }
}