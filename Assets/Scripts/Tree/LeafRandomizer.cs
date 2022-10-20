using UnityEngine;

namespace Tree
{
    public class LeafRandomizer : MonoBehaviour
    {
        public LeafAssetsScriptable availableLeafTextures;

        private void Awake()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            var leafCount = availableLeafTextures.leafGraphics.Count;
            spriteRenderer.sprite = availableLeafTextures.leafGraphics[Random.Range(0, leafCount)];
        }
    }
}
