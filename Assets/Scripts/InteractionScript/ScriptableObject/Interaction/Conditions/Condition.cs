using UnityEngine;
using System;
//this class contain single condition
[Serializable]
public class Condition 
{
    public ConditionDescription Description;
    public bool Satisfied;
}

public enum ConditionDescription
{
    HasLetterOpend,
    HasLaptopStarted,
    HasFusePickedUp,
    HasFusePlacedInCircuit,

}