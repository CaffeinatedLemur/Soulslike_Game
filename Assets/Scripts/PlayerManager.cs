using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NightBook
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputhandler;
        Animator anim;

        void Start()
        {
            inputhandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputhandler.isInteracting = anim.GetBool("isInteracting");
            inputhandler.rollFlag = false;
            inputhandler.sprintFlag = false;

        }
    }

}
