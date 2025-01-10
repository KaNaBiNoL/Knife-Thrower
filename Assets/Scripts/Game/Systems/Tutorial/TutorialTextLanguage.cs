using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class TutorialTextLanguage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _startBlockText;
        [SerializeField] private TextMeshProUGUI _secondBlockText;
        
        
        void Start()
        {
            if (YandexGame.EnvironmentData.isDesktop)
            {
                switch (YandexGame.EnvironmentData.language)
                {
                    case "ru":
                        _startBlockText.text = "Нажмите левой кнопкой мыши на сюрикен. Не отпускайте кнопку.";
                        _secondBlockText.text = "Проведите мышью в нужную сторону и отпустите кнопку для броска";
                        break;
                    case "en":
                        _startBlockText.text = "Left-click on the shuriken. Do not release the button";
                        _secondBlockText.text = "Swipe the mouse in the right direction and release the button to throw";
                        break;
                    case "tr":
                        _startBlockText.text = "Shuriken'e sol fare düğmesiyle tıklayın. Düğmeyi bırakmayın";
                        _secondBlockText.text = "Fareyi doğru yönde kaydırın ve atmak için düğmeyi bırakın";
                        break;
                    case "de":
                        _startBlockText.text = "Klicken Sie mit der linken Maustaste auf den Shuriken. Lassen Sie den Knopf nicht los";
                        _secondBlockText.text = "Streichen Sie mit der Maus in die richtige Richtung und lassen Sie die Taste los, um zu werfen";
                        break;
                    case "es":
                        _startBlockText.text = "Haga clic en Shuriken con el botón izquierdo del ratón. No suelte el botón";
                        _secondBlockText.text = "Pase el ratón en la dirección correcta y suelte el botón para lanzar";
                        break;
                }
            }
            else
            {
                switch (YandexGame.EnvironmentData.language)
                {
                    case "ru":
                        _startBlockText.text = "Нажмите пальцем на сюрикен. Не отпускайте палец.";
                        _secondBlockText.text = "Проведите в нужную сторону и отпустите палец для броска";
                        break;
                    case "en":
                        _startBlockText.text = "Tap the shuriken with your finger. Don't release your finger";
                        _secondBlockText.text = "Swipe in the right direction and release your finger to throw";
                        break;
                    case "tr":
                        _startBlockText.text = "Parmağınızı shuriken'e bastırın. Parmağınızı bırakmayın.";
                        _secondBlockText.text = "Doğru yöne kaydırın ve atmak için parmağınızı bırakın";
                        break;
                    case "de":
                        _startBlockText.text = "Drücken Sie mit dem Finger auf den Shuriken. Lassen Sie Ihren Finger nicht los.";
                        _secondBlockText.text = "Streichen Sie in die richtige Richtung und lassen Sie den Finger zum Werfen los";
                        break;
                    case "es":
                        _startBlockText.text = "Toque el dedo en el Shuriken. No sueltes el dedo.";
                        _secondBlockText.text = "Deslice en la dirección deseada y suelte el dedo para lanzar";
                        break;
                }
            }

        }

        
        
    }
}
