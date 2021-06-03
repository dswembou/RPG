using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingWrapper : MonoBehaviour
{
    const string defaultSaveFile = "save";
    
    private static SavingWrapper _instance = null;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
    }
    public void Save()
    {
        GetComponent<SavingSystem>().Save(defaultSaveFile);
    }
    public void Load()
    {
        GetComponent<SavingSystem>().Load(defaultSaveFile);
    }
}
