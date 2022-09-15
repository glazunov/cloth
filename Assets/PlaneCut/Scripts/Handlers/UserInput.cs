using UnityEngine;
using DG.Tweening;

namespace PlaneCut
{
	public class UserInput : MonoBehaviour
	{
		private Vector2 _firstPressPos;
		private Vector2 _secondPressPos;
		private Vector2 _currentSwipe;

		public void Update()
		{
			if (Input.GetMouseButtonDown(0)) {
				//save began touch 2d point
				_firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			}
			if (Input.GetMouseButtonUp(0)) {
				//save ended touch 2d point
				_secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

				//create vector from the two points
				_currentSwipe = new Vector2(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);

				//normalize the 2d vector
				_currentSwipe.Normalize();

				//swipe upwards
				if (_currentSwipe.y > 0 & _currentSwipe.x > -0.5f & _currentSwipe.x < 0.5f) {
					Debug.Log("up swipe");
				}
				//swipe down
				if (_currentSwipe.y < 0 & _currentSwipe.x > -0.5f & _currentSwipe.x < 0.5f) {
					Debug.Log("down swipe");
				}
				//swipe left
				if (_currentSwipe.x < 0 & _currentSwipe.y > -0.5f & _currentSwipe.y < 0.5f) {
					Debug.Log("left swipe");
					transform.DOMoveX(transform.position.x + 0.5f, 0.2f);
				}
				//swipe right
				if (_currentSwipe.x > 0 & _currentSwipe.y > -0.5f & _currentSwipe.y < 0.5f) {
					Debug.Log("right swipe");
					transform.DOMoveX(transform.position.x - 0.5f, 0.2f);
				}
			}
		}
	}
}