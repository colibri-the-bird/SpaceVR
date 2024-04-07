using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject[] Task_obj;
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Task_obj[0].GetComponent<Capsule_G>() != null) 
        {
            Task_obj[0].GetComponent<Capsule_G>().CanStart = true;
            if (Task_obj[0].GetComponent<Capsule_G>().Pass == true)
            {
                if (Task_obj.Length == 1) win = true;
                Task_obj = Task_obj.Where(val => val != Task_obj[0]).ToArray();
            }
        }
        if (win)
        {
            print("Winnnn");
        }
    }
}
