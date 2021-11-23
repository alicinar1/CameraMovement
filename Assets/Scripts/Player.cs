using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static volatile Player instance = null;

    public static Player Instance 
    { 
        get 
        {
            if (instance == null)
            {
                instance = new GameObject("Player").AddComponent<Player>();
            }

            return instance;
        } 
    }

    private void OnEnable()
    {
        instance = this;
    }
}
