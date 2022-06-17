using TMPro;
using UnityEngine;
using PlayerPrefs = Akali.Scripts.Utilities.PlayerPrefs;

namespace Akali.Ui_Materials.Scripts.Components
{
    public class LevelText : MonoBehaviour
    {
        private void Update()
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = $"LEVEL {PlayerPrefs.GetLevelText()}";
        }
    }
}