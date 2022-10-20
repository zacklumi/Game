using System;
using System.Collections.Generic;
using LoginPrompt;
using LoginPrompt.ScriptableObjects;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<TreeDataScriptable> treeData = new();
    private List<string> selectedEmotions = new();
    public static event Action OnSelectionsCompleted;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        NamingPromptSelection.OnNamingButtonPressed += AddEmotionToSelections;
        BackButton.OnBackButtonPressed += WipeExistingSelections;
    }

    private void OnDestroy()
    {
        NamingPromptSelection.OnNamingButtonPressed -= AddEmotionToSelections;
    }

    private void AddEmotionToSelections(string selection)
    {
        selectedEmotions.Add(selection);
        if (selectedEmotions.Count >= 2)
        {
            OnSelectionsCompleted?.Invoke();
        }
    }

    private void WipeExistingSelections()
    {
        selectedEmotions.Clear();
    }
}
