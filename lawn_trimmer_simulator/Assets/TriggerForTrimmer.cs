using UnityEngine;

namespace Assets
{
    public class TriggerForTrimmer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // Проверяем, является ли объект, вошедший в триггер, объектом пользователя
            if (other.gameObject.name == "FirstPersonController")
            {
                Debug.Log("Пользователь вошел в триггер");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // Проверяем, является ли объект, вышедший из триггера, объектом пользователя
            if (other.gameObject.name == "FirstPersonController")
            {
                Debug.Log("Пользователь вышел из триггера");
            }
        }
    }

}