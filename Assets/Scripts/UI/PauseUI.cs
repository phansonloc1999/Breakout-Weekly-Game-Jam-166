using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] GameObject _buttonField;
        [SerializeField] GameObject _hightScoreField;

        public void Setup()
        {
            gameObject.SetActive(false);
            _buttonField.SetActive(true);
            _hightScoreField.SetActive(false);
        }
        public void Show()
        {
            gameObject.SetActive(true);
            _buttonField.SetActive(true);
            _hightScoreField.SetActive(false);
        }

        public void HideAll()
        {
            gameObject.SetActive(false);
        }

        public void ShowHighScore()
        {
            _buttonField.SetActive(false);
            _hightScoreField.SetActive(true);
        }
    }
}