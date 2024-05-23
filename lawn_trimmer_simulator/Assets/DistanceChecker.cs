using Assets;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    private float minDistance = 5f;

    void Update()
    {
        if (TaskController.currentState == TaskController.TaskControllerEnum.TrimmerIsInPreparatoryState)
        {
            if (player == null)
            {
                Debug.LogError("Player transform is not assigned.");
                return;
            }

            // Игнорируем компонент Y при вычислении расстояния и направлении
            Vector3 positionNoY = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 playerPositionNoY = new Vector3(player.position.x, 0, player.position.z);

            float distance = Vector3.Distance(positionNoY, playerPositionNoY);

            if (distance < minDistance)
            {
                Vector3 direction = (playerPositionNoY - positionNoY).normalized;
                Vector3 newPositionNoY = positionNoY + direction * minDistance;

                // Сохраняем компонент Y игрока
                player.position = new Vector3(newPositionNoY.x, player.position.y, newPositionNoY.z);
            }
        }
    }
}
