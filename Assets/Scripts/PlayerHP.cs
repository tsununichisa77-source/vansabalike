using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PunchScript : MonoBehaviour
{
[SerializeField] StatusData statusdata;

public Slider hpSlider;
    float HP;
     void Start()
    {
               if (hpSlider != null)
        {
            hpSlider.maxValue= statusdata.MAXHP;
            hpSlider.value = statusdata.MAXHP;
        }
         HP = statusdata.MAXHP;
    }
	void Update(){}
 
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Sesshoku sita zeyo!");
            other.gameObject.GetComponent<EnemyScript>().Damage(statusdata.ATK);
            other.gameObject.GetComponent<EnemyScript>().NockBack(statusdata.NockBack);
   
        }
    }
}