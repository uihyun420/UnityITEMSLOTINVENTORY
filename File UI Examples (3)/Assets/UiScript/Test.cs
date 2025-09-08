using System.Collections;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI leftStat;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI rightStat;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI totalScoreText;

    private Coroutine coroutine;
    

    private void Start()
    {
        
        //if (coroutine != null)
        //{
        //    StopCoroutine(coroutine);
        //}
        StartCoroutine(CoText());
        //StopCoroutine(coroutine);
    }
  

    private void Awake()
    {
        leftText.text = "";
        rightText.text = "";

        leftStat.text = "";
        rightStat.text = "";

        totalScore.text = "TOTAL SCORE";
    }


    public IEnumerator CoText()
    {
        for (int i = 0; i < 3; i++)
        {
            leftStat.text += $"STAT\n";
            leftText.text += $"{Random.Range(1, 100):00}\n";
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < 3; i++)
        {         
            rightStat.text += $"STAT\n";
            rightText.text += $"{Random.Range(1, 100):00}\n";
            yield return new WaitForSeconds(1f);
        }

        totalScoreText.text = $"{Random.Range(1, 999999999)}";
        //coroutine = null;
    }
}
