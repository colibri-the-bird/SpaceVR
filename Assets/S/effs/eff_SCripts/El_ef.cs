using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class El_ef : MonoBehaviour
{
    public float M = 1f;

    public float Dmg;
    public int Kvo;
    public List<GameObject> en = new List<GameObject>();

    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StCoroutine()
    {
        yield return new WaitForSeconds(Time.deltaTime*5);
        this.gameObject.transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * 100;
        if ((Kvo <= 0)|(this.gameObject.transform.localScale.x >= 20)) Destroy(this.gameObject);
        StartCoroutine(StCoroutine());
    }

    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.GetComponent<Enemy>() != null)&&(!en.Contains(collision.gameObject))&&(Kvo>0))
        {
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            UnityEngine.Debug.DrawLine(this.gameObject.transform.position, collision.transform.position, Color.cyan);
            this.gameObject.transform.position = collision.transform.position;
            en.Add(collision.gameObject);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 200, 0, ForceMode.Impulse);
            collision.gameObject.GetComponent<Enemy>().HP -= collision.gameObject.GetComponent<Enemy>().DefK * Dmg / 4;
            Kvo--;
        }
    }
}