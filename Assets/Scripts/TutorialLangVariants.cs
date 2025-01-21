using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class TutorialLangVariants : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private Image _image;
        
        
        void Start()
        {
            switch (YandexGame.EnvironmentData.language)
            {
                case "ru":
                    _image.sprite = _sprites[0];
                    break;
                case "en":
                    _image.sprite = _sprites[1];
                    break;
                case "tr":
                    _image.sprite = _sprites[2];
                    break;
                case "de":
                    _image.sprite = _sprites[3];
                    break;
                case "es":
                    _image.sprite = _sprites[4];
                    break;
            }
        }

        
    }
}
