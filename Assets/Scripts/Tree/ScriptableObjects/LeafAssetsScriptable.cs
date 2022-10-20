using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameAssets/LeafAssets")]
public class LeafAssetsScriptable : ScriptableObject
{
    public List<Sprite> leafGraphics = new();
}
