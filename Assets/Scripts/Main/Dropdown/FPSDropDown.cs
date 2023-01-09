using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSDropDown : MonoBehaviour
{

    public TextMeshProUGUI output;

    public void HandleInputData(int val)
    {
        if (val == 0) {
            output.text = "Loading...";
            output.text = "Editing Client FPS...";
            output.text = "[LOG] Client FPS has been set to 60";
            Debug.Log("TargetFrameRate Value Changed...");
            Application.targetFrameRate = 60;
        }
        if (val == 1)
        {
            Application.targetFrameRate = 120;
            output.text = "Loading...";
            output.text = "Editing Client FPS...";
            output.text = "[LOG] Client FPS has been set to 120";
            Debug.Log("TargetFrameRate Value Changed...");
        }
        if (val == 2)
        {
            Application.targetFrameRate = 240;
            output.text = "Loading...";
            output.text = "Editing Client FPS...";
            output.text = "[LOG] Client FPS has been set to 240";
            Debug.Log("TargetFrameRate Value Changed...");
        }
        if (val == 3)
        {
            Application.targetFrameRate = 280;
            output.text = "Loading...";
            output.text = "Editing Client FPS...";
            output.text = "[LOG] Client FPS has been set to 280";
            Debug.Log("TargetFrameRate Value Changed...");
        }
        if (val == 4)
        {
            Application.targetFrameRate = 300;
            output.text = "Loading...";
            output.text = "Editing Client FPS...";
            output.text = "[LOG] Client FPS has been set to 300";
            Debug.Log("TargetFrameRate Value Changed...");
        }
        if (val == 5)
        {
            Application.targetFrameRate = 9999;
            output.text = "Loading...";
            output.text = "Editing Client FPS...";
            output.text = "[LOG] Client FPS has been set to (val= [inf])";
            Debug.Log("TargetFrameRate Value Changed...");
        }
    }  
}