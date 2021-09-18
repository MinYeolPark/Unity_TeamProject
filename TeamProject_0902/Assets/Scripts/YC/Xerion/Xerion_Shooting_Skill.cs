using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xerion_Shooting_Skill : MonoBehaviour
{
    Animator animator;

    public GameObject GunShot;

    public GameObject Laser;

    public GameObject Direction;
    public GameObject Range;
    // public GameObject RangeDirection;



    [SerializeField] private GameObject satellite;
    [SerializeField] private GameObject satellite_range;


    protected float DirecAngle; //e키 방향각도
    [SerializeField] private Transform grenade;
    [SerializeField] private GameObject grenadeEffect;


    [SerializeField] private GameObject Drone_Range;
    private bool DroneReload;

    //마우스 좌표 저장용(임시)
    Vector3 mouseVector;

    void Start()
    {
        GunShot.SetActive(false);
        Direction.SetActive(false);
        Range.SetActive(false);

        // RangeDirection.SetActive(false);
        satellite_range.SetActive(false);
        DroneReload = false;

        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (animator.GetBool("A_Xerion") == false)
                StartCoroutine("Active_A");
            animator.SetBool("A_Xerion", true);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Direction.transform.position = Range.transform.position; //캐릭터가운데로 화살이동
            Direction.SetActive(true); //총방향 설정 -> 총 active
            GetMousePos();  //마우스 위치 받아와서 방향 바라보게 하기
            Direction.transform.rotation = Quaternion.AngleAxis(DirecAngle, Vector3.up); //각도setting
            ycManager.Instance.PlayerDirection = DirecAngle; //플레이어에 방향전달
        }
        if (Input.GetKeyUp(KeyCode.Q))  //E키 떼는 순간 스킬 시작
        {
            Direction.SetActive(false);

            if (animator.GetBool("A_Xerion") == false)
            {
                StartCoroutine("Active_Q");
            }
            animator.SetBool("A_Xerion", true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            satellite_range.SetActive(true);    //위성공격 범위 active
            Range.SetActive(true); //스킬범위 active
        }
        if (Input.GetKey(KeyCode.W))
        {
            satellite_range.transform.position = GetMousePos(); //위성공격범위 마우스위치에 이동
        }
        if (Input.GetKeyUp(KeyCode.W))  //E키 떼는 순간 스킬 시작
        {
            Range.SetActive(false);
            satellite_range.SetActive(false);

            if (animator.GetBool("W_Xerion") == false)
            {
                StartCoroutine("Active_W");
            }
            animator.SetBool("W_Xerion", true);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Direction.transform.position = Range.transform.position; //캐릭터가운데로 화살이동
            Direction.SetActive(true); //화살방향 설정 -> 화살 active
            GetMousePos();  //마우스 위치 받아와서 방향 바라보게 하기
            Direction.transform.rotation = Quaternion.AngleAxis(DirecAngle, Vector3.up); //각도setting
            ycManager.Instance.PlayerDirection = DirecAngle; //플레이어에 방향전달
        }
        if (Input.GetKeyUp(KeyCode.E))  //E키 떼는 순간 스킬 시작
        {
            Direction.SetActive(false);

            Transform grenadeTransform = Instantiate(grenade, grenadeEffect.transform.position,
Quaternion.identity); //유탄발사 and transform 저장

            Vector3 nextDir = new Vector3(mouseVector.x, grenadeEffect.transform.position.y, mouseVector.z);
            Vector3 shootDir = (nextDir - grenadeEffect.transform.position).normalized; //마우스좌표 -발사좌표

            grenadeTransform.GetComponent<PFX_ProjectileObject>().Setup(shootDir); //유탄에 방향전달

            if (animator.GetBool("E_Xerion") == false)
            {
                StartCoroutine("Active_E");
            }
            animator.SetBool("E_Xerion", true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            satellite_range.SetActive(true);    
            Drone_Range.SetActive(true);
            satellite_range.transform.position = GetMousePos();
        }
        if (Input.GetKey(KeyCode.R))
        {
            satellite_range.transform.position = GetMousePos(); 
        }
        if (Input.GetKeyUp(KeyCode.R))  
        {
            Drone_Range.SetActive(false);
            satellite_range.SetActive(false);

            if (animator.GetBool("W_Xerion") == false)
            {
                StartCoroutine("Active_W");
            }
            animator.SetBool("W_Xerion", true);
        }
    }
    IEnumerator Active_A()
    {
        while (true)
        {
            GunShot.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            GunShot.SetActive(false);
            animator.SetBool("A_Xerion", false);
            break;
        }
    }
    IEnumerator Active_E()
    {
        while (true)
        {
            grenadeEffect.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            grenadeEffect.SetActive(false);
            animator.SetBool("E_Xerion", false);
            break;
        }
    }
    IEnumerator Active_W()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(satellite, satellite_range.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
            Destroy(satellite);
            animator.SetBool("W_Xerion", false);
            break;
        }
    }
    IEnumerator Active_Q()
    {
        while (true)
        {
            Laser.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            Laser.SetActive(false);
            animator.SetBool("A_Xerion", false);
            break;
        }
    }
    Vector3 GetMousePos()
    {

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);
        //마우스 위치 받아서 각도계산
        DirecAngle = Mathf.Atan2(hit.point.x - Direction.transform.position.x,
            hit.point.z - Direction.transform.position.z) * Mathf.Rad2Deg;

        return hit.point;
    }
}
