using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC 
{
    public class BulletController
    {
        private Vector3 _velocity;
        private LevelObjectView _view;

        public BulletController(LevelObjectView view) 
        {
            _view = view;
            Active(false);
        }

        public void Active(bool val) 
        {
            _view.gameObject.SetActive(val);
        }

        private void SetVelocity(Vector3 velocity) 
        {
            _velocity = velocity;
            float angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void Throw(Vector3 position, Vector3 velocity) 
        {
            Active(true);
            SetVelocity(velocity);
            _view._transform.position = position;
            _view._rigidbody.velocity = Vector3.zero;
            _view._rigidbody.angularVelocity = 0;

            _view._rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}
