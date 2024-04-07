using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boom_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public float R;
    public GameObject[] en;

    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale += new Vector3(1,1,1)*Time.deltaTime* R*M;
    }

    private IEnumerator StCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (en != null)
        {
            foreach (var e in en)
            {
                if (e != null) e.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            en = en.Append(collision.gameObject).ToArray();
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((transform.position.x - collision.transform.position.x) * 100 * R * M, (transform.position.y - collision.transform.position.y) * 100 * R * M,
                            (transform.position.z - collision.transform.position.z) * 100 * R * M, ForceMode.Impulse);
            collision.gameObject.GetComponent<Enemy>().HP -= collision.gameObject.GetComponent<Enemy>().DefK * M * Dmg / 2;
        }
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (Dmg < 0) 
            {
                collision.gameObject.GetComponent<Enemy>().HP -= collision.gameObject.GetComponent<Player>().DefK * M * Dmg / 2;
            }
        }
    }
}
