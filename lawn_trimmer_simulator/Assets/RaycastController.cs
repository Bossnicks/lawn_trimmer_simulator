using Assets;
using UnityEngine;
using static Assets.TaskController;

namespace Assets
{
    public class RaycastController : MonoBehaviour
    {
        public float rayDistance = 100f; // Дистанция луча
        private string clickedObjectName;
        private TrimmerController trimmerController;

        GameObject trimmer;
        //Transform trimmerTransform;



        private void Start()
        {
            trimmer = GameObject.Find("Trimmer");
            trimmerController = trimmer.GetComponent<TrimmerController>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PerformRaycastLeftClick();
            }
            if (Input.GetMouseButtonDown(1))
            {
                PerformRaycastRightClick();
            }
        }

        void PerformRaycastLeftClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                clickedObjectName = hit.collider.gameObject.name;
            }

            if (clickedObjectName == "Trimmer")
            {
                if(currentState == TaskControllerEnum.Beginning)
                {
                    selectedObject = trimmer;
                    //trimmerControllertrimmerController.Rotate(0, 0, 0);
                }
            }
        }
        void PerformRaycastRightClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                clickedObjectName = hit.collider.gameObject.name;
            }
            if (TrimmerClickChecker(clickedObjectName))
            {
                trimmerController.Rotate();
            }
        }
        bool TrimmerClickChecker(string clickedObject)
        {
            string[] validObjectNames = {
                "activate_button", "additional_handle", "barbell", "electric_motor",
                "handle", "corpusKatushki", "osnovaKatushki", "protective_box"
            };
            Debug.Log(clickedObjectName);
            return System.Array.IndexOf(validObjectNames, clickedObject) >= 0;
        }
    }
}
