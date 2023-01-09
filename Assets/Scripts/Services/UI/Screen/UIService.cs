using System;
using System.Collections.Generic;
using KnifeThrower.Services.Screen;
using UnityEngine;

namespace KnifeThrower.Services
{
    public class UIService : IUIService
    {
        private readonly UIFactory _factory;
        private Dictionary<Type, ScreenController> _controllersByType = new();

        public UIService(UIFactory factory)
        {
            _factory = factory;
        }
        public T GetController<T>() where T : ScreenController
        {
            Type key = typeof(T); 
            if (_controllersByType.ContainsKey(key))
            {
                return _controllersByType[key] as T;
            }

            return CreateController<T>();
        }

        public void ShowScreen<T>() where T : ScreenController
        {
            GetController<T>()?.Show();
        }

        public void HideScreen<T>() where T : ScreenController
        {
            GetController<T>()?.Hide();
        }

        private T CreateController<T>() where T : ScreenController
        {
            T controller = _factory.Create<T>();
            if (controller != null)
            {
                Debug.Log($"Cant create controller for type {typeof(T)}");
            }
            _controllersByType.Add(typeof(T), controller);
            return controller;

        }
    }
}