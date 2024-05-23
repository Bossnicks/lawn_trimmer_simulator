using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using static Assets.TaskController;



namespace Assets
{
    public class Backlight : MonoBehaviour
    {
        private Renderer objectRenderer;
        private Material newMaterial;
        private Material originalMaterial;

        private void Start()
        {
            objectRenderer = GetComponent<Renderer>();
            originalMaterial = objectRenderer.material;
            newMaterial = Resources.Load<Material>("Materials/Backlight");
        }
        public void ChangeColor()
        {
            objectRenderer.material = newMaterial;

            switch (gameObject.name)
            {
                case "barbell":
                    RaycastController.hintText.text = "Служит для соединения двигателя и режущей головки, обеспечивая удобство в использовании и маневренность.";
                    break;
                case "electric_motor":
                    RaycastController.hintText.text = "Приводит в движение режущий механизм, обеспечивая работу триммера.";
                    break;
                case "handle":
                    RaycastController.hintText.text = "Обеспечивает удобство и контроль при управлении триммером.";
                    break;
                case "corpusKatushki":
                    RaycastController.hintText.text = "Защищает и удерживает катушку с леской в безопасном положении.";
                    break;
                case "osnovaKatushki":
                    RaycastController.hintText.text = "Держит леску и позволяет ей вращаться для срезания травы.";
                    break;
                case "protective_box":
                    RaycastController.hintText.text = "Предохраняет пользователя от летящих обрезков травы и мусора.";
                    break;
                case "lezkaBacklight":
                    RaycastController.hintText.text = "Служит режущим элементом, который вращается и срезает траву.";
                    break;
                default:
                    Debug.Log("Недопустимый элемент");
                    break;
            }


        }

        public void ReturnColor()
        {
            objectRenderer.material = originalMaterial;
            RaycastController.hintText.text = HintToState();
        }

        public static string HintToState()
        {
            switch(currentState)
            {
                case TaskControllerEnum.Beginning:
                    return "Идите на задний двор и возьмите триммер";
                case TaskControllerEnum.TrimmerIsInPreparatoryState:
                    return "Заправьте лезку в косилку";
                case TaskControllerEnum.TrimmerIsFilledWithFishingLine:
                    return "Идите на задний двор и возьмите триммер";
                case TaskControllerEnum.MowingHasBegun:
                    return "Идите на задний двор и возьмите триммер";
                case TaskControllerEnum.MowingHasBeenSuspended:
                    return "Идите на задний двор и возьмите триммер";
                case TaskControllerEnum.MowingStopped:
                    return "Идите на задний двор и возьмите триммер";
                default:
                    return "";

            }
        } 
    }

}

