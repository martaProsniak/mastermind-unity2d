using System;
using System.Collections.Generic;
using UnityEngine;

public class GuessRowController : MonoBehaviour
{
    [Header("Row Components")]
    [SerializeField] private SpriteRenderer[] _pegRenderers;
    [SerializeField] private SpriteRenderer[] _hintPegRenderers;

    private PegColor[] _currentPegColors;

    private Dictionary<PegColor, Color> _colorMap;

    private void Awake()
    {
        _currentPegColors = new PegColor[4];
        SetColorMap();
        SetPegs();
    }

    private void SetPegs()
    {
        for (int i = 0; i < _pegRenderers.Length; i++)
        {
            PegController peg = _pegRenderers[i].GetComponent<PegController>();
            if (peg != null)
            {
                peg.Initialize(i, this);
            }
        }
    }

    public void OnPegClicked(int pegIndex)
    {
        PegColor selectedColor = ColorPaletteController.CurrentColor;

        _currentPegColors[pegIndex] = selectedColor;
        _pegRenderers[pegIndex].color = _colorMap[selectedColor];
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

    private void SetColorMap()
    {
        _colorMap = new Dictionary<PegColor, Color>
        {
            { PegColor.Red, Color.red },
            { PegColor.Green, Color.green },
            { PegColor.Blue, Color.blue },
            { PegColor.Yellow, Color.yellow },
            { PegColor.Purple, new Color(0.5f, 0, 0.5f) },
            { PegColor.Orange, new Color(1f, 0.5f, 0) },
            { PegColor.Pink, Color.magenta },
            { PegColor.LightBlue, Color.cyan } 
        };
    }
}
