using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExpBar : MonoBehaviour
{
    public static ExpBar instance;

    // Start is called before the first frame update
    public float currentExp;
    public Slider expDisplay;

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

    void Start()
    {

        
        try
        {
            expDisplay.value = 0;
            Debug.Log("ExpBar Created!!!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("ExpBar not enabled!!" + e.Message);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetExp(float _exp)
    {
        expDisplay.value = _exp;
    }
}
