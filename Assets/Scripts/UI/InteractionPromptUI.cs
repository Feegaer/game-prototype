using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InteractionPromptUI: MonoBehaviour
    {
        [SerializeField] private TMP_Text promptText;
        public void Show(string message) 
        {
            promptText.text = message;
            gameObject.SetActive(true);
        }
        public void Hide() => gameObject.SetActive(false);
    }
}
