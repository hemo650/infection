﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Infection.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Transform[] disableOnChange;

        public void SetActivePanel(Transform panel)
        {
            foreach (Transform child in disableOnChange)
            {
                child.gameObject.SetActive(child == panel);
            }
        }

        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}