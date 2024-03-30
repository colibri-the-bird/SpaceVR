using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP = 100;
    public float DefK = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
