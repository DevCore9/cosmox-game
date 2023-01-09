  using UnityEngine;
  using System.Collections;
  
  public class WebNews1 : MonoBehaviour
  {
      public void OpenURL()
      {
          Application.OpenURL("https://www.cosmox-web.ml/news");
          Debug.Log("Loading Script...");
          Debug.Log("Opening the Browser with address https://www.cosmox-web.ml/news");
      }
  
  }