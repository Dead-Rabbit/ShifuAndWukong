using UnityEngine;

public class GameObjectTools
{
    public static Transform GetTransform(Transform check, string name)
    {
        foreach (Transform t in check.GetComponentsInChildren<Transform>())
        {
            if (t.name == name) 
            {
                //要做的事
                return t;    
            }    
        }
        return null;
    }
        
}