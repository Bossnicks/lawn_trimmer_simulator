using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatushkaController : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameController.Instance;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(MotorWithSound.trimmerIsWorking && TaskController.currentState == TaskController.TaskControllerEnum.MowingHasBegun)
        {
            if (other.CompareTag("Rose"))
            {
                gameController.DecreaseDurability(5);
                gameController.ApplyFlowerPenalty();
                Debug.Log("rose destroy");
                if (TaskController.currentState == TaskController.TaskControllerEnum.MowingHasBegun)
                {
                    Destroy(other.gameObject);
                }
            }
            if (other.CompareTag("Fornios"))
            {
                if (gameController.currentLineType == GameController.LineType.Strong || gameController.currentLineType == GameController.LineType.Medium)
                {
                    gameController.DecreaseDurability(10);
                }
                else
                {
                    gameController.DecreaseDurability(30);
                }
                if (TaskController.currentState == TaskController.TaskControllerEnum.MowingHasBegun)
                {
                    Destroy(other.gameObject);
                }
            }
            if (other.CompareTag("Kistochka"))
            {
                gameController.DecreaseDurability(5);
                if (TaskController.currentState == TaskController.TaskControllerEnum.MowingHasBegun)
                {
                    Destroy(other.gameObject);
                }
            }
            if (other.CompareTag("Lopuh"))
            {
                if (gameController.currentLineType == GameController.LineType.Strong)
                {
                    gameController.DecreaseDurability(40);
                }
                else if (gameController.currentLineType == GameController.LineType.Medium)
                {
                    gameController.DecreaseDurability(120);
                }
                else
                {
                    gameController.DecreaseDurability(360);
                }
                if(TaskController.currentState == TaskController.TaskControllerEnum.MowingHasBegun)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
