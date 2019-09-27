using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    [SerializeField]
    private Player MyChar = null;

    Text ScoreObj;
    // Start is called before the first frame update
    void Start()
    {
        ScoreObj = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreObj.text = "Exp: " + MyChar.Experiance;
    }
}
