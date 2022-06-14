using Akali.Common;
using Akali.Scripts.Core;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using UnityEngine;

namespace Akali.Scripts
{
    public class SwerveController : Singleton<SwerveController>
    {

        private void Awake()
        {
            GameStateManager.Instance.GameStateMainMenu.OnExecute += StartSwerve;
            GameStateManager.Instance.GameStatePlaying.OnExecute += Swerve;
        }

        // private void DisableSwerve()
        // {
        //     GameStateManager.Instance.GameStateMainMenu.onExecute -= StartSwerve;
        //     GameStateManager.Instance.GameStatePlaying.onExecute -= Swerve;
        // }

        private void StartSwerve()
        {
            if (Input.GetMouseButtonDown(0))
            { 
                MovementController.Instance.movement = true;
                pressed = true;
                PlayerController.Instance.isPlay = true;
                secondPos.x = Input.mousePosition.x;
                AkaliLevelManager.Instance.LevelIsPlaying();
            }
        }

        public float turnAmount;
        public float turnSpeed;
        public float xClamp, transformX;
        public Vector3 firstPos,secondPos;
        public bool pressed;
        public float sensitivity;
        public float speed;
        
        private void Swerve()
        {
            if (Input.GetMouseButtonDown(0))
            {
                pressed = true;
                firstPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0) && pressed)
            {
                secondPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                transformX += (secondPos.x - firstPos.x) * sensitivity;
                transformX = Mathf.Clamp(transformX, -xClamp, xClamp);
                transform.position = new Vector3(transformX, transform.position.y, transform.position.z);
                Vector3 movement = new Vector3((secondPos - firstPos).x * sensitivity * turnAmount, 0, speed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * turnSpeed);
                firstPos = secondPos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                pressed = false;
                transform.DORotate(new Vector3(0,0,0), .2f);
            }
        }
    }
}