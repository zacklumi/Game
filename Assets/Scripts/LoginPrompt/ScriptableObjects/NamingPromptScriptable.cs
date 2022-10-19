using System;
using System.Collections.Generic;
using UnityEngine;

namespace LoginPrompt.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameAssets/Naming")]
    public class NamingPromptScriptable : ScriptableObject
    {
        public EmotionData rootEmotion;

        [Serializable]
        public class EmotionData
        {
            public string emotionName;
            public Color emotionColor;
        }

        public List<EmotionData> childEmotions;
    }
}
