using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Staff: MonoBehaviour, IWeapon, IProjectileWeapon {

	FireBall fireball;

	public int CurrentDamage {get;set;}

	private Animator animator;
	public List<BaseStat> Stats {
		get;
		set;
	}
	void Start()
	{
		fireball = Resources.Load<FireBall> ("Weapons/Projectiles/FireBall");
		animator = GetComponent<Animator> ();
	}

	public Transform ProjectileSpawn { get; set; }

	public void CastProjectile(int damage)
	{
		FireBall fireBallInstance = (FireBall)Instantiate (fireball, ProjectileSpawn.position, transform.rotation);
		fireBallInstance.Direction = ProjectileSpawn.forward;
	}


	public void PerformAttack(int damage)
	{
		
		animator.SetTrigger ("Base Attack");
		Debug.Log (this.name + " attack!");
	}


}
