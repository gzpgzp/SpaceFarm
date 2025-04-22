using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NormalTools
{
    public class NormalTextDialog : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Button closeBtn;

        public void Start()
        {
            closeBtn.onClick.AddListener(CloseDialog);
        }

        public void ShowDialog(string showText)
        {
            text.text = showText;
        }

        private void CloseDialog()
        {
            closeBtn.onClick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}
