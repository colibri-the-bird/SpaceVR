using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Void_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public float time;
    public float R;

    private bool sttt;


    public GameObject[] obj;

    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!sttt) this.gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * R * M;
    }

    private IEnumerator StCoroutine()
    {

        for (int i = 0; i <= time; i++)
        {
            if (obj != null)
            {
                foreach (var e in obj)
                {
                    if (e != null)
                    {
                        e.transform.position -= new Vector3(0,42,0);
                        e.GetComponent<Enemy>().HP -= e.GetComponent<Enemy>().DefK * M * Dmg / time;
                    }
                }
            }
            if (i >= time / 2)
            {
                Destroy(GetComponent<MeshRenderer>());
                sttt = true;
            }
            yield return new WaitForSeconds(1);
        }
        foreach (var e in obj)
        {
            if (e != null)
            {
                e.GetComponent<Rigidbody>().velocity = Vector3.zero;
                e.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                e.transform.position = new Vector3(e.transform.position.x, transform.position.y + 1 , e.transform.position.z);
            }
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
}
