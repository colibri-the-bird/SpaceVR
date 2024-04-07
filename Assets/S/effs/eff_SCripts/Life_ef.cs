using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Life_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public float time;
    public float R;


    public GameObject[] obj;

    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1) * R * M;
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

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
                        if (e.GetComponent<Enemy>() != null)
                            e.GetComponent<Enemy>().HP -= e.GetComponent<Enemy>().DefK * M * Dmg / time;
                        if (e.GetComponent<Player>() != null)
                            e.GetComponent<Enemy>().HP -= e.GetComponent<Player>().DefK * M * Dmg / time;
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.GetComponent<Enemy>() != null)&& (collision.gameObject.GetComponent<Player>() != null))
        {
            obj = obj.Append(collision.gameObject).ToArray();
        }
    }
}
