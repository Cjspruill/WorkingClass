using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedCharactersSingleton : MonoBehaviour
{
    public static SpawnedCharactersSingleton Instance { get; private set; }

    private void Awake()
    {
        // If an instance already exists and it's not this, destroy this object
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Otherwise, set the instance to this
        Instance = this;
    }

}
