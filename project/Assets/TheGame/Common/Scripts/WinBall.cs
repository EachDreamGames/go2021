using System.Collections;
using TheGame.Management.GameController;
using UnityEngine;

namespace TheGame.Common
{
    public class WinBall : MonoBehaviour
    {
        [SerializeField] private LevelControllerStaticContainer _levelControllerContainer;

        private void OnTriggerEnter2D(Collider2D _)
        {
            StartCoroutine(DoFinishGame());
            IEnumerator DoFinishGame()
            {
                yield return new WaitForSeconds(2f);
                _levelControllerContainer.LevelController.FinishGame();
            }
        }
    }
}