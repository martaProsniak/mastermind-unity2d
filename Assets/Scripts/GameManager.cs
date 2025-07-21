using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Editor adjustable settings
    [Header("Settings")]
    [SerializeField] private int _codeLength = 4;
    [SerializeField] private int _maxGuesses = 10;

    // Game State
    private List<PegColor> _code;
    private List<Guess> _guessHistory = new List<Guess>();

    private void Awake()
    {
        GenerateCode();
    }

    private void GenerateCode()
    {
        _code = new List<PegColor>();
        var allColors = System.Enum.GetValues(typeof(PegColor)).Cast<PegColor>().ToList();
        var random = new System.Random();

        for (int i = 0; i < _codeLength; i++)
        {
            int randomIndex = random.Next(allColors.Count);
            _code.Add(allColors[randomIndex]);
        }

        Debug.Log("Secret code: " + string.Join(", ", _code));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
