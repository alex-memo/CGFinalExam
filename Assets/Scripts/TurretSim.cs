using UnityEngine;
/// <summary>
/// Simulated the input of a turret
/// </summary>
public class TurretSim : MonoBehaviour
{
	[SerializeField] private Material vignetteMat;
	[SerializeField] private Material energyMat;
	private float energy = 1;
	private float burnRate = 0.1f;
	private float lastFireTime = 0;
	private void Awake()
	{
		resetMats();
	}
	private void Update()
	{
		input();
		restoreFire();
	}
	private void restoreFire()
	{
		if (Time.time - lastFireTime <= 1) { return; }//after 1 second of not firing, start restoring energy
		if (energy >= 1) { return; }//if energy is full, don't restore

		energy += burnRate * Time.deltaTime;
		setMaterials();
		if (energy > 1) { energy = 1; }//clamp energy to 1

	}
	private void input()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			fire();
		}
	}
	private void fire()
	{
		if (energy > 0)
		{
			energy -= burnRate * Time.deltaTime;
			setMaterials();
			lastFireTime = Time.time;
		}
	}
	private void setMaterials()
	{
		energyMat.SetFloat("_FillPercentage", energy);
		vignetteMat.SetFloat("_Alpha", 1f - energy);
	}

	private void resetMats()
	{
		vignetteMat.SetFloat("_Alpha", 0f);
		energyMat.SetFloat("_FillPercentage", 1f);
	}
	private void OnDestroy()
	{
		resetMats();
	}
}
