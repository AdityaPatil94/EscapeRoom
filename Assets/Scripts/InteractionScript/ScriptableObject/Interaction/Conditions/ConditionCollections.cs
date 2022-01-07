using System;
using System.Collections.Generic;
using UnityEngine;

    //this class contains
    [Serializable]
    public class ConditionCollections 
    {
        public string Description;
        public Condition[] RequiredCondition;// = new Condition[10];
        public ReactionCollection reactionCollection;

        public bool CheckAndReact()
        {
        
            //go through all condition
            for(int i =0;i<RequiredCondition.Length;i++)
            {
                //Debug.Log(RequiredCondition[i].Description);
                //Debug.Log(RequiredCondition[i].Satisfied);
                if (!AllConditions.CheckCondition(RequiredCondition[i])) return false;
            }

            if (reactionCollection != null)
                Debug.Log("react here");
                reactionCollection.React();

                return true;
        }
    }
