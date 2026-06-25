using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Cylinder : MonoBehaviour
{
	[Header("移動範囲")]
	[SerializeField] private float LeftLimit = -5f; // 左端
	[SerializeField] private float RightLimit = 5f; // 右端

	[Header("ランダム性")]
	[SerializeField] private float MinSpeed = 1f; // 最低速度
	[SerializeField] private float MaxSpeed = 8f; // 最高速度
	[SerializeField] private float MinChangeTime = 0.5f; // 最短の変更時間
	[SerializeField] private float MaxChangeTime = 2.0f; // 最長の変更時間

	[SerializeField] private AudioClip HitSE;

	private float CurrentSpeed; // 現在のスピード
	private float Direction = 1f; // 移動方向(右1，左-1)
	private float TimeToChange; // 次に速度が変わる時間
	private float timer;
	float LimitTimer = 30f;

	private void Start()
	{
		// 最初の速度
		RandomizeMovement();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		LimitTimer -= Time.deltaTime;

		// 時間が来たら、速度をランダムに変更
		if (timer >= TimeToChange)
		{
			RandomizeMovement();
		}

		// 左右の端にぶつかると強制的に反転
		if (transform.position.x >= RightLimit && Direction > 0)
		{
			Direction = -1f;
			RandomizeMovement(); // 反転時に速度変更
		}
		else if (transform.position.x <= LeftLimit && Direction < 0)
		{
			Direction = 1f;
			RandomizeMovement();
		}

			// 移動処理
			transform.Translate(Vector3.right * Direction * CurrentSpeed * Time.deltaTime);

		if (LimitTimer <= 0)
		{
			CurrentSpeed = 0f;
		}
	}

	// 衝突時に音を出す
	private void OnCollisionEnter(Collision collision)
	{
		AudioSource.PlayClipAtPoint(HitSE, transform.position);
	}


	// 即とと時間をランダムに再設定
	void RandomizeMovement()
	{
		CurrentSpeed = Random.Range(MinSpeed, MaxSpeed);
		TimeToChange = Random.Range(MinChangeTime, MaxChangeTime);
		timer = 0f; // タイマーリセット

		if (LimitTimer <= 0)
		{
			CurrentSpeed = 0f;
		}
	}
}

