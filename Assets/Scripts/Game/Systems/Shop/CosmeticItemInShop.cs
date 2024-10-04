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
    public class CosmeticItemInShop : MonoBehaviour
    {
        [SerializeField] private Button _setThisItemActiveButton;
        
        [SerializeField] private GameObject _purchaseLabel;
        [SerializeField] private GameObject _setItemButton;
        [SerializeField] private Button _purchaseButton;
        [SerializeField] private GameObject _confirmLabel;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _declineButton;
        [SerializeField] private TextMeshProUGUI _purchasePriceText;
        
        
        [SerializeField] private int _ItemSerialNumber;
        [SerializeField] private int _ItemPurchasePrice;

        [SerializeField] private int _NumberInShopCategory;
        
        
        

        private void OnEnable()
        {
            _setThisItemActiveButton.onClick.AddListener(SetThisItemActive);
            _purchaseButton.onClick.AddListener(OpenConfirmLabel);
            _confirmButton.onClick.AddListener(FinishPurchase);
            _declineButton.onClick.AddListener(DeclinePurchase);
            CosmeticShop.IsPurchaseDone.AddListener(CheckInteractible);
        }

        

        private void Awake()
        {
            switch (YandexGame.savesData.IsItemPurchased[_ItemSerialNumber])
            {
                case false:
                    _purchaseLabel.SetActive(true);
                    _setItemButton.SetActive(false);
                    break;
                case true:
                    _purchaseLabel.SetActive(false);
                    _setItemButton.SetActive(true);
                    break;
            }
            
            
        }

        private void Start()
        {
            _confirmLabel.SetActive(false);
            BuyAvailableCheck(_purchaseButton, _ItemPurchasePrice);
            _purchasePriceText.text = $"{_ItemPurchasePrice}";
        }
        
        private void SetThisItemActive()
        {
            switch (gameObject.tag)
            {
                case Tags.ShurikenInShop:
                    CosmeticShop.ShopShurikenNumber = _NumberInShopCategory;
                    break;
                case Tags.TrailInShop:
                    CosmeticShop.ShopTrailNumber = _NumberInShopCategory;
                    break;
            }
            CosmeticShop.IsSetButtonPressed.Invoke();
        }

        private void OpenConfirmLabel()
        {
            _confirmLabel.SetActive(true);
        }
        
        private void FinishPurchase()
        {
            YandexGame.savesData.IsItemPurchased[_ItemSerialNumber] = true;
            ShopConsumablesService.PlayerCash -= _ItemPurchasePrice;
            _purchaseLabel.SetActive(false);
            _setItemButton.SetActive(true);
            CosmeticShop.IsPurchaseDone.Invoke();
            YandexGame.SaveProgress();
        }
        
        private void DeclinePurchase()
        {
            _confirmLabel.SetActive(false);
        }
        
        private void BuyAvailableCheck(Button button, int boosterPrice)
        {
            if (boosterPrice > ShopConsumablesService.PlayerCash)
            {
                button.interactable = false;
            }
        }
        
        private void CheckInteractible()
        {
            BuyAvailableCheck(_purchaseButton, _ItemPurchasePrice);
        }

        private void OnDisable()
        {
            _setThisItemActiveButton.onClick.RemoveListener(SetThisItemActive);
            _purchaseButton.onClick.RemoveListener(OpenConfirmLabel);
            _confirmButton.onClick.RemoveListener(FinishPurchase);
            _declineButton.onClick.RemoveListener(DeclinePurchase);
            CosmeticShop.IsPurchaseDone.RemoveListener(CheckInteractible);
        }
    }
}
