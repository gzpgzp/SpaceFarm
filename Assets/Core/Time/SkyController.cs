using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Time
{
    public class SkyController : MonoBehaviour,MMEventListener<TimeChangeEvent>
    {
        [SerializeField] private Image sky;
        private Color morningColor = new Color(0f, 0f, 0f,0f);
        private Color eveningColor = new Color(0.2f, 0.1f, 0.1f, 0.4f);
        private Color nightColor = new Color(0f, 0f, 0.1f, 0.6f);

        private void OnEnable()
        {
            this.MMEventStartListening<TimeChangeEvent>();
        }

        private void OnDisable()
        {
            this.MMEventStopListening<TimeChangeEvent>();
        }

        public void OnMMEvent(TimeChangeEvent eventType)
        {
            if (eventType.timeType == TimeType.Morning)
            {
                sky.color = morningColor;
            }
            else if (eventType.timeType == TimeType.Evening)
            {
                sky.color = eveningColor;
            }
            else
            {
                sky.color = nightColor;
            }
        }
    }
}