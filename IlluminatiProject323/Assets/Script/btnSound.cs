using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSound : MonoBehaviour
{
   public AudioSource soundButton;
   public AudioClip hover;
   public AudioClip click;

   public void HoverSound()
   {
      soundButton.PlayOneShot(hover);
   }
   
   public void ClickSound()
   {
      soundButton.PlayOneShot(click);
   }
}
