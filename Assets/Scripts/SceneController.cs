using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartOver()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }
}
