using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowingEnemyLife : MonoBehaviour {
    
    Text enemyLifeText;

	// Use this for initialization
	void Start () {
        enemyLifeText = GetComponent<Text>();
        enemyLifeText.alignment = TextAnchor.UpperCenter;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowEnemyLife(int enemyLife, int totalLife)
    {
        string Life = enemyLife.ToString() + "/" + totalLife.ToString();
        enemyLifeText.text = Life;
        if (enemyLife == 0)
            enemyLifeText.text = "";
    }

}
