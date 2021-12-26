using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC 
{
    public class BulletEmitterController 
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        private float _delay = 1f;
        private float _startSpeed = 5f;

        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform) 
        {
            _transform = transform;
            foreach (LevelObjectView BulletView in bulletViews)
            {
                _bullets.Add(new BulletController(BulletView));
            }
        }

        public void Update() 
        {
            if (_timeTillNextBullet > 0)
            {
                _bullets[_currentIndex].Active(false);
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, -_transform.up * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0;
                }
            }
        }
    }
}
