using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class center_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Civil>() != null)
        {
            collision.gameObject.GetComponent<Civil>().Parent.GetComponent<Capsule_G>().Time_Pass = true;
            Destroy(collision.gameObject);
        }
    }
}
