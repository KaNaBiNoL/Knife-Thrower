using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class DataText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _level12RecordText;
        [SerializeField] private TextMeshProUGUI _level15RecordText;
        [SerializeField] private TextMeshProUGUI _level16RecordText;
        
        
        void Start()
        {
            ShowTextData();
        }

        private void ShowTextData()
        {
            _text.text =
                $"Level1 = {YandexGame.savesData.ScoreOnLevel[1]};Level2 = {YandexGame.savesData.ScoreOnLevel[2]};" +
                $"Level3 = {YandexGame.savesData.ScoreOnLevel[3]};Level4 = {YandexGame.savesData.ScoreOnLevel[4]};" +
                $"Level5 = {YandexGame.savesData.ScoreOnLevel[5]};Level6 = {YandexGame.savesData.ScoreOnLevel[6]};" +
                $"Level7 = {YandexGame.savesData.ScoreOnLevel[7]};Level8 = {YandexGame.savesData.ScoreOnLevel[8]};" +
                $"Level9 = {YandexGame.savesData.ScoreOnLevel[9]};Level10 = {YandexGame.savesData.ScoreOnLevel[10]};" +
                $"Level11 = {YandexGame.savesData.ScoreOnLevel[11]};Level12 = {YandexGame.savesData.ScoreOnLevel[12]};" +
                $"Level13 = {YandexGame.savesData.ScoreOnLevel[13]};Level14 = {YandexGame.savesData.ScoreOnLevel[14]};" +
                $"Level15 = {YandexGame.savesData.ScoreOnLevel[15]};Level16 = {YandexGame.savesData.ScoreOnLevel[16]};" +
                $"Level17 = {YandexGame.savesData.ScoreOnLevel[17]};Level18 = {YandexGame.savesData.ScoreOnLevel[18]};" +
                $"Level19 = {YandexGame.savesData.ScoreOnLevel[19]};Level20 = {YandexGame.savesData.ScoreOnLevel[20]};" +
                $"Level21 = {YandexGame.savesData.ScoreOnLevel[21]};Level22 = {YandexGame.savesData.ScoreOnLevel[22]};" +
                $"Level23 = {YandexGame.savesData.ScoreOnLevel[23]};Level24 = {YandexGame.savesData.ScoreOnLevel[24]};" +
                $"Level25 = {YandexGame.savesData.ScoreOnLevel[25]};Level26 = {YandexGame.savesData.ScoreOnLevel[26]};" +
                $"Level27 = {YandexGame.savesData.ScoreOnLevel[27]};  Level 12 Button Text {_level12RecordText.text};" +
                $" Level 15 Button Text {_level15RecordText.text}; Level 16 Button Text {_level16RecordText.text}]";
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
