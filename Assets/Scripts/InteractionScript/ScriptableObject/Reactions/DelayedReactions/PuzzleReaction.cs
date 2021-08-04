using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReaction : DelayedReaction
{
    public PuzzleData PuzzleData;
    private PuzzleCanvasHandler puzzleHandler;            // Reference to the component to display the text.


    protected override void SpecificInit()
    {
        puzzleHandler = FindObjectOfType<PuzzleCanvasHandler>();
    }


    protected override void ImmediateReaction()
    {
        puzzleHandler.PuzzleReaction (PuzzleData);
    }
}
