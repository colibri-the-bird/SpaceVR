using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gravitat_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public float time;
    public float R;
    public float F;

    public GameObject[] obj;

    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * R * M;

    }

    private IEnumerator StCoroutine()
    {
        float T = Time.deltaTime;
        for (int i = 0; i <= time/T; i++)
        {
            if (obj != null)
            {
                foreach (var e in obj)
                {
                    if (e != null)
                    {
                        e.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
                        e.GetComponent<Rigidbody>().AddForce((e.transform.position.x - transform.position.x)*F*M, (e.transform.position.y - transform.position.y)*F*M, 
                            (e.transform.position.z - transform.position.z)*F*M, ForceMode.Acceleration);

                        e.GetComponent<Enemy>().HP -= e.GetComponent<Enemy>().DefK * M * Dmg / time;
                        e.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                        
                    }
                }
            }
            
            yield return new WaitForSeconds(T);
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
