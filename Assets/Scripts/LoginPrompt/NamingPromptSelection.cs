using System;
using LoginPrompt.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LoginPrompt
{
    public class NamingPromptSelection : MonoBehaviour
    {
        public NamingPromptScriptable namingData;
        public TextMeshProUGUI TextMeshPro { get; private set; }
        public Image Image { get; private set; }

        public static event Action<string> OnNamingButtonPressed;
    
        private void Awake()
        {
            TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            if (TextMeshPro != null)
            {
                TextMeshPro.text = namingData.rootEmotion.emotionName;
            }

            Image = GetComponent<Image>();
            if (Image != null)
            {
                Image.color = namingData.rootEmotion.emotionColor;
            }
        }

        public void PostNamingButtonPressed()
        {
            OnNamingButtonPressed?.Invoke(TextMeshPro.text);
        }
    }
}
