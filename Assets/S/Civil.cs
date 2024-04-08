using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : MonoBehaviour
{
    Animator animator;
    public GameObject Parent;
    public float HP = 100;
    private bool d;
    public float DefK = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            animator.SetTrigger("Dead");
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mamalien_Death")) d = true;
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Mamalien_Death") && d)
        {
            Destroy(this.gameObject);
        }
    }
}
