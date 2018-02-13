using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowingEnemyLife : MonoBehaviour {
    
    Text enemyLifeText;

	void Start () {
        enemyLifeText = GetComponent<Text>();
        enemyLifeText.alignment = TextAnchor.UpperCenter;
    }
    
    public void ShowEnemyLife(int enemyLife, int totalLife)
    {
        string Life = enemyLife.ToString() + "/" + totalLife.ToString();
        enemyLifeText.text = Life;
        if (enemyLife == 0)
            enemyLifeText.text = "";
    }

}
