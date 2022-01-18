using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC 
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform[] _waypoints;
        [SerializeField] float _moveSpeed = 2f;
        int _waypointsIndex = 0;

        private void Start()
        {
            transform.position = _waypoints[_waypointsIndex].transform.position;
        }
        private void Update()
        {
            Move();
        }

        private void Move() 
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _waypoints[_waypointsIndex].transform.position,
                _moveSpeed * Time.deltaTime);

            if (transform.position == _waypoints [_waypointsIndex].transform.position)
            {
                _waypointsIndex += 1;
            }

            if (_waypointsIndex == _waypoints.Length)
            {
                _waypointsIndex = 0;
            }
        }
    }
}
