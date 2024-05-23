using UnityEngine;

namespace Assets
{
    public class CameraController : MonoBehaviour
    {
        bool move = false;
        float speed = 0.01f;
        float offset = 0;
        Vector3 startPosition;
        Vector3 needPosition;
        Quaternion startRotation;
        Quaternion needRotaton;
        private void Start()
        {
            transform.position = new Vector3(0.1969f, 0.0592f, -0.0835f);
            transform.rotation = Quaternion.Euler(26.203f, -39.711f, 0f);
        }

        public void MoveToTrimmer()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1969f, 0.0592f, -0.0835f);
            needRotaton = Quaternion.Euler(26.203f, -39.711f, 0f);
        }

        public void MoveToCoil()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1646f, 0.0452f, -0.0669f);
            needRotaton = Quaternion.Euler(23.376f, -6.935f, 0.383f);
        }
        public void MoveToProtectiveBox()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1763f, 0.0438f, -0.0485f);
            needRotaton = Quaternion.Euler(27.281f, -126.019f, 0.82f);

        }
        public void MoveToElectronicBox()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1763f, 0.0483f, -0.0447f);
            needRotaton = Quaternion.Euler(23.376f, -121.997f, 0.383f);
        }

        public void MoveToBarbell()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1874f, 0.054f, -0.0479f);
            needRotaton = Quaternion.Euler(41.752f, -72.201f, -21.379f);
        }

        public void MoveToHandle()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1933f, 0.024f, -0.041f);
            needRotaton = Quaternion.Euler(10.615f, -55.126f, 7.316f);
        }

        public void MoveToFishingLine()
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(0.1683f, 0.0266f, -0.0773f);
            needRotaton = Quaternion.Euler(36.181f, -45.253f, -10.637f);
        }

        void Update()
        {
            if (move)
            {
                offset += speed;
                transform.position = Vector3.Lerp(startPosition, needPosition, offset);
                transform.rotation = Quaternion.Slerp(startRotation, needRotaton, offset);
                if (offset >= 1)
                {
                    move = false;
                    offset = 0;
                }
            }
        }
    }
}