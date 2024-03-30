using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine;
using Oculus.Interaction;

public class TriggerTarget : MonoBehaviour
{

    public GameObject[] bots;
    private GameObject player;

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
            if (bots.Length != 0) this.transform.parent.GetComponent<Enemy>().finih = bots[0].transform;
        }
        else if (player != null) this.transform.parent.GetComponent<Enemy>().finih = player.transform;
        else this.transform.parent.GetComponent<Enemy>().finih = null;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            player = collision.gameObject;
        }
        if (collision.gameObject.GetComponent<Botik>() != null) bots = bots.Append(collision.gameObject).ToArray();

    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            player = null;
        }
        if (collision.gameObject.GetComponent<Botik>() != null)
        {
            bots = bots.Where(val => val != collision.gameObject).ToArray();
        }
    }
}
