
using UnityEngine.Serialization;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[27];
        
        public int PlayerMoney = 0;
        public int UnlockedLevels = 1;
        public int[] ScoreOnLevel = new int[60];
        public int LevelsScoreSum = 0;
        public int[] BoostersCount = new int[4];
        public int AddedBoosterCount;

        public bool[] IsItemPurchased = new bool[11];
        public int ShopNumberOfSetShuriken = 0;
        public int ShopNumberOfSetTrail = 0;

        public int AdsCounter = 0;

        public float GlobalVolumeValue = 0.5f;
        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;

            ScoreOnLevel[0] = 0;
            ScoreOnLevel[1] = 0;
            ScoreOnLevel[2] = 0;
            ScoreOnLevel[3] = 0;
            ScoreOnLevel[4] = 0;
            ScoreOnLevel[5] = 0;
            ScoreOnLevel[6] = 0;
            ScoreOnLevel[7] = 0;
            ScoreOnLevel[8] = 0;
            ScoreOnLevel[9] = 0;
            ScoreOnLevel[10] = 0;
            ScoreOnLevel[11] = 0;
            ScoreOnLevel[12] = 0;
            ScoreOnLevel[13] = 0;
            ScoreOnLevel[14] = 0;
            ScoreOnLevel[15] = 0;
            ScoreOnLevel[16] = 0;
            ScoreOnLevel[17] = 0;
            ScoreOnLevel[18] = 0;
            ScoreOnLevel[19] = 0;
            ScoreOnLevel[20] = 0;
            ScoreOnLevel[21] = 0;
            ScoreOnLevel[22] = 0;
            ScoreOnLevel[23] = 0;
            ScoreOnLevel[24] = 0;
            ScoreOnLevel[25] = 0;
            ScoreOnLevel[26] = 0;
            ScoreOnLevel[27] = 0;
            ScoreOnLevel[28] = 0;
            ScoreOnLevel[29] = 0;
            ScoreOnLevel[30] = 0;
            ScoreOnLevel[31] = 0;
            ScoreOnLevel[32] = 0;
            ScoreOnLevel[33] = 0;
            

            BoostersCount[0] = 1;
            BoostersCount[1] = 1;
            BoostersCount[2] = 1;
            BoostersCount[3] = 1;
            AddedBoosterCount = 1;

            IsItemPurchased[0] = true;
            IsItemPurchased[1] = false;
            IsItemPurchased[2] = false;
            IsItemPurchased[3] = false;
            IsItemPurchased[4] = false;
            IsItemPurchased[5] = false;
            IsItemPurchased[6] = true;
            IsItemPurchased[7] = false;
            IsItemPurchased[8] = false;
            IsItemPurchased[9] = false;
            IsItemPurchased[10] = false;

        }
    }
}
