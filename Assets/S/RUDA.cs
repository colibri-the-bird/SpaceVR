using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUDA : MonoBehaviour
{
    public float HP = 100;
    public GameObject[] comp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            System.Random rand = new System.Random();
            Destroy(this.GetComponent<Collider>());
            if (comp != null)
            {
                foreach (var compItem in comp)
                {
                    var clone = Instantiate(compItem,this.transform.position + new Vector3(((float)rand.NextDouble()- 0.5f)*3, (float)rand.NextDouble()*2, ((float)rand.NextDouble() - 0.5f) * 3), Quaternion.identity);
                    clone.GetComponent<Rigidbody>().AddForce(((float)rand.NextDouble() - 0.5f) * 3, (float)rand.NextDouble() * 8, ((float)rand.NextDouble() - 0.5f) * 3, ForceMode.Impulse);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
