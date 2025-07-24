using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    [Header("Game Board Settings")]
    [SerializeField] private GameObject _guessRowPrefab;
    [SerializeField] private int _numberOfRows = 10;
    [SerializeField] private float _rowSpacing = 1.2f;

    private List<GuessRowController> _rowControllers = new List<GuessRowController>();
    private int _currentRowIndex = 0;

    private void OnEnable()
    {
        GameManager.OnGuessProcessed += UpdateBoardOnGuess;
    }

    private void OnDisable()
    {
        GameManager.OnGuessProcessed -= UpdateBoardOnGuess;
    }

    void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        if (_guessRowPrefab == null)
        {
            Debug.LogError("GuessRow prefab is not assigned");
        }

        for (int i = 0; i < _numberOfRows; i++)
        {
            GameObject newRow = Instantiate(_guessRowPrefab, new Vector3(0, i * _rowSpacing, 0), Quaternion.identity);
            newRow.transform.SetParent(transform);
            newRow.name = $"Guess Row {i}";

            _rowControllers.Add(newRow.GetComponent<GuessRowController>());
        }
    }

    private void UpdateBoardOnGuess(Guess guessResult)
    {
        if (_currentRowIndex >= _rowControllers.Count)
        {
            return;
        }

        GuessRowController currentRow = _rowControllers[_currentRowIndex];
        currentRow.DisplayHints(guessResult.BlackPegs, guessResult.WhitePegs);
        _currentRowIndex++;
    }
}
