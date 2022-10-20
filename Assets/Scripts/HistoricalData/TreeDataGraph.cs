using System.Collections.Generic;
using HistoricalData.ScriptableObjects;
using UnityEngine;

namespace HistoricalData
{
    public class TreeDataGraph : MonoBehaviour
    {
        public TreeDataScriptable treeData;
        public List<RootEmotionBarData> rootEmotionBars;

        private const int ChildEmotionsPerRoot = 6;

        public void CreateEmotionBars()
        {
            var iterator = 0;
            foreach (var rootEmotion in rootEmotionBars)
            {
                List<TreeDataScriptable.TreeData> emotions = new();
                for (var i = 0; i < ChildEmotionsPerRoot; i++)
                {
                    emotions.Add(treeData.emotionalData[iterator + i]);
                }

                iterator += ChildEmotionsPerRoot;
                rootEmotion.CreateEmotionBars(emotions);
            }
        }

        public void HideGraph()
        {
            foreach (var childBar in rootEmotionBars)
            {
                childBar.ClearChildren();
            }
            gameObject.SetActive(false);
        }
    }
}
