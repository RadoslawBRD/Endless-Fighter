using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static HudManager instance;


    public GameObject playerScreen;
    public GameObject levelUpScreen;




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
            levelUpScreen.GetComponent<Canvas>().enabled = false;
            playerScreen.GetComponent<Canvas>().enabled = true;
            Debug.Log("Hud enabled properly");

        }
        catch (System.Exception e)
        {
            Debug.Log("Hud not enabled!!"+ e.Message);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changePlayerScreenVisibility()
    {
        playerScreen.GetComponent<Canvas>().enabled = !playerScreen.GetComponent<Canvas>().enabled;
    }
    public void changeLevelUpScreenVisibility()
    {
        levelUpScreen.GetComponent<Canvas>().enabled = !levelUpScreen.GetComponent<Canvas>().enabled;        
    }
}
