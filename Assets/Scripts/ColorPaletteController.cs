using UnityEngine;

public class ColorPaletteController : MonoBehaviour
{
    public static PegColor CurrentColor
    {
        get; private set;
    }

    private void Awake()
    {
        CurrentColor = PegColor.Red;
    }

    public void SelectColor(int colorIndex)
    {
        CurrentColor = (PegColor)colorIndex;
        Debug.Log("Chosen color: " + CurrentColor);
    }
}
