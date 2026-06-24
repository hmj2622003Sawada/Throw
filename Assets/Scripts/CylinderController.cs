using UnityEngine;
using UnityEngine.Rendering;

public class Cylinder : MonoBehaviour
{
	[SerializeField] private float BaseSpeed = 2.0f; // 基本の移動速度
	[SerializeField] private float Width = 3.0f; // 左右の移動幅
	[SerializeField] private float Randomness = 1.0f; // 不規則さ(値が大きいほど急激に変化)

	private Vector3 startPosition;
	private float NoiseTime;
	private float CurrentPositionX;

	private void Start()
	{
		startPosition = transform.position;
		// 
	}
}
