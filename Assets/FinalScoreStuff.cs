using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FinalScoreStuff : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI FinalScoreText;
    [SerializeField] private ScoreTracker ScoreTrackerScript;
    [SerializeField] private int Level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        //saves temp data
        DataSaverLoader.Gd.LatestLevel = Level;
        DataSaverLoader.Gd.LatestScore = ScoreTrackerScript.GetScore();


        FinalScoreText.text = "Final Score\n" + ScoreTrackerScript.GetScore().ToString();
        StartCoroutine(EnterName());   
    }

    IEnumerator EnterName()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(7);
    }
}