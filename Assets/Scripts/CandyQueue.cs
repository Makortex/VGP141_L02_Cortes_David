using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyQueue : MonoBehaviour
{
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();
    IEnumerator runningCoroutine = null;
    //private Queue<GameObject> candyQueue = new Queue<GameObject>();
    
    public GameObject redCandy;
    public GameObject purpleCandy;

    public Transform spawn;
    public bool isCoroutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnPurple()
    {
        isCoroutineRunning = true;
        runningCoroutine = null;
        yield return new WaitForSeconds(2.0f);
        Instantiate(purpleCandy, spawn);
        isCoroutineRunning = false;
        //coroutineQueue.Dequeue();
    }
    IEnumerator SpawnRed()
    {
        isCoroutineRunning = true;
        runningCoroutine = null;
        yield return new WaitForSeconds(5.0f);
        Instantiate(redCandy, spawn);
        isCoroutineRunning = false;
        //coroutineQueue.Dequeue();
    }
    public void Red()
    {
        if (isCoroutineRunning == false)
        {
            runningCoroutine = SpawnRed();
            StartCoroutine(runningCoroutine);
        }
        else
        {
            coroutineQueue.Enqueue(SpawnRed());
        }
    }
    public void Purple()
    {
        if (isCoroutineRunning == false)
        {
            runningCoroutine = SpawnPurple();
            StartCoroutine(runningCoroutine);

        }
        else
        {
            coroutineQueue.Enqueue(SpawnPurple());
        }
    }
}
