using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
   private static DoNotDestroy instance;

      void Awake()
      {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
          instance = this;
          DontDestroyOnLoad(gameObject);
        }
      }
}