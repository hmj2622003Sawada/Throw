using UnityEngine;

public class GetHandPosition : MonoBehaviour
{
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		// 右手の座標を取得
		Transform rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
		if (rightHand != null)
		{
			Vector3 rightHandPos = rightHand.position;
			Debug.Log("右手の座標: " + rightHandPos);
		}

		// 左手の座標を取得
		Transform leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
		if (leftHand != null)
		{
			Vector3 leftHandPos = leftHand.position;
			Debug.Log("左手の座標: " + leftHandPos);
		}
	}
}

