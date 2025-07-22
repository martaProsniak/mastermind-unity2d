using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    [Header("Game Board Settings")]
    [SerializeField] private GameObject _guessRowPrefab;
    [SerializeField] private int _numberOfRows = 10;
    [SerializeField] private float _rowSpacing = 1.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        }
    }
}
