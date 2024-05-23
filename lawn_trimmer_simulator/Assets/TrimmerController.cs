using UnityEngine;

public class TrimmerController : MonoBehaviour
{
    private Transform trimmerTransform;
    private bool isRotating = false;
    private bool rotateForward = false; // Переменная для управления направлением поворота
    public float rotationSpeed = 60f; // Скорость вращения
    public float moveSpeed = 1f; // Скорость передвижения
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        trimmerTransform = transform;
        initialPosition = trimmerTransform.position;
        initialRotation = trimmerTransform.rotation;
    }

    void Update()
    {
        if (isRotating)
        {
            float rotateStep = rotationSpeed * Time.deltaTime;
            trimmerTransform.rotation = Quaternion.RotateTowards(trimmerTransform.rotation, targetRotation, rotateStep);

            float moveStep = moveSpeed * Time.deltaTime;
            trimmerTransform.position = Vector3.Lerp(trimmerTransform.position, targetPosition, moveStep);

            if (Quaternion.Angle(trimmerTransform.rotation, targetRotation) < 1f && Vector3.Distance(trimmerTransform.position, targetPosition) < 0.001f)
            {
                isRotating = false;
                trimmerTransform.rotation = targetRotation; // Обеспечиваем точное совпадение
                trimmerTransform.position = targetPosition; // Обеспечиваем точное совпадение
            }
        }
    }

    public void Rotate()
    {
        if (!isRotating)
        {
            isRotating = true;
            rotateForward = !rotateForward; // Инвертируем направление поворота

            // Устанавливаем целевую ориентацию и позицию в зависимости от направления
            targetRotation = rotateForward ? Quaternion.Euler(90f, 0f, 0f) * initialRotation : initialRotation;
            targetPosition = rotateForward ? initialPosition + new Vector3(0f, 0.005f, -0.01f) : initialPosition;
        }
    }
}
