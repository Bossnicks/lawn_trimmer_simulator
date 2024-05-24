using static Assets.TaskController;
using UnityEngine;

public class MotorWithSound : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения в градусах в секунду
    private AudioSource audioSource;

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
        if (Input.GetMouseButton(1) && currentState == TaskControllerEnum.MowingHasBegun) // Проверяем, удерживается ли правая кнопка мыши
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
