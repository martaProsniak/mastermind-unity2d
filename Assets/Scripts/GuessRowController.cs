using UnityEngine;

public class GuessRowController : MonoBehaviour
{
    [Header("Row Components")]
    [SerializeField] private SpriteRenderer[] _pegRenderers;
    [SerializeField] private SpriteRenderer[] _hintPegRenderers;

    public void SetPegs(PegColor[] colors)
    {

    }

    public void DisplayHints(int blackPegs, int whitePegs)
    {
        for (int i = 0; i < blackPegs; i++)
        {
            _hintPegRenderers[i].color = Color.black;
        }

        for (int i = blackPegs; i < blackPegs + whitePegs; i++)
        {
            _hintPegRenderers[i].color = Color.white;
        }
    }
}
