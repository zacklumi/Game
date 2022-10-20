using System;
using System.Collections.Generic;
using LoginPrompt;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private readonly List<string> _selectedEmotions = new();
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
}
