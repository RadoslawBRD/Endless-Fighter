using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CashDisplay : MonoBehaviour
{
    public static CashDisplay instance;
    public GameObject cashLabel;

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
            cashLabel.gameObject.GetComponentInChildren<Text>().text = "0";
            Debug.Log("CashDisplay enabled properly");
        }
        catch (System.Exception e)
        {
            Debug.LogError("CashDisplay not enabled!!" + e.Message);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void UpdateCashDisplay(float _currentCash)
    {
        cashLabel.gameObject.GetComponentInChildren<Text>().text = _currentCash.ToString();
    }
}
