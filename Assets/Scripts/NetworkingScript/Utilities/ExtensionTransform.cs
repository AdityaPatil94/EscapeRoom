using UnityEngine;

public static class Transforms
{
    public static void DestroyChildern(this Transform t,bool destroyImmediatly = false)
    {
        foreach (Transform child in t)
        {
            if(destroyImmediatly)
            {
                MonoBehaviour.DestroyImmediate(child.gameObject);
            }
            else
            {
                MonoBehaviour.Destroy(child.gameObject);
            }
        }
    }
}
