using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Animator anim;

    void Start() 
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update() 
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("BonesAttack"))
        {
            //Damage();
        }
    }

}
