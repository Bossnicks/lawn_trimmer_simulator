using UnityEngine;

public class TrimmerController : MonoBehaviour
{
    private Transform trimmerTransform;
    private bool isRotating = false;
    private bool rotateForward = false; // ���������� ��� ���������� ������������ ��������
    public float rotationSpeed = 60f; // �������� ��������
    public float moveSpeed = 1f; // �������� ������������
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
                trimmerTransform.rotation = targetRotation; // ������������ ������ ����������
                trimmerTransform.position = targetPosition; // ������������ ������ ����������
            }
        }
    }

    public void Rotate()
    {
        if (!isRotating)
        {
            isRotating = true;
            rotateForward = !rotateForward; // ����������� ����������� ��������

            // ������������� ������� ���������� � ������� � ����������� �� �����������
            targetRotation = rotateForward ? Quaternion.Euler(90f, 0f, 0f) * initialRotation : initialRotation;
            targetPosition = rotateForward ? initialPosition + new Vector3(0f, 0.005f, -0.01f) : initialPosition;
        }
    }
}
