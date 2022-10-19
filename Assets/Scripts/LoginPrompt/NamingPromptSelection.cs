using System;
using TMPro;
using UnityEngine;

namespace LoginPrompt
{
    public class NamingPromptSelection : MonoBehaviour
    {
        public NamingPromptScriptable namingData;
        public TextMeshProUGUI TextMeshPro { get; private set; }

        public static event Action<string> OnNamingButtonPressed;
    
        private void Awake()
        {
            TextMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            if (TextMeshPro != null)
            {
                TextMeshPro.text = namingData.rootEmotion;
            }
        }

        public void PostNamingButtonPressed()
        {
            OnNamingButtonPressed?.Invoke(TextMeshPro.text);
        }
    }
}
