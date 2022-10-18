using LoginPrompt;
using TMPro;
using UnityEngine;

public class NamingPromptSelection : MonoBehaviour
{
    public NamingPromptScriptable namingData;
    public TextMeshProUGUI _textMeshPro { get; private set; }

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (_textMeshPro != null)
        {
            _textMeshPro.text = namingData.rootEmotion;
        }
    }
}
