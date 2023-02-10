  using UnityEngine;
  using System.Collections;
  
  public class UserScript : MonoBehaviour
  {
      public void OpenURL()
      {
          Application.OpenURL("https://www.cosmox-web.ml/user/01");
          Debug.Log("Loading Script...");
          Debug.Log("Checking user database...");
          Debug.Log("Opening the Browser with address https://www.cosmox-web.ml/user/01");
      }
  
  }