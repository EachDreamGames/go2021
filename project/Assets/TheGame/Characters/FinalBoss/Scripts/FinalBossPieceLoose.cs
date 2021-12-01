using System.Collections;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace TheGame.Characters.FinalBoss.Scripts
{
    public class FinalBossPieceLoose : MonoBehaviour
    {
        [SerializeField] private GameObject _piecePrefab;
        [SerializeField] private Transform _spawnPoint;

        public void SpawnPiece() => Instantiate(_piecePrefab, _spawnPoint.position, quaternion.identity);
        
        [Button, DisableInEditorMode]
        
        private void SpawnPieces(int count = 1)
        {
            StartCoroutine(DoSpawn(count));

            IEnumerator DoSpawn(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    SpawnPiece();
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }
    
}