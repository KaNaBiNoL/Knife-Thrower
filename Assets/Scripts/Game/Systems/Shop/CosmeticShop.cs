using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class CosmeticShop : MonoBehaviour
    {
        [SerializeField] private RectTransform _ActiveShurikenVariantRT;
        [SerializeField] private RectTransform _ActiveTrailVariantRT;

        [SerializeField] private RectTransform[] _ShopShurikensRT;
        [SerializeField] private RectTransform[] _ShopTrailsRT;
        

        public static int ShopShurikenNumber
        {
            get;
            set;
        }
        public static int ShopTrailNumber
        {
            get;
            set;
        }

        public static UnityEvent IsPurchaseDone = new UnityEvent();
        public static UnityEvent IsSetButtonPressed = new UnityEvent();

        private void OnEnable()
        {
            IsSetButtonPressed.AddListener(SetActiveShuriken);
            IsSetButtonPressed.AddListener(SetActiveTrail);
        }

        void Awake()
        {
            ShopShurikenNumber = YandexGame.savesData.ShopNumberOfSetShuriken;
            ShopTrailNumber = YandexGame.savesData.ShopNumberOfSetTrail;
        }

        private void Start()
        {
            SetActiveShuriken();
            SetActiveTrail();
        }

        private void SetActiveShuriken()
        {
            _ActiveShurikenVariantRT.anchoredPosition = _ShopShurikensRT[ShopShurikenNumber].anchoredPosition;
        }

        private void SetActiveTrail()
        {
            _ActiveTrailVariantRT.anchoredPosition = _ShopTrailsRT[ShopTrailNumber].anchoredPosition;
        }

        private void OnDisable()
        {
            IsSetButtonPressed.RemoveListener(SetActiveShuriken);
            IsSetButtonPressed.RemoveListener(SetActiveTrail);
            YandexGame.savesData.ShopNumberOfSetShuriken = ShopShurikenNumber;
            YandexGame.savesData.ShopNumberOfSetTrail = ShopTrailNumber;
        }
    }
}