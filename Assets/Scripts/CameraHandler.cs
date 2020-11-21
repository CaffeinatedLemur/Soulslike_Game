using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NightBook
{
    public class CameraHandler : MonoBehaviour
    {
        public Transform targetTransform;
        public Transform cameraTransform;
        public Transform cameraPivotTransform;

        private Transform myTransform;
        private Vector3 cameraTransformPosition;
        private LayerMask ignoreLayers;

        public static CameraHandler singleton;

        public float lookSpeed;
        public float followSpeed;
        public float pivotSpeed;

        private float defaultPosition;
        private float lookAngle;
        private float pivotAngle;

        public float minimumPivot = -35;
        public float maximumPivot = 35;


        private void Awake()
        {
            singleton = this;
            myTransform = transform;
            defaultPosition = cameraTransform.localPosition.z;

            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);

        }

        public void FollowTarget (float delta)
        {
            Vector3 targetPosition = Vector3.Lerp(myTransform.position, targetTransform.position, delta / followSpeed);
            myTransform.position = targetPosition;
        }

        public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
        {
            lookAngle += (mouseXInput * lookSpeed) / delta;
            pivotAngle -= (mouseYInput * pivotSpeed) / delta;

            //lookAngle += (mouseXInput * delta);
            //pivotAngle -= (mouseYInput * delta);

            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTransform.rotation = targetRotation;

            rotation = Vector3.zero;
            rotation.x = pivotAngle;

            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTransform.localRotation = targetRotation;
        }

    }
}
