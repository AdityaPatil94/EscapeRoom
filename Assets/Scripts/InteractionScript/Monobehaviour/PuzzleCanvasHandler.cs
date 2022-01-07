using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PuzzleCanvasHandler : MonoBehaviour
{
    public GameObject PuzzlePanel;
    //public TextMeshProUGUI PuzzleText;
    public Text PuzzleText;

    public void PuzzleReaction(PuzzleData data)
    {
        PuzzlePanel.SetActive(true);
        PuzzleText.text = data.PuzzleMessage;
        PuzzleText.color = data.textColor;
}
}

[System.Serializable]
public class PuzzleData
{
    public string PuzzleMessage;                     // The text to be displayed to the screen.
    public Color textColor = Color.white;       // The color of the text when it's displayed (different colors for different characters talking).
}