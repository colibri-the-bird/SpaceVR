using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;
using Oculus.Interaction;

public class Trigger2 : MonoBehaviour
{
    public GameObject[] bots;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bots.Length != 0)
        {
            foreach (var bot in bots)
            {
                if (bot == null)
                {
                    bots = bots.Where(val => val != bot).ToArray();
                }
            }
            if (bots.Length != 0) this.transform.parent.GetComponent<Botik>().finih = bots[0].transform;
        }
        else this.transform.parent.GetComponent<Botik>().finih = null;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null) bots = bots.Append(collision.gameObject).ToArray();

    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            bots = bots.Where(val => val != collision.gameObject).ToArray();
        }
    }
}
