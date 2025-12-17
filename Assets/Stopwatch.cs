using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour
{
   bool stopwatchActive = false;
   float currentTime;
   public Text timerText;

   void Start () {
    currentTime = 0;
   }

   void Update() {
    if (stopwatchActive == true) {
        currentTime = currentTime + Time.deltaTime;
        }
    TimeSpan time = TimeSpan.FromSeconds(currentTime);
    timerText.text = time.ToString(@"mm\:ss\:fff");
   }

   public void StartStopwatch() {
    stopwatchActive = true;
   }

   public void StopStopwatch() {
    stopwatchActive = false;
   } 
}
