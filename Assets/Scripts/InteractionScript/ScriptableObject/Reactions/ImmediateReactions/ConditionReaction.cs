// This is the Reaction to change the satisfied state
// of a Condition.  The Condition here is a reference
// to one on the AllConditions asset.  That means by
// changing the Condition here, the global game
// Condition will change.  Since Reaction decisions
// are made based on Conditions, the change must be
// immediate and therefore this is a Reaction rather
// than a DelayedReaction.
public class ConditionReaction : Reaction
{
    public Condition condition;     // The Condition to be changed.

    protected override void ImmediateReaction ()
    {
        for (int i = 0; i < AllConditions.Instance.conditions.Length; i++)
        {
            if (AllConditions.Instance.conditions[i].Description == condition.Description)
            {
                AllConditions.Instance.conditions[i].Satisfied = condition.Satisfied;
            }
        }
    }

}
