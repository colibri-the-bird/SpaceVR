using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public float HP = 1000;
    public float DefK = 1;
    private bool d;

    Animator animator;
    //================================================================
    public Transform finih;
    RaycastHit Hit;
    bool stena, stenaTime;
    Vector3 PovorotDlaObxoda;
    Transform TargetPregrada;
    Vector3 NapravlenieLy4a;
    public Transform[] ForvardRay;
    public Transform[] LeftRay;
    public Transform[] RightRay;

    Transform[] pointRay;
    int distansRay = 3;
    public float speedCube = 3;
    public float R;
    float timeFlag;


    //================================================================


    public GameObject[] obj;
    public GameObject[] floor;
    private bool atc;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finih == null)
        {
            animator.ResetTrigger("Move");
        }
        if (obj.Length == 0)
        {
            animator.ResetTrigger("Attack");
        }
        if (HP <= 0)
        {
            finih = null;
            animator.SetTrigger("Dead");
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mamalien_Death")) d = true;
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Mamalien_Death") && d)
        {
            Destroy(this.gameObject);
        }
        if ((finih != null)&&(floor.Length != 0))
        {
            animator.SetTrigger("Move");
            //непрерывное движение куба пока то не достигнет цели
            if (Vector3.Distance(finih.position, transform.position) > R)
            {
                transform.position += transform.forward * speedCube * Time.deltaTime;
            }
            if (!stena)
            {
                //дебаг линия от куба к цели
                UnityEngine.Debug.DrawLine(finih.position, transform.position, Color.red);
                //поворот в направлении основной цели
                transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(finih.position - transform.position), Time.deltaTime * 2f);
                NapravlenieLy4a = transform.forward;
                pointRay = ForvardRay;
                distansRay = 2;
            }
            else
            {
                if (TargetPregrada != null)
                {
                    // меняем направление луча в случае запуска опции обхода преграды
                    NapravlenieLy4a = OptionRay(TargetPregrada, transform);
                    //меняем точки пускания лучей на самые ближние к преграде
                    pointRay = NapravlenieLy4a == -transform.right ? LeftRay : RightRay;
                    distansRay = 4;
                }
            }
            byte rayIntPoint = 0;
            for (int i = 0; i < pointRay.Length; i++)
            {
                //лучи в дебаге
                UnityEngine.Debug.DrawRay(pointRay[i].position, NapravlenieLy4a, Color.green);
                //пускаем лучи из выбранных точек
                if (Physics.Raycast(pointRay[i].position, NapravlenieLy4a, out Hit, distansRay))
                {
                    if ((NapravlenieLy4a == transform.forward)&&(Hit.collider.gameObject.GetComponent<Player>() == null)&&(Hit.collider.gameObject.GetComponent<Botik>() == null)&&(Hit.collider.gameObject.GetComponent<Enemy>() == null))
                    {
                        stena = true;
                        TargetPregrada = Hit.transform;
                        //поворачиваем наш кубик к ближайшему краю преграды
                        transform.localRotation = Quaternion.Euler(OptionDirection(TargetPregrada, transform));
                    }
                    else stena = true;
                    break;
                }
                else if ((NapravlenieLy4a != transform.forward && !stenaTime) && (TargetPregrada != null))
                {
                    rayIntPoint++;
                    if (rayIntPoint >= pointRay.Length)
                    {
                        //разворачиваем кубик в исходное положение и даем ему 1 секунду чтобы пройти мимо преграды и не цеплятся за края,
                        //далее снова включаем курс на конечную цель
                        timeFlag = Time.time+2;
                        stenaTime = true;
                        Vector3 povorot = TargetPregrada.rotation.eulerAngles;
                        transform.localRotation = Quaternion.Euler(povorot);
                    }
                }
            }
            if (timeFlag + 1 < Time.time && stenaTime)
            {
                stenaTime = false;
                stena = false;
            }
        }
    }
    Vector3 OptionDirection(Transform block, Transform myTransform)
    {
        Vector3 vec = block.transform.rotation.eulerAngles;
        vec.y = block.transform.position.x < myTransform.position.x ? vec.y += 90 : vec.y -= 90;
        return vec;
    }
    //выбор направлния лучей
    Vector3 OptionRay(Transform block, Transform myTransform)
    {
        Vector3 vec;
        return vec = TargetPregrada.position.x < myTransform.position.x ? -myTransform.right : myTransform.right;
    }
    private IEnumerator StCoroutine()
    {

        while (atc) 
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 2);
            if (obj != null)
            {
                foreach (var e in obj)
                {
                    if (e != null)
                    {
                        if (e.GetComponent<Player>() != null)
                        {
                            e.GetComponent<Player>().HP -= e.GetComponent<Player>().DefK * 20;
                        }

                        if (e.GetComponent<Botik>() != null)
                        {
                            e.GetComponent<Botik>().HP -= e.GetComponent<Botik>().DefK * 20;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length/2);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        floor = floor.Append(collision.gameObject).ToArray();
    }
    private void OnCollisionExit(Collision collision)
    {
        floor = floor.Where(val => val != collision.gameObject).ToArray();
    }
    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.GetComponent<Player>() != null)|(collision.gameObject.GetComponent<Botik>() != null))
        {
            obj = obj.Append(collision.gameObject).ToArray();
            atc = true;
            StartCoroutine(StCoroutine());
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if ((collision.gameObject.GetComponent<Player>() != null)|(collision.gameObject.GetComponent<Botik>() != null))
        {
            obj = obj.Where(val => val != collision.gameObject).ToArray();
            atc = false;
            StopCoroutine(StCoroutine());
        }
    }
}
