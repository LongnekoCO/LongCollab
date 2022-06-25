using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongBossHealthBar : MonoBehaviour
{
	public BossHealth bossHealth;
	public Slider slider;
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		bossHealth = GameObject.FindWithTag("Boss").GetComponent<BossHealth>();
		slider.maxValue = bossHealth.maxhealth;
		slider.value = bossHealth.health;
    }
}
