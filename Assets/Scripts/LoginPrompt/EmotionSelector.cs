using System.Collections.Generic;
using UnityEngine;

namespace LoginPrompt
{
    public class EmotionSelector : MonoBehaviour
    {
        public List<NamingPromptSelection> promptSelections = new();

        private void Awake()
        {
            NamingPromptSelection.OnNamingButtonPressed += UpdateButtons;
            BackButton.OnBackButtonPressed += ResetAllPrompts;
            GameController.OnSelectionsCompleted += HideSelf;
        }

        private void OnDestroy()
        {
            NamingPromptSelection.OnNamingButtonPressed -= UpdateButtons;
            BackButton.OnBackButtonPressed -= ResetAllPrompts;
            GameController.OnSelectionsCompleted -= HideSelf;
        }

        private void UpdateAllPrompts(NamingPromptSelection selection)
        {
            var iterator = 0;
            foreach (var prompt in promptSelections)
            {
                prompt.TextMeshPro.text = selection.namingData.childEmotions[iterator++].emotionName;
            }
        }

        private void UpdateButtons(string selection)
        {
            var selectedPrompt = promptSelections.Find((prompt) => prompt.namingData.rootEmotion.emotionName == selection);
            if (selectedPrompt != null)
            {
                UpdateAllPrompts(selectedPrompt);
            }
        }

        private void ResetAllPrompts()
        {
            foreach (var prompt in promptSelections)
            {
                prompt.TextMeshPro.text = prompt.namingData.rootEmotion.emotionName;
            }
        }

        private void HideSelf()
        {
            gameObject.SetActive(false);
        }
    }
}
