using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Luja_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public float time;
    public float R;

    public GameObject[] obj;

    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale += new Vector3(1, 0, 1) * Time.deltaTime * R*M;
    }

    private IEnumerator StCoroutine()
    {

        for (int i = 0; i <= time; i++)
        {
            if (obj != null)
            {
                foreach (var e in obj)
                {
                    if (e != null) e.GetComponent<Enemy>().HP -= e.GetComponent<Enemy>().DefK * M * Dmg / time;
                }
            }
            yield return new WaitForSeconds(1);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            obj = obj.Append(collision.gameObject).ToArray();
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            obj = obj.Where(val => val != collision.gameObject).ToArray();
        }
    }
}