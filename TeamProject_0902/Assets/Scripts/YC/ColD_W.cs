using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColD_W : MonoBehaviour
{
    Animator animator;
    public GameObject aura;
    public GameObject shield;

    public GameObject flame;

    public GameObject Direction;
    public GameObject grenade;
    
   [SerializeField] private Transform grenade_Bomb;
   protected float DirecAngle; //e키 방향각도
    protected float R_DirecAngle; //r키 방향각도
   // protected Vector3 BombDirec;

    public GameObject missile;
    public GameObject Range;
    public GameObject RangeDirection;
    public GameObject missile_target_effect;

    //마우스 좌표 저장용(임시)
    Vector3 mouseVector;
    
    void Start()
    {
        aura.SetActive(false);
        shield.SetActive(false);

        flame.SetActive(false);

        Direction.SetActive(false);
        grenade.SetActive(false);

        missile.SetActive(false);
        Range.SetActive(false);
        RangeDirection.SetActive(false);
      //  missile_target_effect.SetActive(false);
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (animator.GetBool("A_ColD") == false)
                StartCoroutine("Active_A");
            animator.SetBool("A_ColD", true);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(animator.GetBool("W_ColD")==false)
            StartCoroutine("Active_W");
            animator.SetBool("W_ColD", true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (animator.GetBool("Q_ColD") == false)
                StartCoroutine("Active_Q");
            animator.SetBool("Q_ColD", true);
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

         Transform grenadeTransform =  Instantiate(grenade_Bomb, grenade.transform.position,
        Quaternion.identity); //유탄발사 and transform 저장

            Vector3 nextDir = new Vector3(mouseVector.x, grenade.transform.position.y, mouseVector.z);
            Vector3 shootDir = (nextDir- grenade.transform.position).normalized; //마우스좌표 -발사좌표
           
            grenadeTransform.GetComponent<PFX_ProjectileObject>().Setup(shootDir); //유탄에 방향전달



            if (animator.GetBool("E_ColD") == false)
            {
                StartCoroutine("Active_E");
            }
            animator.SetBool("E_ColD", true);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            mouseVector = GetMousePos(); //화살 방향 마우스방향에 미리 이동
            Direction.SetActive(true); //방향화살 active
            //화살표 위치 고정
        }
        if (Input.GetKey(KeyCode.R))
        {
            Direction.transform.position = mouseVector;
            Range.SetActive(true);
            GetRdirect(); //get R_DirecAngle
            Direction.transform.rotation = 
                Quaternion.AngleAxis(R_DirecAngle, Vector3.up);

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            Range.SetActive(false);
           Direction.SetActive(false);
            if (animator.GetBool("R_ColD") == false)
                StartCoroutine("Active_R");
            animator.SetBool("R_ColD", true);
        }
    }
    IEnumerator Active_A()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            animator.SetBool("A_ColD", false);
            break;
        }
    }
    IEnumerator Active_Q()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            flame.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            animator.SetBool("Q_ColD", false);
            yield return new WaitForSeconds(0.5f);
            flame.SetActive(false);
     
            break;
        }
    }
    IEnumerator Active_W()
    {
        while (true)
        {
            aura.SetActive(true);
            shield.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            aura.SetActive(false);
            shield.SetActive(false);
            animator.SetBool("W_ColD", false);
            break;
        }
    }
    IEnumerator Active_E()
    {
        while (true)
        {
            grenade.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            grenade.SetActive(false);
            animator.SetBool("E_ColD", false);
            break;
        }
    }
    IEnumerator Active_R()
    {
        while (true)
        {
            missile.SetActive(true);
            yield return new WaitForSeconds(0.67f);
            missile.SetActive(false);
            animator.SetBool("R_ColD", false);
            break;
        }
        while (true)
        {
          
            missile_target_effect.transform.position =
                new Vector3(Direction.transform.position.x, 12.5f, Direction.transform.position.z);
            //미사일 타겟 위치

            Instantiate(missile_target_effect, missile_target_effect.transform.position,
          Direction.transform.rotation); //유탄발사

            yield return new WaitForSeconds(4.5f);
            break;
        }
    }

   Vector3 GetMousePos()
    {
   
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);
        //마우스 위치 받아서 각도계산
        DirecAngle = Mathf.Atan2( hit.point.x - Direction.transform.position.x,
            hit.point.z - Direction.transform.position.z) * Mathf.Rad2Deg;

        mouseVector = hit.point;

        return hit.point;
    }

    void GetRdirect()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

        R_DirecAngle = Mathf.Atan2(hit.point.x - Direction.transform.position.x,
        hit.point.z - Direction.transform.position.z) * Mathf.Rad2Deg;
    }
}
