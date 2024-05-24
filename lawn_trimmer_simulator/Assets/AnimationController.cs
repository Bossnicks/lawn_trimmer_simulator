using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static Animator animator;

    void Start()
    {



        
    }

    private void Update()
    {
    }

    public static void BeginAnimate(string obj)
    {
        animator = GameObject.Find(obj).GetComponent<Animator>();
        if (animator != null)
        {
            Debug.Log(obj);
        }

        switch (obj)
        {
            case "corpusKatushki":
                if(TaskController.currentStudyState == TaskController.StudyTaskControllerEnum.OpenKatushka)
                {
                    animator.SetBool("OpenOsnova", true);
                }  
                else if(TaskController.currentStudyState == TaskController.StudyTaskControllerEnum.CloseKatushka) 
                {
                    animator.SetBool("OpenOsnova", false);
                }
                break;
        }
    }
}
