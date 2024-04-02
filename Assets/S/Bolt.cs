using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float Dmg_T;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Destroy(this.gameObject.GetComponent<MeshRenderer>());
        Destroy(this.gameObject.GetComponent<Collider>());
        if (collision.gameObject.GetComponent<Enemy>() != null) collision.gameObject.GetComponent<Enemy>().HP -= Dmg_T*10;
        if (collision.gameObject.GetComponent<RUDA>() != null) collision.gameObject.GetComponent<RUDA>().HP -= Dmg_T;
        Destroy(this.gameObject);
    }
    private IEnumerator StCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
