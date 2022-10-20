using System;
using System.Collections.Generic;
using System.Linq;
using HistoricalData.ScriptableObjects;
using LoginPrompt.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tree
{
    public class TreeGenerator : MonoBehaviour
    {
        public TreeDataScriptable treeData;
        public List<NamingPromptScriptable> emotionData = new();
        
        public static event Action<TreeDataScriptable> OnTreeSelected;

        private void Awake()
        {
            AssignLeafColors();
        }

        private Color GetLeafColor(string inputName)
        {
            foreach (var childEmotion in emotionData.SelectMany(emotion => emotion.childEmotions.Where(childEmotion => childEmotion.emotionName == inputName)))
            {
                return childEmotion.emotionColor;
            }

            return Color.white;
        }

        public void AssignLeafColors()
        {
            transform.localScale = new Vector3(Random.Range(0.9f, 1.1f) * Mathf.Sign(Random.value - 0.5f), Random.Range(0.97f, 1.03f), 1.0f);
            if (treeData == null)
                return;
            var mostSelectedEmotion = treeData.emotionalData.Max(item => item.selections);
            var selectedEmotionName = treeData.emotionalData.Find((prompt) => prompt.selections == mostSelectedEmotion).emotionName;
            var treeLeafColor = GetLeafColor(selectedEmotionName);
            var childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            foreach (var childRenderer in childSpriteRenderers)
            {
                if (childRenderer.gameObject == gameObject)
                    continue;
                childRenderer.color = treeLeafColor;
            }
        }
        
        private void OnMouseUp()
        {
            OnTreeSelected?.Invoke(treeData);
        }
    }
}
