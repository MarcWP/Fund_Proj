using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : StateMachineBehaviour
{
    //Clase de referencia. Realmente no utilizada.
    public GameObject player;
    public GameObject monster;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.gameObject;
        player = monster.GetComponent<GoblinController>().player;
    }
}
