using System.Collections.Generic;
using Tree.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tree
{
    public class TreeController : MonoBehaviour
    {
        public TreeHistoryScriptable treeHistory;
        public List<GameObject> availableTreePrefabs;
        public int numberOfTrees = 20;
        public float treeSpacing = 5.5f;

        private void Awake()
        {
            for (int i = 0; i < numberOfTrees; i++)
            {
                var randomTreeIndex = Random.Range(0, availableTreePrefabs.Count);
                var newTree = Instantiate(availableTreePrefabs[randomTreeIndex], new Vector3(i * -treeSpacing, 0.0f, 0.0f), Quaternion.identity);
                newTree.transform.parent = transform;
                if (i == 0) continue; // Skip the first one so it can be used for the day's tree
                var treeGen = newTree.GetComponent<TreeGenerator>();
                treeGen.treeData = treeHistory.treeHistory[treeHistory.treeHistory.Count - 1 - i];
                treeGen.AssignLeafColors();
            }
        }
    }
}
