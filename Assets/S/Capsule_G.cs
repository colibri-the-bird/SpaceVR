using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_G : MonoBehaviour
{
    public bool Pass = false;
    public bool Capsule_Pass = false;
    public bool CanStart = false;
    public GameObject Mayak;
    private bool d = false;
    private bool a = false;
    private GameObject clone;

    public GameObject civil;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CanStart && !d)
        {
            clone = Instantiate(Mayak, this.transform.position, this.transform.rotation);
            d = true;
        }
        if (Capsule_Pass && !a)
        {
            var clon = Instantiate(civil, this.transform.position, this.transform.rotation);
            clon.GetComponent<Civil>().Parent = this.gameObject;
            CanStart = false;
            Destroy(clone); clone = null;
            a = true;
        }
        if (Pass)
        {
            //4toto
        }
    }
}
