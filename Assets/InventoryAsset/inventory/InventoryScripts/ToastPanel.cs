
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ToastPanel : MonoBehaviour
{
    public static ToastPanel instance;

    private void Awake()
    {
        if (instance != null)
        { 
            Destroy(this);
        }

        instance = this;
    }
    
    public GameObject panel;
    public Image toastImage;
    public TMP_Text textMessage;

    public void ShowMessage(string info)
    {
        textMessage.text = info;
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(panel.transform.DOLocalMoveY(50, 1f));
        sequence.Insert(0,toastImage.DOFade(1, 0.5f));
        sequence.Insert(0,textMessage.DOFade(1, 0.5f));
        sequence.AppendInterval(2);
        sequence.Append(panel.transform.DOLocalMoveY(50, 1f));
        sequence.Insert(3,toastImage.DOFade(0, 0.5f));
        sequence.Insert(3,textMessage.DOFade(0, 0.5f));
        sequence.Append(panel.transform.DOLocalMoveY(-100, 0));
        sequence.Play();
    }
    
}
