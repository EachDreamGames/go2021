using System.Collections;
using TheGame.Management.GameController;
using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Common
{
    public class WinBall : MonoBehaviour
    {
        [SerializeField] private LevelControllerStaticContainer _levelControllerContainer;
        [SerializeField] private UnityEvent _onTrigger;

        private void OnTriggerEnter2D(Collider2D _)
        {
            _onTrigger?.Invoke();
            StartCoroutine(DoFinishGame());
            IEnumerator DoFinishGame()
            {
                yield return new WaitForSeconds(4f);
                _levelControllerContainer.LevelController.FinishGame();
            }
        }
    }
}