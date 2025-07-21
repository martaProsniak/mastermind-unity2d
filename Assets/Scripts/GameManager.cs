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
    private List<PegColor> _secretCode;
    private List<Guess> _guessHistory = new List<Guess>();

    private void Awake()
    {
        GenerateCode();
    }

    private void GenerateCode()
    {
        _secretCode = new List<PegColor>();
        var allColors = System.Enum.GetValues(typeof(PegColor)).Cast<PegColor>().ToList();
        var random = new System.Random();

        for (int i = 0; i < _codeLength; i++)
        {
            int randomIndex = random.Next(allColors.Count);
            _secretCode.Add(allColors[randomIndex]);
        }

        Debug.Log("Secret code: " + string.Join(", ", _secretCode));
    }

    public Guess CheckGuess(PegColor[] playerGuess)
    {
        int blackPegs = 0;
        int whitePegs = 0;

        var secretCodeCopy = new List<PegColor>(_secretCode);
        var playerGuessCopy = new List<PegColor>(playerGuess);

        for (int i = playerGuessCopy.Count - 1; i >= 0; i--)
        {
            if (playerGuessCopy[i] != secretCodeCopy[i])
            {
                continue;
            }

            blackPegs++;
            playerGuessCopy.RemoveAt(i);
            secretCodeCopy.RemoveAt(i);
        }

        foreach (var color in playerGuessCopy) {
            if (secretCodeCopy.Contains(color))
            {
                whitePegs++;
                secretCodeCopy.Remove(color);
            }
        }

        Guess currentGuess = new Guess(playerGuess, blackPegs, whitePegs);
        _guessHistory.Add(currentGuess);

        return currentGuess;
    }
}
