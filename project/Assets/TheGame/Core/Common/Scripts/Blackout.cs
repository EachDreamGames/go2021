using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheGame.Core.Common
{
  public static class Blackout
  {
    private const float FadingTime = 0.1f;
    private static float TimeStep => FadingTime / 255;

    private static Image _blackoutImage;

    private static void Prepare() => 
      _blackoutImage = _blackoutImage ? _blackoutImage : CreateBlackoutObject();

    private static Image CreateBlackoutObject()
    {
      GameObject blackoutObject = new GameObject("BlackoutCover");
      Object.DontDestroyOnLoad(blackoutObject);
      blackoutObject.AddComponent<Canvas>();
      GameObject imageObject = new GameObject("Image");
      imageObject.transform.parent = blackoutObject.transform;
      Image image = imageObject.AddComponent<Image>();
      image.rectTransform.anchorMin = Vector2.zero;
      image.rectTransform.anchorMax = Vector2.one;
      image.rectTransform.offsetMin = Vector2.zero;
      image.rectTransform.offsetMax = Vector2.zero;
      image.enabled = false;
      return image;
    }

    public static IEnumerator Show()
    {
      Prepare();
      _blackoutImage.enabled = true;
      byte alpha = 0;
      do
      {
        _blackoutImage.color = new Color32(0, 0, 0, alpha);
        alpha++;
        yield return new WaitForSeconds(TimeStep);
      } while (alpha < 255);
    }

    public static IEnumerator Hide()
    {
      Prepare();
      byte alpha = 255;
      do
      {
        _blackoutImage.color = new Color32(0, 0, 0, alpha);
        alpha--;
        yield return new WaitForSecondsRealtime(TimeStep);
      } while (alpha > 0);

      _blackoutImage.enabled = false;
    }
  }
}