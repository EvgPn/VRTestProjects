using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressScript : MonoBehaviour
{
	[SerializeField] private GameObject _objectToSpawn;
	[SerializeField] private Transform _posForSpawn;

	private bool _moveButton = false;

	private Vector3 _targetButtonMovePos;
	private Vector3 _defaultButtonPos;

	private void Start()
	{
		_defaultButtonPos = transform.position;
		_targetButtonMovePos = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
	}

	private void Update()
	{
		if(_moveButton)
		{
			transform.position = Vector3.MoveTowards(transform.position, _targetButtonMovePos, 0.1f);
		}
		if(!_moveButton)
		{
			transform.position = Vector3.MoveTowards(transform.position, _defaultButtonPos, 0.1f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Instantiate(_objectToSpawn, _posForSpawn.position, Quaternion.identity);

		_moveButton = true;
		StartCoroutine(EnableButton());
	}

	IEnumerator EnableButton()
	{
		yield return new WaitForSeconds(2f);
		_moveButton = false;
	}
}
