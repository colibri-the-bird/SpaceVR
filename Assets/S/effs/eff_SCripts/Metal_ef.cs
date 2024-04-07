using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Metal_ef : MonoBehaviour
{

    public float M = 1f;

    public float Dmg;
    public float time;
    public float K;
    public bool ef2;


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
        yield return new WaitForSeconds(time / 10);
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
        yield return new WaitForSeconds(9 * time / 10);
        foreach (var e in obj)
        {
            if (e != null)
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

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal_ef : MonoBehaviour
{

    public float M = 1f;

    public float Dmg;
    public float time;
    public float K;

    public bool ef2;

    public GameObject obj;

    void Start()
    {

        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale += new Vector3(1, 0, 1) * Time.deltaTime * R * M;
        this.GetComponent<Rigidbody>().AddForce((obj.transform.position.x - transform.position.x) * M * Time.deltaTime,
            (obj.transform.position.y - transform.position.y) * M * Time.deltaTime, (obj.transform.position.z - transform.position.z) * M * Time.deltaTime, ForceMode.Acceleration);
    }

    private IEnumerator StCoroutine()
    {

        for (int i = 0; i <= time; i++)
        {
            if (obj != null)
            {
                foreach (var e in obj)
                {
                    if (e != null) e.GetComponent<Enemy>().HP -= e.GetComponent<Enemy>().DefK * M * Dmg * 2 / time;
                }
            }
            yield return new WaitForSeconds(2);
        }
        Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider collision)
    {
        if ((collision.gameObject.GetComponent<Enemy>() != null) && ((obj == null) | (Vector3.Distance(this.transform.position, obj.transform.position) < Vector3.Distance(this.transform.position, collision.transform.position))))
        {
            obj = collision.gameObject;
        }
    }
}*/
