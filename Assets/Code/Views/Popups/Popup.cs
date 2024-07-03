using UnityEngine;

namespace Code.Views.Popups
{
    public class Popup  : MonoBehaviour
    {
        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}