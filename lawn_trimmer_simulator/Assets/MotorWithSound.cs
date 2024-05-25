using static Assets.TaskController;
using UnityEngine;

public class MotorWithSound : MonoBehaviour
{
    public float rotationSpeed = 100f; // �������� �������� � �������� � �������
    private AudioSource audioSource;
    public static bool trimmerIsWorking = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this game object.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && currentState == TaskControllerEnum.MowingHasBegun) // ���������, ������������ �� ������ ������ ����
        {
            trimmerIsWorking = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            trimmerIsWorking = false;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
