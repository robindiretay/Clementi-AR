using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class ClickerGame : MonoBehaviour
{
    public TMP_Text countdownText;
    public Slider progressSlider;
    public int maxClicks = 100; // The total number of clicks required
    public float timeLimit = 10f; // The countdown time in seconds
    public float deteriorationRate = 0.5f; // The rate at which the progress slider decreases
    public float deteriorationAmount = 0.5f; // The amount at which the progress slider decreases
    public GameObject tapPanel;
    public GameObject successObject;
    public GameObject failureObject;
    public GameObject tapUI;

    private int currentClicks = 0;
    private float remainingTime;
    private bool gameActive = false;

    void Start()
    {
        progressSlider.maxValue = maxClicks;
        progressSlider.value = 0;
    }

    public void StartGame()
    {
        currentClicks = 0;
        remainingTime = timeLimit;
        gameActive = true;
        tapPanel.SetActive(true);
        StartCoroutine(CountdownTimer());
        StartCoroutine(DeteriorateProgress());
    }

    public void OnClick()
    {
        if (gameActive && remainingTime > 0)
        {
            currentClicks++;
            progressSlider.value = currentClicks;
        }
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            countdownText.text = Mathf.Ceil(remainingTime) + "s".ToString();
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }
        EndGame();
    }

    private IEnumerator DeteriorateProgress()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(deteriorationRate);
            progressSlider.value = Mathf.Max(progressSlider.value - deteriorationAmount, 0);
        }
    }

    private void EndGame()
    {
        gameActive = false;
        tapPanel.SetActive(false);
        countdownText.text = "";
        
        // Activate the corresponding object based on success or failure
        if (currentClicks >= maxClicks)
        {
            successObject.SetActive(true);
            tapUI.SetActive(false);
        }
        else
        {
            failureObject.SetActive(true);
            tapUI.SetActive(false);
        }
    }
}
