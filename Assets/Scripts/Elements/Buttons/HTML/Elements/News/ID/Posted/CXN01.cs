  using UnityEngine;
  using System.Collections;
  
  public class CXN01 : MonoBehaviour
  {
      public void OpenURL()
      {
          Application.OpenURL("https://www.cosmox-web.ml/almost-there-id01");
          Debug.Log("Loading Script...");
          Debug.Log("Opening the Browser with address https://www.cosmox-web.ml/almost-there-id01");
      }
  
  }