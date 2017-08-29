using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject playerHand;
	Transform spawnProjectile;
	Item currentlyEquipped;
	public int powerLevel;

	public GameObject EquippedWeapon {
		get;
		set;
	}

	CharacterStats characterStats;
	IWeapon attackingWeapon;

	void Start()
	{
		spawnProjectile = transform.Find ("ProjectileSpawn");
		characterStats = GetComponent<Player> ().characterStats;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			PerformWeaponAttack ();
		}
	}
	public void EquipWeapon(Item itemToEquip)
	{
		if (EquippedWeapon != null) 
		{
			InventoryController.Instance.GiveItem (currentlyEquipped.ObjectSlug);
			characterStats.RemoveStatBonus (EquippedWeapon.GetComponent<IWeapon> ().Stats);
			Destroy (playerHand.transform.GetChild (0).gameObject);

		}

		EquippedWeapon = (GameObject)Instantiate (Resources.Load<GameObject>("Weapons/"+ itemToEquip.ObjectSlug),
			playerHand.transform.position, playerHand.transform.rotation);
		attackingWeapon = EquippedWeapon.GetComponent<IWeapon> ();
		if(EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
			EquippedWeapon.GetComponent<IProjectileWeapon> ().ProjectileSpawn = spawnProjectile;
		EquippedWeapon.GetComponent<IWeapon> ().Stats = itemToEquip.Stats;
		EquippedWeapon.transform.SetParent (playerHand.transform);
		attackingWeapon.Stats = itemToEquip.Stats;
		currentlyEquipped = itemToEquip;
		characterStats.AddStatBonus (itemToEquip.Stats);

		Debug.Log (attackingWeapon.Stats [0].GetCalculatedStatValue());
		Debug.Log ("Current Stat Value = " + characterStats.stats[0].GetCalculatedStatValue());
	}
	public void PerformWeaponAttack()
	{
		attackingWeapon.PerformAttack (CalculateDamage());

	}

	private int CalculateDamage()
	{
		int damageToDeal = (characterStats.GetStat (BaseStat.BaseStatType.Power).GetCalculatedStatValue()*2)
			+Random.Range(2,8);
		damageToDeal += CalculateCrit (damageToDeal);
		Debug.Log ("Damage Dealt: " + damageToDeal);
		return damageToDeal;
	}
	private int CalculateCrit(int damage)
	{
		if(Random.value <= .10f)
		{
			int critDamage =(int) (damage * Random.Range (.25f, .5f));
			return critDamage;
		}
		return 0;
	}
}
