using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class OpenLevelController : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;

        void Awake()
        {
            PlayerPrefs.DeleteAll();
            int unlockedLevel = YandexGame.savesData.UnlockedLevels;
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].interactable = false;
            }

            for (int i = 0; i < unlockedLevel; i++)
            {
                _buttons[i].interactable = true;
            }

            Debug.Log($"Unlocked level int = {unlockedLevel}");
        }

        
    }
}