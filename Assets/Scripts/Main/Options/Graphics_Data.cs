using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphics_Data : MonoBehaviour
{
    public void  SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
