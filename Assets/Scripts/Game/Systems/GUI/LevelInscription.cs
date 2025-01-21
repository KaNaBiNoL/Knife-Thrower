using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace KnifeThrower
{
    public class LevelInscription : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        void Start()
        {
            switch (YandexGame.EnvironmentData.language)
            {
                case "ru":
                    _text.text = $"Уровень {SceneManager.GetActiveScene().buildIndex - 1}";
                    break;
                case "en":
                    _text.text = $"Level {SceneManager.GetActiveScene().buildIndex - 1}";
                    break;
                case "tr":
                    _text.text = $"Seviye {SceneManager.GetActiveScene().buildIndex - 1}";
                    break;
                case "de":
                    _text.text = $"Level {SceneManager.GetActiveScene().buildIndex - 1}";
                    break;
                case "es":
                    _text.text = $"Nivel {SceneManager.GetActiveScene().buildIndex - 1}";
                    break;
            }
        }

        
    }
}
