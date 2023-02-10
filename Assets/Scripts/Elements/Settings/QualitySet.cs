using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySet : MonoBehaviour
{
    public void  SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
