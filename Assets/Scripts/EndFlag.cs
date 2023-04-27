using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour


{
    public bool finalLevel;
    public string nextLevelName;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (finalLevel == true)
            {
                // load the main menu
                SceneManager.LoadScene(0);
            }
            else
            {
                // load the next level
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
