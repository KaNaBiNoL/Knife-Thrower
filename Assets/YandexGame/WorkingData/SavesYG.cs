
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
        public bool[] openLevels = new bool[3];

        public int PlayerMoney = 0;
        public int UnlockedLevels = 1;
        public int[] LevelScores = new int[10];
        public int LevelsScoreSum = 0;
        public int[] BoostersCount = new int[4];

        public bool[] IsItemPurchased = new bool[11];
        public int ShopNumberOfSetShuriken = 0;
        public int ShopNumberOfSetTrail = 0;
        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;

            LevelScores[0] = 0;
            LevelScores[1] = 0;
            LevelScores[2] = 0;
            LevelScores[3] = 0;
            LevelScores[4] = 0;
            LevelScores[5] = 0;
            LevelScores[6] = 0;
            LevelScores[7] = 0;

            BoostersCount[0] = 0;
            BoostersCount[1] = 0;
            BoostersCount[2] = 0;
            BoostersCount[3] = 0;

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
