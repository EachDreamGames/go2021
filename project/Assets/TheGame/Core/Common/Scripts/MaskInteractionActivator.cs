using UnityEngine;
using UnityEngine.Tilemaps;

namespace TheGame.Core.Common
{
  public class MaskInteractionActivator : MonoBehaviour
  {
    [SerializeField] private Renderer _renderer;
    [SerializeField] private SpriteMaskInteraction _interaction;

    private void Start()
    {
      switch (_renderer)
      {
        case TilemapRenderer tilemapRenderer:
          tilemapRenderer.maskInteraction = _interaction;
          break;
        case SpriteRenderer spriteRenderer:
          spriteRenderer.maskInteraction = _interaction;
          break;
      }
    }
  }
}