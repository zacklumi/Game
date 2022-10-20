using System.Collections.Generic;
using System.Linq;
using HistoricalData.ScriptableObjects;
using LoginPrompt.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class RootEmotionBarData : MonoBehaviour
{
    public GameObject emotionBarPrefab;
    public List<NamingPromptScriptable> emotionData;
    
    public void CreateEmotionBars(List<TreeDataScriptable.TreeData> treeData)
    {
        var totalSelections = 0;
        treeData.ForEach(x => totalSelections += x.selections);
        var position = transform.position.x + GetComponent<RectTransform>().sizeDelta.x * 0.5f;
        var totalSize = 700.0f;
        foreach (var data in treeData)
        {
            var barWidth = (float)data.selections / totalSelections * totalSize;
            var barColor = GetBarColor(data.emotionName);
            var newBar = Instantiate(emotionBarPrefab, transform);
            newBar.transform.position = new Vector3(position + barWidth * 0.5f, transform.position.y, transform.position.z);
            newBar.GetComponent<Image>().color = barColor;
            newBar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, 32.0f);
            position += barWidth;
        }
    }

    public void ClearChildren()
    {
        var childrenBars = transform.childCount;
        for (var i = 0; i < childrenBars; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private Color GetBarColor(string inputName)
    {
        foreach (var childEmotion in emotionData.SelectMany(emotion => emotion.childEmotions.Where(childEmotion => childEmotion.emotionName == inputName)))
        {
            return childEmotion.emotionColor;
        }

        return Color.white;
    }
}
