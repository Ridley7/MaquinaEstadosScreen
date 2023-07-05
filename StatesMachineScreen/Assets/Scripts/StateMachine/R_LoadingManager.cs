using System;
using UnityEngine;
using UnityEngine.UI;

namespace R_ScreenStateMachine
{
    public class R_LoadingManager : MonoBehaviour
    {
        public enum R_LoadingType
        {
            Fullscreen,
            Popup
        }

        [Serializable]
        private class R_LoadingData
        {
            public GameObject container;
            public Text text;
            public GameObject animation;
        }

        [SerializeField] private R_LoadingData fullScreenLoading;
        [SerializeField] private R_LoadingData popupLoading;

        private R_LoadingType currentLoadingType = R_LoadingType.Fullscreen;

        public void EnableLoading(string text = "Loading", R_LoadingType type = R_LoadingType.Fullscreen, bool enableLoadingAnimation = true)
        {
            DisableLoading();

            switch (type)
            {
                case R_LoadingType.Fullscreen:
                    fullScreenLoading.text.text = text;
                    fullScreenLoading.container.SetActive(true);
                    fullScreenLoading.animation.SetActive(enableLoadingAnimation);
                    currentLoadingType = type;
                    break;

                case R_LoadingType.Popup:
                    popupLoading.text.text = text;
                    popupLoading.container.SetActive(true);
                    popupLoading.animation.SetActive(enableLoadingAnimation);
                    currentLoadingType = type;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void DisableLoading()
        {
            switch (currentLoadingType)
            {
                case R_LoadingType.Fullscreen:
                    fullScreenLoading.container.SetActive(false);
                    break;

                case R_LoadingType.Popup:
                    popupLoading.container.SetActive(false);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(currentLoadingType), currentLoadingType, null);
            }
        }
    }

}

