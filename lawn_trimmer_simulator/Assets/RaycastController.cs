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
        GameObject trainLezka;
        GameObject osnovaKatushki;
        GameObject firstLezka;
        GameObject secondLezka;
        GameObject statistic;
        private float rotationSpeed = 10f; 


        GameObject trimmer;
        //Transform trimmerTransform;



        private void Start()
        {
            trimmer = GameObject.Find("Trimmer");
            trainLezka = GameObject.Find("LezkaSrednyaTrainCopy");
            osnovaKatushki = GameObject.Find("osnovaKatushki");
            firstPersonCharacter = GameObject.Find("FirstPersonController").GetComponent<FirstPersonController>();
            reticle = GameObject.Find("Reticle").GetComponent<Image>();
            trimmerDescriptionMenu = GameObject.Find("MenuBackground");
            statistic = GameObject.Find("StatisticBackground");
            statistic.SetActive(false);
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
            if (Input.GetMouseButton(1))
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
            Debug.Log(clickedObjectName);
            if (TrimmerClickChecker(clickedObjectName))
            {
                if (currentState == TaskControllerEnum.Beginning)
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
                if (currentState == TaskControllerEnum.MowingHasBegun)
                {
                    trimmer.transform.parent = firstPersonCharacter.transform;
                    trimmer.transform.localPosition = new Vector3(0f, -0.3f, 0.8f);
                    trimmer.transform.localRotation = Quaternion.Euler(-90, 0, -88);
                    statistic.SetActive(true);
                }
                if (currentState == TaskControllerEnum.TrimmerIsFilledWithFishingLine)
                {
                    firstPersonCharacter.crosshairImage = crossHairImage;
                    currentState = TaskControllerEnum.MowingHasBegun;
                    trimmerController.Rotate();
                    playerCamera.enabled = true;
                    explorerCamera.enabled = false;
                    trimmerDescriptionMenu.SetActive(false);
                    trainLezka.transform.parent = osnovaKatushki.transform;
                    firstLezka.transform.parent = osnovaKatushki.transform;
                    secondLezka.transform.parent = osnovaKatushki.transform;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    firstPersonCharacter.playerCanMove = true;
                    reticle.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
                
            }
            if (currentState == TaskControllerEnum.MowingHasBeenSuspended)
            {
                Destroy(firstLezka);
                Destroy(secondLezka);

                if (GameObject.Find(clickedObjectName).tag == "LezkaOstraya")
                {
                    firstLezka = Instantiate(Resources.Load<GameObject>("Prefabs/OstrayaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(90, 0, 180));
                    secondLezka = Instantiate(Resources.Load<GameObject>("Prefabs/OstrayaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(-90, -270, 90));
                }
                if (GameObject.Find(clickedObjectName).tag == "LezkaSlabaya")
                {
                    firstLezka = Instantiate(Resources.Load<GameObject>("Prefabs/SlabayaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(90, 0, 180));
                    secondLezka = Instantiate(Resources.Load<GameObject>("Prefabs/SlabayaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(-90, -270, 90));
                }
                if (GameObject.Find(clickedObjectName).tag == "LezkaSrednya")
                {
                    firstLezka = Instantiate(Resources.Load<GameObject>("Prefabs/SrednyaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(90, 0, 180));
                    secondLezka = Instantiate(Resources.Load<GameObject>("Prefabs/SrednyaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(-90, -270, 90));
                }
                
                firstLezka.transform.parent = osnovaKatushki.transform;
                secondLezka.transform.parent = osnovaKatushki.transform;

                trimmer.transform.localPosition = new Vector3(0f, -0.3f, 0.8f);
                trimmer.transform.localRotation = Quaternion.Euler(-90, 0, -88);

                if (secondLezka != null && firstLezka != null)
                {
                    GameController.lezkaInKatushka = true;
                    currentState = TaskControllerEnum.MowingHasBegun;
                }
            }
            if (currentState == TaskControllerEnum.TrimmerIsInPreparatoryState)
            {
                if(currentStudyState == StudyTaskControllerEnum.OpenKatushka && clickedObjectName == "corpusKatushki")
                {
                    AnimationController.BeginAnimate(clickedObjectName);
                    currentStudyState = StudyTaskControllerEnum.TakeLezka;
                    Debug.Log("dasdsadasdas");
                }
                if (currentStudyState == StudyTaskControllerEnum.TakeLezka && clickedObjectName == "LezkaSrednyaTrainCopy")
                {
                    Debug.Log("assda");
                    trainLezka.transform.position = new Vector3(100, 100, 100);
                    trainLezka.transform.localScale = trainLezka.transform.localScale / 1.2f;
                    currentStudyState = StudyTaskControllerEnum.PutLezka;

                }
                if (currentStudyState == StudyTaskControllerEnum.PutLezka && clickedObjectName == "osnovaKatushki")
                {
                    trainLezka.transform.rotation = Quaternion.Euler(0, 0, 0);
                    trainLezka.transform.position = GameObject.Find(clickedObjectName).transform.position + new Vector3(0, 0, -0.0003f);
                    currentStudyState = StudyTaskControllerEnum.CloseKatushka;
                }
                if (currentStudyState == StudyTaskControllerEnum.CloseKatushka && clickedObjectName == "corpusKatushki")
                {
                    AnimationController.BeginAnimate(clickedObjectName);
                    currentStudyState = StudyTaskControllerEnum.RollingOsnova;
                    Debug.Log("bad");
                }
                if (currentStudyState == StudyTaskControllerEnum.RollingOsnova && clickedObjectName == "LezkaSrednyaTrainCopy")
                {
                    Debug.Log("good");
                    firstLezka = Instantiate(Resources.Load<GameObject>("Prefabs/SrednyaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(90, 0, 180));
                    secondLezka = Instantiate(Resources.Load<GameObject>("Prefabs/SrednyaLezkaPrefab"), osnovaKatushki.transform.position, Quaternion.Euler(-90,-270, 90));
                    currentState = TaskControllerEnum.TrimmerIsFilledWithFishingLine;
                    //todo
                    //animate of lezka
                }

            }
            
        }
        void PerformRaycastRightClick()
        {
            if(currentState == TaskControllerEnum.MowingHasBegun)
            {
                GameObject.Find("katushka").transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            if(currentState == TaskControllerEnum.MowingHasBeenSuspended)
            {
                trimmer.transform.localPosition = new Vector3(-0.7f, 0f, 0.7f);
                trimmer.transform.localRotation = Quaternion.Euler(-180, 120, -88);
            }

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
