using System.Collections.Generic;
using HistoricalData.ScriptableObjects;
using UnityEngine;

namespace Tree.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GameAssets/TreeHistory")]
    public class TreeHistoryScriptable : ScriptableObject
    {
        public List<TreeDataScriptable> treeHistory;
    }
}
