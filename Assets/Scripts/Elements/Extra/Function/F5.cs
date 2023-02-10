using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class F5 : MonoBehaviour {
    public GameObject GameUI;
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.F5))
        { 
            bool isActive = GameUI.activeSelf;
 
            GameUI.SetActive(false);
            GameUI.SetActive(true);
        }
    }
}