using UnityEngine;

namespace PlatformerMVC 
{
    public class CameraController
    {
        private LevelObjectView _playerView;
        private Transform _playerTransform;
        private Transform _mCamTransform;

        private float _camSpeed = 1.3f;

        private float X;
        private float Y;

        private float offsetX;
        private float offsetY;

        private float _xAxisInput;
        private float _yAxisVelovity;

        public CameraController(LevelObjectView player, Transform camera) 
        {
            _playerView = player;
            _playerTransform = _playerView._transform;
            _mCamTransform = camera;
        }

        public void Update() 
        {
            _xAxisInput = Input.GetAxis("Horizontal");
            _yAxisVelovity = _playerView._rigidbody.velocity.y;

            if (_xAxisInput > 0)
            {
                offsetX = 2;
            }
            else if (_xAxisInput < 0)
            {
                offsetX = -2;
            }
            else 
            {
                offsetX = 0;
            }

            if (_yAxisVelovity > 0)
            {
                offsetY = 2;
            }
            else if (_yAxisVelovity < 0)
            {
                offsetY = -2;
            }
            else 
            {
                offsetY = 0;
            }

            _mCamTransform.position = Vector3.Lerp(_mCamTransform.position,
                new Vector3(X + offsetX, Y + offsetY, _mCamTransform.position.z),
                Time.deltaTime * _camSpeed);
        }
    }
}
