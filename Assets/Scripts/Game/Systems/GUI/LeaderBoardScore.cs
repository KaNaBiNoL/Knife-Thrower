using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace KnifeThrower
{
    public class LeaderBoardScore : MonoBehaviour
    {
        public int WholeGameScore { get; set; }
        void Start()
        {
            SetScoreInLB();
        }

        private void SetScoreInLB()
        {
            for (int i = 0; i < YandexGame.savesData.ScoreOnLevel.Length; i++)
            {
                WholeGameScore += YandexGame.savesData.ScoreOnLevel[i];
            }

            if (WholeGameScore > YandexGame.savesData.LevelsScoreSum)
            {
                YandexGame.NewLeaderboardScores("Leaders", WholeGameScore);
                YandexGame.savesData.LevelsScoreSum = WholeGameScore;
                YandexGame.SaveProgress();
            }
            
        }
    }
}
