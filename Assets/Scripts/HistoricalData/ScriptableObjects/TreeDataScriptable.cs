using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "GameAssets/TreeData")]
public class TreeDataScriptable : ScriptableObject
{
    private void Awake()
    {
        RandomizeData();
    }
    
    private const int LowestPossiblePicks = 100;
    private const int HighestPossiblePicks = 10000;

    public int totalSelections;

    [Serializable]
    public class TreeData
    {
        public TreeData(string _emotionName, int _selections)
        {
            emotionName = _emotionName;
            selections = _selections;
        }
        public string emotionName;
        public int selections;
    }

    [ContextMenuItem("Randomize", "RandomizeData")]
    public List<TreeData> emotionalData = new()
    {
        //Anger
        new TreeData("Aggressive", 0),
        new TreeData("Disgusted", 0),
        new TreeData("Frustrated", 0),
        new TreeData("Hurt", 0),
        new TreeData("Jealous", 0),
        new TreeData("Selfish", 0),
        //Calm
        new TreeData("Content", 0),
        new TreeData("Focused", 0),
        new TreeData("Patient", 0),
        new TreeData("Relaxed", 0),
        new TreeData("Thankful", 0),
        new TreeData("Thoughtful", 0),
        //Confidence
        new TreeData("Accepted", 0),
        new TreeData("Determined", 0),
        new TreeData("Inspired", 0),
        new TreeData("Proud", 0),
        new TreeData("Respected", 0),
        new TreeData("Supported", 0),
        //Fear
        new TreeData("Anxious", 0),
        new TreeData("Insecure", 0),
        new TreeData("Powerless", 0),
        new TreeData("Rejected", 0),
        new TreeData("Scared", 0),
        new TreeData("Shocked", 0),
        //Joy
        new TreeData("Cheerful", 0),
        new TreeData("Creative", 0),
        new TreeData("Energetic", 0),
        new TreeData("Excited", 0),
        new TreeData("Hopeful", 0),
        new TreeData("Loving", 0),
        //Sadness
        new TreeData("Ashamed", 0),
        new TreeData("Disappointed", 0),
        new TreeData("Lonely", 0),
        new TreeData("Stressed", 0),
        new TreeData("Tired", 0),
        new TreeData("Upset", 0),
    };
    
    private void RandomizeData()
    {
        totalSelections = 0;
        foreach (var emotion in emotionalData)
        {
            emotion.selections = Random.Range(LowestPossiblePicks, HighestPossiblePicks);
            totalSelections += emotion.selections;
        }
    }
}
