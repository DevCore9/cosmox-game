 using UnityEngine;
 using System.Collections;
 
 public class Randomizer : MonoBehaviour
 {
     public AudioClip[] audioClips;
     public AudioSource audioSource;
     public AudioListener audioListener;
 
     // Start is called before the first frame update
     void Start()
     {
         audioListener = GetComponent<AudioListener>();
         audioSource = gameObject.GetComponent<AudioSource>();
     }
 
     // Update is called once per frame
     void Update()
     {
         if (!audioSource.isPlaying)
         {
             PlayRandom();
         }
     }
     void PlayRandom()
     {
         audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
         audioSource.Play();
        
     
     }
 
 
 
     
 }