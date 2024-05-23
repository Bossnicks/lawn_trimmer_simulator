using Assets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Assets.TaskController;

namespace Assets
{
    public class RaycastController : MonoBehaviour
    {
        public float rayDistance = 100f; // Дистанция луча
        private string clickedObjectName;
        private TrimmerController trimmerController;
        public static TextMeshProUGUI hintText;
        private Camera playerCamera;
        private Camera explorerCamera;
        private GameObject trimmerDescriptionMenu;
        private FirstPersonController firstPersonCharacter;
        private Sprite crossHairImage;
        private Image reticle;

        GameObject trimmer;
        //Transform trimmerTransform;



        private void Start()
        {
            firstPersonCharacter = GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>();
            reticle = GameObject.Find("Reticle").GetComponent<Image>();
            trimmerDescriptionMenu = GameObject.Find("MenuBackground");
            trimmerDescriptionMenu.SetActive(false);
            explorerCamera = GameObject.Find("explorerCamera").GetComponent<Camera>();
            playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
            explorerCamera.enabled = false;
            playerCamera.enabled = true;
            hintText = hint.GetComponent<TextMeshProUGUI>();
            hintText.text = "Идите на задний двор и возьмите триммер";
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
            Camera activeCamera = playerCamera.enabled ? playerCamera : explorerCamera;
            Vector3 rayVector = activeCamera == playerCamera ? new Vector3(Screen.width / 2, Screen.height / 2, 0) : Input.mousePosition;
            Ray ray = activeCamera.ScreenPointToRay(rayVector);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                clickedObjectName = hit.collider.gameObject.name;
            }

            if (TrimmerClickChecker(clickedObjectName))
            {
                if(currentState == TaskControllerEnum.Beginning)
                {
                    crossHairImage = firstPersonCharacter.crosshairImage;
                    currentState = TaskControllerEnum.TrimmerIsInPreparatoryState;
                    selectedObject = trimmer;
                    hintText.text = Backlight.HintToState();
                    trimmerController.Rotate();
                    playerCamera.enabled = false;
                    explorerCamera.enabled = true;
                    trimmerDescriptionMenu.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    firstPersonCharacter.playerCanMove = false;
                    reticle.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                    

                }
            }
        }
        void PerformRaycastRightClick()
        {

            //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit, rayDistance))
            //{
            //    clickedObjectName = hit.collider.gameObject.name;
            //}
        }
        bool TrimmerClickChecker(string clickedObject)
        {
            string[] validObjectNames = {
                "activate_button", "additional_handle", "barbell", "electric_motor",
                "handle", "corpusKatushki", "osnovaKatushki", "protective_box"
            };
            return System.Array.IndexOf(validObjectNames, clickedObject) >= 0;
        }
    }
}
