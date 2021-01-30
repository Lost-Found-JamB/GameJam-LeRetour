using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreInGameScript : MonoBehaviour
{
    [SerializeField] private int itemScoreValue = 100; 

    public static int scoreValue = 0;

    public static int boxValue = 0;

    public static int itemValue = 0;

    private TextMeshProUGUI _score = null;

    private int _box = 0;

    private int _item = 0;

    private int _capacityMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        _score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void Score(int nbItem, bool isFull, bool isAlmostFull)
    {
        //Conversion boite en pts : appuie sur ENTRÉE => Score qui augmente de item x 100
        if (!isFull && !isAlmostFull)
        {
            scoreValue = scoreValue + nbItem * itemScoreValue;
            _score.text = "Score : " + scoreValue;
            Debug.Log("Score item X 100");
        }

        //Boite pleine : appuie sur ENTRÉE avec item=maxItem => Score qui augmente de (item x 100) x 50%
        if (isFull)
        {
            scoreValue = scoreValue + (nbItem * itemScoreValue) + (nbItem * itemScoreValue) / 2;
            _score.text = "Score : " + scoreValue;
            Debug.Log("Score item X 50");
        }

        //Boite presque pleine : appuie sur ENTRÉE avec item=maxItem => Score qui augmente de (item x 100) x 25%
        if (isAlmostFull)
        {
            scoreValue = scoreValue + (nbItem * itemScoreValue) + (nbItem * itemScoreValue) / 4;
            _score.text = "Score : " + scoreValue;
            Debug.Log("Score item X 25");
        }
    }
}
