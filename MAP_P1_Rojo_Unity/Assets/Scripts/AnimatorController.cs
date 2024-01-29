using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator anim;
    CharacterController controller;
    private void OnAnimatorIK(int layerIndex)
    {
        Vector3 _linkVel = controller.velocity;
        if(_linkVel == Vector3.fwd)
        {
            anim.SetInteger("AnimState", 0);
        }
        else if (_linkVel == -Vector3.fwd)
        {
            anim.SetInteger("AnimState", 1);
        }
        else if(_linkVel == Vector3.right)
        {
            anim.SetInteger("AnimState", 2);
        }
    }
}
