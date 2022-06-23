using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KillDisplay : MonoBehaviour
{
    public static KillDisplay instance;
    public GameObject killValue;
    private int killCount = 0;
    // Start is called before the first frame update

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
            killValue.gameObject.GetComponentInChildren<Text>().text = killCount.ToString();
            Debug.Log("KillDisplay enabled properly");
        }
        catch (System.Exception e)
        {
            Debug.LogError("KillDisplay not enabled!!" + e.Message);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateKillDisplay(float _value)
    {
        killValue.gameObject.GetComponentInChildren<Text>().text = _value.ToString();
    }
    public void UpdateKillCount()
    {
        killCount++;
        UpdateKillDisplay(killCount);
    }
}
