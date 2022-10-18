using System.Collections.Generic;
using UnityEngine;

namespace LoginPrompt
{
    [CreateAssetMenu(menuName = "GameAssets/Naming")]
    public class NamingPromptScriptable : ScriptableObject
    {
        public string rootEmotion;
        public List<string> childEmotions;
    }
}
