using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
	private bool IsStuck = false;

	private void Update()
	{
		// 的に当たらず、yが0いかになったら破棄する
		if(!IsStuck && transform.position.y <0f)
		{
			Destroy(gameObject);
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		// 既に何かに刺さっている場合は処理しない
		if (IsStuck) return;

		// 衝突した相手がTargetだった場合
		if(collision.gameObject.CompareTag("Target"))
		{
			IsStuck = true;

			// 衝突した場所の座標
			Vector3 HitPoint = collision.contacts[0].point;
			// 的の中心の座標
			Vector3 TargetCenter = collision.transform.position;

			// 物理挙動を止める
			if (TryGetComponent<Rigidbody>(out Rigidbody rb))
			{
				rb.isKinematic = true; // 物理演算の無効化
				rb.linearVelocity = Vector3.zero;　// 速度をゼロ
				rb.angularVelocity = Vector3.zero; // 回転をゼロ
			}

			transform.SetParent(collision.transform);


			// スコアを足す
			if(GameManager.Instance != null)
			{
				GameManager.Instance.AddScore(100);
			}
		}

		
	}
}
