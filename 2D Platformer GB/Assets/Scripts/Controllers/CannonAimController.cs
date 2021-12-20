using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC 
{
    public class CannonAimController : MonoBehaviour
    {
        private Transform muzzleTransform;
        private Transform targetTransform;

        private Vector3 dir;
        private float angle;
        private Vector3 axis;

        public CannonAimController(Transform muzzleTransform, Transform targetTransform) 
        {
            targetTransform = this.targetTransform;
            muzzleTransform = this.muzzleTransform;
        }

        void Update()
        {
            dir = targetTransform.position - muzzleTransform.position;
            angle = Vector3.Angle(Vector3.down, dir);
            axis = Vector3.Cross(Vector3.down, dir);

            muzzleTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}
