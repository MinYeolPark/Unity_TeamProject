using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player_Movement : MonoBehaviour
{
    protected Animator avatar;
    float lastAttackTime, lastSkillTime, lastDashTime;
    public bool attacking = false;
    public bool dashing = false;
    void Start()
    {
        avatar = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());
    }
    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking = false;
    }

    IEnumerator StartAttack()
    {
        if (Time.time - lastAttackTime > 1f) 
        {
            lastAttackTime = Time.time;
            while(attacking)
            {
                avatar.SetTrigger("AttackStart");
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
