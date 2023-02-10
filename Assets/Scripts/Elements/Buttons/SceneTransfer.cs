using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer: MonoBehaviour
{
    public string MainLevel;

    public string Pause_Setup { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangingSceneToMainScene()
    {
        SceneManager.LoadScene(MainLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting the Client...");
    }
}
