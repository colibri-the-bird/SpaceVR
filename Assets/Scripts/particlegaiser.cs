using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlegaiser : MonoBehaviour
{
    public GameObject fire;
    public GameObject smoke;
    int timeInSec = 5;
    IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        GameObject copiedThing = Instantiate(fire);
        yield return new WaitForSeconds(timeInSec);
        Destroy(copiedThing);
        GameObject copiedThing1 = Instantiate(smoke);
        yield return new WaitForSeconds(timeInSec);
        Destroy(copiedThing1);
    }
}
    