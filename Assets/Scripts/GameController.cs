using System;
using System.Collections.Generic;
using HistoricalData;
using HistoricalData.ScriptableObjects;
using LoginPrompt;
using Tree;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TreeDataGraph graphPopup;
    private readonly List<string> _selectedEmotions = new();
    public static event Action OnSelectionsCompleted;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        NamingPromptSelection.OnNamingButtonPressed += AddEmotionToSelections;
        BackButton.OnBackButtonPressed += WipeExistingSelections;
        TreeGenerator.OnTreeSelected += ShowGraphPopup;
    }

    private void OnDestroy()
    {
        NamingPromptSelection.OnNamingButtonPressed -= AddEmotionToSelections;
        BackButton.OnBackButtonPressed -= WipeExistingSelections;
        TreeGenerator.OnTreeSelected -= ShowGraphPopup;
    }

    private void AddEmotionToSelections(string selection)
    {
        _selectedEmotions.Add(selection);
        if (_selectedEmotions.Count >= 2)
        {
            OnSelectionsCompleted?.Invoke();
        }
    }

    private void WipeExistingSelections()
    {
        _selectedEmotions.Clear();
    }

    private void ShowGraphPopup(TreeDataScriptable incomingData)
    {
        if (incomingData == null)
            return;
        graphPopup.treeData = incomingData;
        graphPopup.gameObject.SetActive(true);
        graphPopup.CreateEmotionBars();
    }
}
