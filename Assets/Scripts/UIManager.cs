using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    enum GameState
    {
        MainMenu = 0,
        Playing = 1
    }

    public class UIManager : BaseSingeton
    {

        [SerializeField] MainMenuUI _mainMenuUI;
        [SerializeField] PauseUI _pauseUI;

        private GameState _gameState = GameState.MainMenu;

        private bool _isPaused = false;

        protected override void Awake()
        {
            base.Awake();
            Setup();
        }

        private void Setup()
        {
            _gameState = GameState.MainMenu;
            _mainMenuUI.Setup();
            _pauseUI.HideAll();
            _isPaused = false;
        }

        private void Update()
        {
            switch (_gameState) {
                case GameState.MainMenu:
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        _mainMenuUI.Show();
                    }
                    break;
                case GameState.Playing:
                    if (Input.GetKeyDown(KeyCode.Escape)){
                        OnPause();
                    }
                    break;
            }       
        }

        #region Button Event

        //----------------MAIN MENU EVENT----------------
        public void OnPlayClick()
        {
            _mainMenuUI.HideAll();
            _pauseUI.Setup();

            _gameState = GameState.Playing;
            SceneManager.LoadScene(1);
        }

        public void OnInstructionClick()
        {
            _mainMenuUI.ShowTab(Tab.Instruction);
        }

        public void OnScoreClick()
        {
            switch (_gameState)
            {
                case GameState.MainMenu:
                    _mainMenuUI.ShowTab(Tab.Score);
                    break;
                case GameState.Playing:
                    _pauseUI.ShowHighScore();
                    break;
            }
            
        }

        public void OnCreditClick()
        {
            _mainMenuUI.ShowTab(Tab.Credit);
        }
        //----------------MAIN MENU EVENT----------------


        //----------------IN GAME EVENT----------------
        public void OnPause()
        {
            _isPaused = !_isPaused;
            if (_isPaused)
            {
                _pauseUI.Show();
                Time.timeScale = 0;
            }
            else
            {
                _pauseUI.HideAll();
                StartCoroutine(ResumeGame(1f));
            }
        }

        IEnumerator ResumeGame(float timer)
        {
            yield return new WaitForSecondsRealtime(timer);
            Time.timeScale = 1f;
        }

        public void OnExitToMainMenu()
        {
            Setup();
            SceneManager.LoadScene(0);
        }
        //----------------IN GAME EVENT----------------


        //BOTH
        public void OnExitGameClick()
        {
            Application.Quit();
        }

        #endregion
    }
}