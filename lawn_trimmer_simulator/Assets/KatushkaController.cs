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
        if (other.CompareTag("Rose"))
        {
            gameController.ApplyFlowerPenalty();
            gameController.DecreaseDurability(10);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Fornios"))
        {
            gameController.DecreaseDurability(20);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Kistochka"))
        {
            gameController.DecreaseDurability(20);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Lopuh"))
        {
            gameController.DecreaseDurability(20);
            Destroy(other.gameObject);
        }
    }
}
