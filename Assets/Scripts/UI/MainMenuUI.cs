using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public enum Tab
    {
        Instruction = 0,
        Score = 1,
        Credit = 2,
    }

    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] GameObject _buttonField;
        [SerializeField] GameObject _tabField;
        [SerializeField] List<GameObject> _lstTabs;

        private bool _isShowTab = false;

        public void Setup()
        {
            gameObject.SetActive(true);
            _isShowTab = false;
            _buttonField.SetActive(true);
            _tabField.SetActive(false);
        }

        public void Show()
        {
            if (_isShowTab)
            {
                _isShowTab = false;
                _buttonField.SetActive(true);
                _tabField.SetActive(false);
            }
        }

        public void HideAll()
        {
            gameObject.SetActive(false);
        }

        private void HideButton()
        {
            _buttonField.SetActive(false);
        }


        public void ShowTab(Tab tabName)
         {
            _tabField.SetActive(true);
            _isShowTab = true;

            HideButton();
            ChangeTab(tabName);
        }

        private void ChangeTab(Tab tabName)
        {
            foreach(var tab in _lstTabs)
            {
                tab.SetActive(false);
            }
            _lstTabs[(int)tabName].SetActive(true);
        }
    }
}