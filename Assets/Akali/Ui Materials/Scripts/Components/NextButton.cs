using System.Collections;
using Akali.Common;
using Akali.Scripts.Managers;
using Akali.Scripts.Managers.StateMachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Akali.Ui_Materials.Scripts.Components
{
    public class NextButton : Singleton<NextButton>
    {
        private void OnEnable()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(GoToNextLevel);
        }

        private void OnDisable()
        {
            gameObject.GetComponent<Button>().onClick.RemoveListener(GoToNextLevel);
        }

        public void GoToNextLevel()
        {
            GameStateManager.Instance.SetGameState(GameStateManager.Instance.GameStatePlaying);
            AkaliLevelManager.Instance.levels.GoToNextLevel(true);
            StartCoroutine(CheckpointReach());
        }

        IEnumerator CheckpointReach()
        {
            if (!PlayerController.Instance.isFail)
            {
                GameUiManager.Instance.completeUi.gameObject.transform.DOScale(1, 0.35f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(0.6f);
                GameUiManager.Instance.completeUi.gameObject.transform.DOScale(0, 0.35f).SetEase(Ease.Linear);    
            }
        }
    }
}