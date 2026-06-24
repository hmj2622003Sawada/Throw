using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowController : MonoBehaviour
{
	[SerializeField] GameObject ItemPrefab; // 投擲物
	[SerializeField] Transform handPoint; // 手の生成位置
	[SerializeField] float ThrowForce = 20f; // 投げる強さ

	private Animator animator; // コンポーネント参照用
	private GameObject CurrentItem; // 現在手に持っているアイテム

	private void Start()
	{
		animator = GetComponent<Animator>();

		// 最初のアイテム
		CreateItemInHand();
	}

	private void Update()
	{
		animator.ResetTrigger("Throw");
		// スペースキーが押されたらアニメーションを再生
		if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			// 持っているアイテムを投げられるようにする
			if (CurrentItem != null)
			{
				animator.SetTrigger("Throw");
			}
		}
	}

	// 放す瞬間
	public void ThrowItemEvent()
	{
		if (CurrentItem == null) return;

		CurrentItem.transform.SetParent(null);
		Rigidbody rb = CurrentItem.GetComponent<Rigidbody>();
		if(rb != null)
		{
			rb.isKinematic = false;
			rb.AddForce(transform.forward * ThrowForce, ForceMode.Impulse);
		}
		CurrentItem= null;
	}

	// アニメーションの終わり
	public void CreateItemInHand()
	{
		if (ItemPrefab == null || handPoint == null || CurrentItem != null) return;

		CurrentItem = Instantiate(ItemPrefab, handPoint.position, handPoint.rotation);
		CurrentItem.transform.SetParent(handPoint);
		CurrentItem.transform.localPosition = Vector3.zero;
		CurrentItem.transform.localRotation = Quaternion.identity;

		Rigidbody rb = CurrentItem.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = true;
		}
	}
}
