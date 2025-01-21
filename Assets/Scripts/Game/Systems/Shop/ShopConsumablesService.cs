using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class ShopConsumablesService : MonoBehaviour
    {

        [SerializeField] private Button _buyFirstBoosterButton;
        [SerializeField] private Button _buySecondBoosterButton;
        [SerializeField] private Button _buyThirdBoosterButton;
        [SerializeField] private Button _buyFourthBoosterButton;
        [SerializeField] private Button _buyFifthBoosterButton;
        [SerializeField] private TextMeshProUGUI _firstBoosterPriceText;
        [SerializeField] private TextMeshProUGUI _secondBoosterPriceText;
        [SerializeField] private TextMeshProUGUI _thirdBoosterPriceText;
        [SerializeField] private TextMeshProUGUI _fourthBoosterPriceText;
        [SerializeField] private TextMeshProUGUI _fifthBoosterPriceText;
        [SerializeField] private TextMeshProUGUI _firstBoosterCountText;
        [SerializeField] private TextMeshProUGUI _secondBoosterCountText;
        [SerializeField] private TextMeshProUGUI _thirdBoosterCountText;
        [SerializeField] private TextMeshProUGUI _fourthBoosterCountText;
        [SerializeField] private TextMeshProUGUI _fifthBoosterCountText;
        [SerializeField] private TextMeshProUGUI _PlayerCashText;

        private int _firstBoosterCount;
        private int _secondBoosterCount;
        private int _thirdBoosterCount;
        private int _fourthBoosterCount;
        private int _fifthBoosterCount;

        private int _firstBoosterPrice = 30;
        private int _secondBoosterPrice = 50;
        private int _thirdBoosterPrice = 80;
        private int _fourthBoosterPrice = 120;
        private int _fifthBoosterPrice = 150;

        public static int PlayerCash
        {
            get;
            set;
        }

        private void OnEnable()
        {
            _buyFirstBoosterButton.onClick.AddListener(FirstBoosterBuy);
            _buySecondBoosterButton.onClick.AddListener(SecondBoosterBuy);
            _buyThirdBoosterButton.onClick.AddListener(ThirdBoosterBuy);
            _buyFourthBoosterButton.onClick.AddListener(FourthBoosterBuy);
            _buyFifthBoosterButton.onClick.AddListener(FifthBoosterBuy);
            CosmeticShop.IsPurchaseDone.AddListener(CheckInteractible);
        }

        

        

        private void Awake()
        {
            _firstBoosterCount = YandexGame.savesData.BoostersCount[0];
            _secondBoosterCount = YandexGame.savesData.BoostersCount[1];
            _thirdBoosterCount = YandexGame.savesData.BoostersCount[2];
            _fourthBoosterCount = YandexGame.savesData.BoostersCount[3];
            _fifthBoosterCount = YandexGame.savesData.AddedBoosterCount;
            PlayerCash = YandexGame.savesData.PlayerMoney;
        }

        void Start()
        {
            CheckInteractible();
            _firstBoosterPriceText.text = $"{_firstBoosterPrice}";
            _secondBoosterPriceText.text = $"{_secondBoosterPrice}";
            _thirdBoosterPriceText.text = $"{_thirdBoosterPrice}";
            _fourthBoosterPriceText.text = $"{_fourthBoosterPrice}";
            _fifthBoosterPriceText.text = $"{_fifthBoosterPrice}";
            SetCountOfBooster(_firstBoosterCountText, _firstBoosterCount);
            SetCountOfBooster(_secondBoosterCountText, _secondBoosterCount);
            SetCountOfBooster(_thirdBoosterCountText, _thirdBoosterCount);
            SetCountOfBooster(_fourthBoosterCountText, _fourthBoosterCount);
            SetCountOfBooster(_fifthBoosterCountText, _fifthBoosterCount);
            SetPlayerCash();
        }
        private void CheckInteractible()
        {
            BuyAvailableCheck(_buyFirstBoosterButton, _firstBoosterPrice);
            BuyAvailableCheck(_buySecondBoosterButton, _secondBoosterPrice);
            BuyAvailableCheck(_buyThirdBoosterButton, _thirdBoosterPrice);
            BuyAvailableCheck(_buyFourthBoosterButton, _fourthBoosterPrice);
            BuyAvailableCheck(_buyFifthBoosterButton, _fifthBoosterPrice);
        }

        private void BuyAvailableCheck(Button button, int boosterPrice)
        {
            if (boosterPrice > PlayerCash)
            {
                button.interactable = false;
            }
        }

        private void SetCountOfBooster(TextMeshProUGUI text, int boosterCount)
        {
            text.text = $"x{boosterCount}";
        }

        private void SetPlayerCash()
        {
            _PlayerCashText.text = $"{PlayerCash}";
        }

        private void FirstBoosterBuy()
        {
            PlayerCash -= _firstBoosterPrice;
            _firstBoosterCount++;
            CosmeticShop.IsPurchaseDone.Invoke();
            SetCountOfBooster(_firstBoosterCountText, _firstBoosterCount);
            SetPlayerCash();
        }

        private void SecondBoosterBuy()
        {
            PlayerCash -= _secondBoosterPrice;
            _secondBoosterCount++;
            CosmeticShop.IsPurchaseDone.Invoke();
            SetCountOfBooster(_secondBoosterCountText, _secondBoosterCount);
            SetPlayerCash();
        }

        private void ThirdBoosterBuy()
        {
            PlayerCash -= _thirdBoosterPrice;
            _thirdBoosterCount++;
            CosmeticShop.IsPurchaseDone.Invoke();
            SetCountOfBooster(_thirdBoosterCountText, _thirdBoosterCount);
            SetPlayerCash();
        }

        private void FourthBoosterBuy()
        {
            PlayerCash -= _fourthBoosterPrice;
            _fourthBoosterCount++;
            CosmeticShop.IsPurchaseDone.Invoke();
            SetCountOfBooster(_fourthBoosterCountText, _fourthBoosterCount);
            SetPlayerCash();
        }
        
        private void FifthBoosterBuy()
        {
            PlayerCash -= _fifthBoosterPrice;
            _fifthBoosterCount++;
            CosmeticShop.IsPurchaseDone.Invoke();
            SetCountOfBooster(_fifthBoosterCountText, _fifthBoosterCount);
            SetPlayerCash();
        }

        private void OnDisable()
        {
            YandexGame.savesData.PlayerMoney = PlayerCash;
            YandexGame.savesData.BoostersCount[0] = _firstBoosterCount;
            YandexGame.savesData.BoostersCount[1] = _secondBoosterCount;
            YandexGame.savesData.BoostersCount[2] = _thirdBoosterCount;
            YandexGame.savesData.BoostersCount[3] = _fourthBoosterCount;
            YandexGame.savesData.AddedBoosterCount = _fifthBoosterCount;
            YandexGame.SaveProgress();
            _buyFirstBoosterButton.onClick.RemoveListener(FirstBoosterBuy);
            _buySecondBoosterButton.onClick.RemoveListener(SecondBoosterBuy);
            _buyThirdBoosterButton.onClick.RemoveListener(ThirdBoosterBuy);
            _buyFourthBoosterButton.onClick.RemoveListener(FourthBoosterBuy);
            _buyFifthBoosterButton.onClick.RemoveListener(FifthBoosterBuy);
            CosmeticShop.IsPurchaseDone.RemoveListener(CheckInteractible);

            
        }
    }
}