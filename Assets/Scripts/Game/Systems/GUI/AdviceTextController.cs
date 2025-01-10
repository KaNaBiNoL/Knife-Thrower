using System.Collections;
using System.Collections.Generic;
using KnifeThrower.Game;
using KnifeThrower.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace KnifeThrower
{
    public class AdviceTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _texts;
        private int _textsCount;
        private int _adviceNumber;
        
        private ILevelLostService _levelLostService;
        

        [Inject]
        public void Construct(ILevelLostService levelLostService)
        {
            _levelLostService = levelLostService;
        }

        void Start()
        {
            _textsCount = _texts.Length;
            _adviceNumber = Random.Range(0, _textsCount); 
            Debug.Log(_adviceNumber);
        }

        void Update()
        {
            if (_levelLostService.IsGameLost)
            {
                _texts[_adviceNumber].gameObject.SetActive(true);
            }
        }
    }
}