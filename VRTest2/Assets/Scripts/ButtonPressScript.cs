using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressScript : MonoBehaviour
{
	[SerializeField] private GameObject _doorToOpen = null;

	[SerializeField] private float _distanceForButtonMove = 0.2f;

	private float _distanceForDoorMove = 4.5f;
	private Vector3 _targetPosForButton;
	private Vector3 _defaultButtonPos;
	private Vector3 _defaultDoorPos;
	private Vector3 _openedDoorPos;

	private bool _buttonIsMooving = false;
	private bool _doorIsMooving = false;
	private bool _doorIsClosing = false;

	private void Start()
	{
		_targetPosForButton = new Vector3(transform.position.x - _distanceForButtonMove, transform.position.y, transform.position.z);

		_defaultButtonPos = transform.position;
		_defaultDoorPos = _doorToOpen.transform.position;

		_openedDoorPos = new Vector3(_doorToOpen.transform.position.x, _doorToOpen.transform.position.y + _distanceForDoorMove, _doorToOpen.transform.position.z);
	}

	private void Update()
	{
		if(_buttonIsMooving && _doorIsMooving)
		{
			transform.position = Vector3.MoveTowards(transform.position, _targetPosForButton, 0.1f);
			_doorToOpen.transform.position = Vector3.MoveTowards(_doorToOpen.transform.position, _openedDoorPos, 0.1f);
		}
		if(_doorIsClosing)
		{
			transform.position = Vector3.MoveTowards(transform.position, _defaultButtonPos, 0.1f);
			_doorToOpen.transform.position = Vector3.MoveTowards(_doorToOpen.transform.position, _defaultDoorPos, 0.1f);

			StartCoroutine(DisableClosing());
		}
	}

	private void OnTriggerEnter(Collider other)
	{		
		_buttonIsMooving = true;
		_doorIsMooving = true;

		StartCoroutine(DisableButtonAndDoor());
	}

	IEnumerator DisableClosing()
	{
		yield return new WaitForSeconds(2f);

		_doorIsClosing = false;
	}

	IEnumerator DisableButtonAndDoor()
	{		
		yield return new WaitForSeconds(3f);

		_buttonIsMooving = false;
		_doorIsMooving = false;

		_doorIsClosing = true;
	}	
}
