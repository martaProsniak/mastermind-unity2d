using UnityEngine;

public class PegController : MonoBehaviour
{
    private int _pegIndex;
    private GuessRowController _parentRow;

    public void Initialize(int index, GuessRowController parent)
    {
        _pegIndex = index;
        _parentRow = parent;
    }

    private void OnMouseDown()
    {
        _parentRow.OnPegClicked(_pegIndex);
    }

    
}
