using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CameraHandler : MonoBehaviour
    {
        public Transform targetTrasform;
        public Transform cameraTrasform;
        public Transform cameraPivotTrandform;
        private Transform myTrasform;
        private Vector3 cameraTrasformPosition;
        private LayerMask ignoreLayers;
        public static CameraHandler singleton;
        public float lookSpeed = 0.1f;
        public float followSpeed = 0.1f;
        public float pivotSpeed = 0.03f;
        private float defaultPotition;
        private float lookAngle;
        private float pivotAngle;
        public float minimumPivot = -35;
        public float maximumPivot = 35;
        private Vector3 cameraFollowVelocity = Vector3.zero;
        private float targetPosition;
        public float cameraSphereRadius=0.2f;
        public float cameraCollisionOffSet=0.2f;
        public float minumumCollisionOffset=0.2f;

        private void Awake()
        {
            singleton = this;
            myTrasform = transform;
            defaultPotition = cameraTrasform.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);
        }

        public void FolllowTarget(float delta)
        {
            //Vector3 targetPosition = Vector3.Lerp(myTrasform.position, targetTrasform.position, delta / followSpeed);
            Vector3 targetPosition = Vector3.SmoothDamp(myTrasform.position, targetTrasform.position, ref cameraFollowVelocity, delta / followSpeed);
            myTrasform.position = targetPosition;
            HandleCameraCollisions(delta);
        }

        public void HandleCameraRotation(float delta, float mouseXinput, float mouseYinput)
        {
            lookAngle += (mouseXinput * lookSpeed) / delta;
            pivotAngle -= (mouseYinput * pivotSpeed) / delta;
            pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);
            Vector3 rotation = Vector3.zero;
            rotation.y = lookAngle;
            Quaternion targetRotation = Quaternion.Euler(rotation);
            myTrasform.rotation = targetRotation;
            rotation = Vector3.zero;
            rotation.x = pivotAngle;
            targetRotation = Quaternion.Euler(rotation);
            cameraPivotTrandform.localRotation = targetRotation;
        }

        public void HandleCameraCollisions(float delta)
        {
            targetPosition = defaultPotition;
            RaycastHit hit;
            Vector3 direction = cameraTrasform.position - cameraPivotTrandform.position;
            direction.Normalize();
            if(Physics.SphereCast(cameraPivotTrandform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPosition), ignoreLayers))
            {
                float dis = Vector3.Distance(cameraPivotTrandform.position, hit.point);
                targetPosition = -(dis - cameraCollisionOffSet);
            }
            if (Mathf.Abs(targetPosition) < minumumCollisionOffset)
            {
                targetPosition = -minumumCollisionOffset;
            }
            cameraTrasformPosition.z = Mathf.Lerp(cameraTrasform.localPosition.z, targetPosition, delta / 0.2f);
            cameraTrasform.localPosition = cameraTrasformPosition;

        }

    }
}

