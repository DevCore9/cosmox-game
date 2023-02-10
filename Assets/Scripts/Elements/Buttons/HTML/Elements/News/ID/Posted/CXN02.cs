  using UnityEngine;
  using System.Collections;
  
  public class CXN02 : MonoBehaviour
  {
      public void OpenURL()
      {
          Application.OpenURL("https://www.cosmox-web.ml/happy-new-year-id02");
          Debug.Log("Loading Script...");
          Debug.Log("Opening the Browser with address https://www.cosmox-web.ml/happy-new-year-id02");
      }
  
  }