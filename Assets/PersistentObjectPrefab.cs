using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectPrefab : MonoBehaviour
{
    [SerializeField] private GameObject persistendObjectPrefab;

    private static bool hasSpawned = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (hasSpawned) return;

        SpawnPersistentObjects();

        hasSpawned = true;
    }

    // Update is called once per frame
    void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(persistendObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}
