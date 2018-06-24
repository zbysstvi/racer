using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// LapSystem measures lapTimes, stores records, makes sure player can't race in the opposite direction
/// </summary>
public class LapSystem : MonoBehaviour {

    public Checkpoint[] checkpoints;
    public int currentCheckpoint;

    public GameObject currentLap;
    public GameObject bestLap;

    private float currentTime;
    private float bestTime;

	// Use this for initialization
	void Start () {

        currentCheckpoint = 0;
        bestTime = 9999; //for first evaluation

        //reference to checkpoints
        //foreach is slower
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].lap = this;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //update time
        currentTime += Time.deltaTime;
        var timeSpan = System.TimeSpan.FromSeconds(currentTime);
        currentLap.GetComponent<Text>().text = "Current  Lap: " + string.Format("{0:0}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);		
	}

    //player reached one of the checkpoints
    public void CheckpointReached(Checkpoint cp)
    {

        //is player going foward?
        if (cp == checkpoints[currentCheckpoint])
        {
            //is it the last checkpoint in a lap (= finish line)? if so reset lap
            if (currentCheckpoint == checkpoints.Length - 1)
            {
                EndLap();

            }

            //it is not last checkpoint, set current checkpoint to next one
            else
            {
                currentCheckpoint++;
                print(currentCheckpoint);
            }
        }
    }

     //lap finished
     public void EndLap()
    {

        //if current lap was a record, update HUD
        if (currentTime < bestTime)
        {
            bestTime = currentTime;
            var timeSpan = System.TimeSpan.FromSeconds(bestTime);
            bestLap.GetComponent<Text>().text = "Best  Lap: " + string.Format("{0:0}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        }

        //reset laptime + checkpoints
        currentTime = 0;
        currentCheckpoint = 0;
    }


}
