using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Death_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public float time;
    public float K;


    public GameObject[] obj;

    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(2, 2, 2) * M;
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StCoroutine()
    {
        yield return new WaitForSeconds(time/10);
        foreach (var e in obj)
        {
            if (e != null)
            {
                if (e.GetComponent<Enemy>() != null)
                    e.GetComponent<Enemy>().DefK = e.GetComponent<Enemy>().DefK * K * M;
                if (e.GetComponent<Player>() != null)
                    e.GetComponent<Player>().DefK = e.GetComponent<Player>().DefK * K * M;
            }
        }
        yield return new WaitForSeconds(9*time/10);
        foreach (var e in obj)
        {
            if ( e != null)
            {
                if (e.GetComponent<Enemy>() != null)
                    e.GetComponent<Enemy>().DefK = e.GetComponent<Enemy>().DefK / K / M;
                if (e.GetComponent<Player>() != null)
                    e.GetComponent<Player>().DefK = e.GetComponent<Player>().DefK / K / M;
            }
        }
        
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.GetComponent<Enemy>() != null) && (collision.gameObject.GetComponent<Player>() != null))
        {
            obj = obj.Append(collision.gameObject).ToArray();
        }
    }
}
