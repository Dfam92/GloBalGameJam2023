using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] int roundTime;
    public int timeValue;
    [SerializeField] int delayToStartGame;
    [SerializeField] TextMeshProUGUI timerTxt;
    private Tween tweener;

    // Start is called before the first frame update
    void Start()
    {
        tweener = timerTxt.transform.DOScale(1.5f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        tweener.Pause();
        timeValue = roundTime;
        timerTxt.text = roundTime.ToString();
        StartCoroutine(TimerDown());
    }

   IEnumerator TimerDown()
    {
        var timeOver = false;
        yield return new WaitForSeconds(delayToStartGame);
        FindObjectOfType<SfxAudioManager>().PlayUIStart();
        while(!timeOver)
        {
            timeValue--;
            timerTxt.text = timeValue.ToString();
            if(timeValue < 10)
            {
                timerTxt.color = Color.red;
                FindObjectOfType<SfxAudioManager>().PlayUIDeny();
                tweener.Play();
            }
            if (timeValue == 0)
            {
                FindObjectOfType<GameManager>().GameOver();
                tweener.Pause();
                yield break;
            }
            yield return new WaitForSeconds(1);
        }
    }
    
}
