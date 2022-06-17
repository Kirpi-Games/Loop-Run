using Akali.Common;
using UnityEngine;

namespace Akali.Scripts.Core
{
    public class CameraPlayerFollower : Singleton<CameraPlayerFollower>
    {
        private const float FollowSpeed = 0.825f;
        public Vector3 followOffset;

        

        public void LateUpdate()
        {
            var desiredPosition = SwerveController.Instance.transform.position + followOffset;
            var followPosition = Vector3.Lerp(transform.position, desiredPosition, FollowSpeed);
            transform.position = followPosition;
        }
    }
}