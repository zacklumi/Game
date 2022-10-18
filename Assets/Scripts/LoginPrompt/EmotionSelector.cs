using System.Collections.Generic;
using UnityEngine;

public class EmotionSelector : MonoBehaviour
{
    public List<NamingPromptSelection> promptSelections = new();

    public void UpdateAllPrompts(NamingPromptSelection selection)
    {
        var iterator = 0;
        foreach (var prompt in promptSelections)
        {
            prompt._textMeshPro.text = selection.namingData.childEmotions[iterator++];
        }
    }

    public void ResetAllPrompts()
    {
        foreach (var prompt in promptSelections)
        {
            prompt._textMeshPro.text = prompt.namingData.rootEmotion;
        }
    }
}
