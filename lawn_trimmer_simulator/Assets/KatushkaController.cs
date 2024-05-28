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
                if (GameController.Instance.lineDurability >= 5)
                {
                    Destroy(other.gameObject);
                }
                gameController.DecreaseDurability(5);
                //gameController.ApplyFlowerPenalty();
                Debug.Log("rose destroy");
                GameController.flowerCount++;

            }
            if (other.CompareTag("Fornios"))
            {
                if (gameController.currentLineType == GameController.LineType.Strong || gameController.currentLineType == GameController.LineType.Medium)
                {
                    if (GameController.Instance.lineDurability >= 10)
                    {
                        Destroy(other.gameObject);
                    }
                    gameController.DecreaseDurability(10);
                }
                else
                {
                    if (GameController.Instance.lineDurability >= 30)
                    {
                        Destroy(other.gameObject);
                    }
                    gameController.DecreaseDurability(30);
                }
            }
            if (other.CompareTag("Kistochka"))
            {
                if (GameController.Instance.lineDurability >= 5)
                {
                    Destroy(other.gameObject);
                }
                gameController.DecreaseDurability(5);
            }
            if (other.CompareTag("Lopuh"))
            {
                if (gameController.currentLineType == GameController.LineType.Strong)
                {
                    if (GameController.Instance.lineDurability >= 40)
                    {
                        Destroy(other.gameObject);
                    }
                    gameController.DecreaseDurability(40);
                }
                else if (gameController.currentLineType == GameController.LineType.Medium)
                {
                    if (GameController.Instance.lineDurability >= 120)
                    {
                        Destroy(other.gameObject);
                    }
                    gameController.DecreaseDurability(120);
                }
                else
                {
                    if (GameController.Instance.lineDurability >= 360)
                    {
                        Destroy(other.gameObject);
                    }
                    gameController.DecreaseDurability(360);
                }
            }
        }
    }
}
