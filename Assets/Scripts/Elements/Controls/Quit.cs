using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void OperationTaskExitClient()
    {
        Application.Quit();
        Debug.Log("InputManager.ButtonPressed(obj=exit_button)");
        Debug.Log("NetworkManager.ConnectionTypeSet(disconnectfromserver.client)");
        Debug.Log("ClientResourcesManager.StartProcess(Exit)");
        Debug.Log("Closing...");
    }
}
