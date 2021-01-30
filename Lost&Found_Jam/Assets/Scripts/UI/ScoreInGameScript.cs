using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGameScript : MonoBehaviour
{
    public static int scoreValue = 0;

    public static int boxValue = 0;

    public static int itemValue = 0;

    private Text _score = null;

    private int _box = 0;

    private int _item = 0;

    private int _capacityMax = 10;

    // Start is called before the first frame update
    void Start()
    {
        _score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            scoreValue += 100;
            boxValue += 1;
            itemValue += 1;

            _score.text = "Your score is " + scoreValue;
            Debug.Log("Box : " + boxValue);
        }
       
        if (boxValue >10)
        {
            Debug.Log("Box number >10");
        }

        

        if (Input.GetKeyDown (KeyCode.P))
        {
            //Conversion boite en pts : appuie sur ENTRÉE => Score qui augmente de item x 100
            if (itemValue < _capacityMax -1)
            {
                scoreValue = scoreValue + itemValue * 100;
                _score.text = "Your score is multiplicated by 100 ! " + scoreValue;
                Debug.Log("Score item X 100");
            }

            //Boite pleine : appuie sur ENTRÉE avec item=maxItem => Score qui augmente de (item x 100) x 50%
            if (itemValue == _capacityMax)
            {
                scoreValue = scoreValue + (itemValue * 100)+ (itemValue * 100)/2;  
                _score.text = "Your score is multiplicated by 50 ! " + scoreValue;
                Debug.Log("Score item X 50");
            }

            //Boite presque pleine : appuie sur ENTRÉE avec item=maxItem => Score qui augmente de (item x 100) x 25%
            if (itemValue == _capacityMax -1)
            {
                scoreValue = scoreValue + (itemValue * 100) + (itemValue * 100) /4;
                _score.text = "Your score is multiplicated by 25 ! " + scoreValue;
                Debug.Log("Score item X 25");
            }
        }

        

     
    }
}
