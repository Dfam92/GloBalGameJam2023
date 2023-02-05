using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] int roundTime;
    public int timeValue;
    private int startTimeValue;
    [SerializeField] int delayToStartGame;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI startTimerText;
    [SerializeField] TextMeshProUGUI startText;
    private Tween tweener;
    private Tween startTween;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        tweener = timerText.transform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        tweener.Pause();
        timeValue = roundTime;
        timerText.text = roundTime.ToString();
        startTimeValue = 3;
        startTimerText.text = startTimeValue.ToString();
        InitialTimer();
    }

   IEnumerator TimerDown()
    {
        startText.DOFade(0, 1f);
        
        
        var timeOver = false;
        while (!timeOver)
        {
            timeValue--;
            timerText.text = timeValue.ToString();
            if(timeValue < 10)
            {
                timerText.color = Color.red;
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

   private void InitialTimer()
    {
        StartCoroutine(StartInitialTimer());
    }
    
    IEnumerator StartInitialTimer()
    {
        startTween = startTimerText.transform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        yield return new WaitForSeconds(delayToStartGame);
        var timeOver = false;
        while (!timeOver)
        {
            startTimeValue--;
            startTimerText.text = startTimeValue.ToString();
           
            if (startTimeValue == -1)
            {
                startText.gameObject.SetActive(true);
                FindObjectOfType<SfxAudioManager>().PlayUIStart();
                gameManager.gameStarted = true;
                startTween.Pause();
                startTimerText.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                
                StartCoroutine(TimerDown());
                yield return new WaitForEndOfFrame();
                yield break;
            }
            FindObjectOfType<SfxAudioManager>().PlayUIConfirm();
            yield return new WaitForSeconds(1f);
        }
       
    }
}
