using TheGame.Core.Animations.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheGame.Management.GameController
{
    public class HappyEnd : AnimatorStateAttributeBehaviour
    {
        [SerializeField] private string _sceneName;
        protected override void OnStateActivate() => SceneManager.LoadScene(_sceneName);
    }
}