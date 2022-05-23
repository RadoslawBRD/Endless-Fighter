using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public static AbilityHolder instance;
    public Dictionary<int, AbilityTemplate> abilities = new Dictionary<int, AbilityTemplate>();
    float activateTime;

    void Start()
    {

        
        try
        {
            abilities.Add(0, ScriptableObject.CreateInstance<VerticalAttack>());
            Debug.Log("AbilityHolder Created!!!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("AbilityHolder not enabled!!" + e.Message);

        }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.Log("instance already exists, destroying object!");
            Destroy(this);
        }
    }


    // Update is called once per frame
    void Update()
        {
            
        }
}
