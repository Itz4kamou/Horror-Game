using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
	[Header("The Head")]
	[SerializeField]
	private Transform headTransform;

	[Header("Views")]
	[SerializeField]
	private bool frontView;
	[SerializeField]
	private bool rightView;
	[SerializeField]
	private bool leftView;

	[SerializeField]
	private Vector3 mainView = new Vector3(0f, 0f, 0f);

	void Start()
	{
		OnPlay();
	}

	void OnPlay()
	{
		headTransform.rotation = Quaternion.Euler(mainView);
	}

	void Update()
	{
		Angles();
		Head();
	}

	void Head()
	{
		ToGoRight();
		ToGoLeft();
	}

	void ToGoRight()
	{
		if (Input.GetAxisRaw("Horizontal") > 0 && frontView)
		{
			headTransform.rotation = Quaternion.Euler(new Vector3(mainView.x, mainView.y + 90f, mainView.z));
		}

		if (Input.GetAxisRaw("Horizontal") > 0 && leftView)
		{
			headTransform.rotation = Quaternion.Euler(mainView);
		}
	}

	void ToGoLeft()
	{
		if (Input.GetAxisRaw("Horizontal") < 0 && frontView)
		{
			headTransform.rotation = Quaternion.Euler(new Vector3(mainView.x, mainView.y - 90f, mainView.z));
		}

		if (Input.GetAxisRaw("Horizontal") < 0 && rightView)
		{
			headTransform.rotation = Quaternion.Euler(mainView);
		}
	}

	void Angles()
	{
		if (Mathf.Approximately(headTransform.rotation.eulerAngles.y, 0f))
		{
			frontView = true;
			rightView = false;
			leftView = false;
		}

		if (Mathf.Approximately(headTransform.rotation.eulerAngles.y, 90f))
		{
			frontView = false;
			rightView = true;
			leftView = false;
		}

		if (Mathf.Approximately(headTransform.rotation.eulerAngles.y, 270f))
		{
			frontView = false;
			rightView = false;
			leftView = true;
		}
	}
}