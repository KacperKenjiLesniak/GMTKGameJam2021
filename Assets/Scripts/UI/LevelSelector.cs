using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Start()
        {
            if (Int32.Parse(text.text) > PlayerPrefs.GetInt("NextLevel", 1))
            {
                GetComponent<Button>().enabled = false;
                var image = GetComponent<Image>();
                var color = image.color;
                GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
            }
        }

        public void Click()
        {
            SceneManager.LoadScene("Level" + Int32.Parse(text.text));
            MusicManager.instance.PlayClip(1);
        }
    }
}