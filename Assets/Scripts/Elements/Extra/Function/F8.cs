using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class F8 : MonoBehaviour {
    public GameObject Players;
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.F8))
        { 
            bool isActive = Players.activeSelf;
 
            Players.SetActive(true);
        }
    }
}