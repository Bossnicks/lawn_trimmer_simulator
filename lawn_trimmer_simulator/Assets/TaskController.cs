using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class TaskController
    {
        public static TaskControllerEnum currentState = TaskControllerEnum.Beginning;
        public static GameObject hint = GameObject.Find("Hints");
        public static GameObject selectedObject;
        

        public enum TaskControllerEnum
        {
            Beginning,
            TrimmerIsInPreparatoryState,
            TrimmerIsFilledWithFishingLine,
            MowingHasBegun,
            MowingHasBeenSuspended,
            MowingStopped
        }
    }
}
