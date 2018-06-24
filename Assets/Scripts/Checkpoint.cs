using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Trigger used for evaluating player progress in a lap.
/// </summary>
public class Checkpoint : MonoBehaviour {

    public LapSystem lap;

    private void OnTriggerEnter(Collider other)
    {
        //is it the Player who enters the collider?
        if (other.CompareTag("Player"))
        {
            lap.CheckpointReached(this);
        }        
    }
}
