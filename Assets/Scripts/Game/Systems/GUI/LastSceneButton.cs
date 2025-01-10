using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KnifeThrower
{
    public class LastSceneButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OpenMenu);
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OpenMenu()
        {
            SceneManager.LoadScene(1);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OpenMenu);
        }
    }
}
