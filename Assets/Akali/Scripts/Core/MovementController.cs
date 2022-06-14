using Akali.Common;
using Akali.Scripts.Managers.StateMachine;
using UnityEngine;

namespace Akali.Scripts.Core
{
    public class MovementController : Singleton<MovementController>
    {
        
        public bool movement;
        [Range(5, 30)] public float platformMovementSpeed;
        public float failSpeed;

        private void Awake()
        {
            GameStateManager.Instance.GameStatePlaying.OnExecute += MoveZ;
            GameStateManager.Instance.GameStatePlaying.OnExecute += GetForward;
        }

        private void MoveZ()
        {
            PlayerController.Instance.animator.SetBool("isRun",movement);
            if (movement)
            {
                if (!PlayerController.Instance.isFail)
                {
                    transform.Translate(Vector3.back * platformMovementSpeed * Time.deltaTime);
                    failSpeed = 0;
                }
            }

            if (Input.GetMouseButtonDown(0) || PlayerController.Instance.isFail)
            {
                platformMovementSpeed = 10;
                movement = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                platformMovementSpeed = 0;
                movement = false;
            }
        }

        private void GetForward()
        {
            if (PlayerController.Instance.isFail)
            {
                platformMovementSpeed = 0;
                movement = true;
                failSpeed = 20;
                transform.Translate(Vector3.forward * failSpeed * Time.deltaTime);   
            }
        }
    }
}
 