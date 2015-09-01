﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColdMedicine : Item {

	public BarValue[] BarEffects;

	public SicknessType[] SicknessCures;

    protected override void Start()
    {
        base.Start();
    }

    public override void Use(MapEntity entity)
    {
    	StartCoroutine(AnimationCoroutine());

        if (entity.GetType() == typeof(PlayerEntity))
        {   
        	// Affect bars
            foreach (BarValue barValue in BarEffects)
            {                
                (entity as PlayerEntity).AlterBar(barValue.EffectValue, barValue.TargetBar);  
            }          

            // Cure sickness
            foreach (SicknessType sickenssType in SicknessCures) 
            {
            	Sickness sickness = SicknessLibrary.Instance.GetSickness(sickenssType);

            	 // Check that the player doesn't have that sickness
	            if((entity as PlayerEntity).Sicknesses.Exists(x => ((x.Name == sickness.Name))))
	            {
                	(entity as PlayerEntity).CureSickness(sickness);
	            }
            }
        }
    }

    private IEnumerator AnimationCoroutine()
    {
    	// Spawn animation
    	GameObject Animation = Instantiate(AnimationObject);
    	Animation.transform.SetParent(transform.root, false);

    	Animation.GetComponent<Animator>().SetInteger("type", AnimationType);

    	// Turn on object
    	Animation.GetComponent<Image>().color = Color.white;

    	// Play FX
    	AudioManager.Instance.Play(AudioManager.AudioType.FX, UseFX);
    	AudioManager.Instance.Fade(AudioManager.AudioType.FX, 0, 2.5f);

    	yield return new WaitForSeconds(2.5f);

    	print(Animation.name);

    	// Despawn Animation
    	Destroy(Animation.gameObject);

    	// Destroy GameObject
    	Destroy(this.gameObject);
    }
}
