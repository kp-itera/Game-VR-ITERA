using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Manoeuvre
{
    public class gc_PlayerHealthManager : MonoBehaviour
    {
        [Tooltip("Damage slider lerp duration!")]
        [Range(0.2f, 2f)]
        public float damageLerpDuration = 0.2f;

        [HideInInspector]
        public int currentHealth;
        [HideInInspector]
        public int maximumHealth;
        
        [Header("UI References")]
        [HideInInspector]
        public Image HealthSlider;
        [HideInInspector]
        public Image DamageSlider;


        public static gc_PlayerHealthManager Instance;

        private void Awake()
        {
            Instance = this;

            HealthSlider = GameObject.Find("HealthSlider").GetComponent<Image>();
            DamageSlider = GameObject.Find("DamageSlider").GetComponent<Image>();
        }

        // Use this for initialization
        public void Initialize(int hAmt)
        {
            currentHealth = hAmt;
            maximumHealth = currentHealth;

            HealthSlider.fillAmount = 0;
            DamageSlider.fillAmount = 0;

            StartCoroutine(LerpHealthSlider());
        }

        public void LerpSliders(int newHealth)
        {

            currentHealth = newHealth;
            float fillAmt = (float)currentHealth / maximumHealth;
            StartCoroutine(LerpDamageSlider(fillAmt));
        }

        public IEnumerator LerpHealthSlider(bool delay = true)
        {
            float t = 0;

            if (delay)
            {
                while (t < 0.5f)
                {
                    t += Time.deltaTime;
                    yield return null;
                }
            }

            t = 0;

            while (t < 3f)
            {
                HealthSlider.fillAmount = Mathf.Lerp(HealthSlider.fillAmount, (float)currentHealth / maximumHealth , t / 3f);
                t += Time.deltaTime;
                yield return null;
            }

            DamageSlider.fillAmount = HealthSlider.fillAmount;

        }

        IEnumerator LerpDamageSlider(float fillAmt)
        {
            float t = 0;

            while (t < damageLerpDuration / 2)
            {
                HealthSlider.fillAmount = Mathf.Lerp(HealthSlider.fillAmount, fillAmt, t/(damageLerpDuration / 2));
                t += Time.deltaTime;
                yield return null;
            }

            t = 0;

            while (t < damageLerpDuration)
            {
                DamageSlider.fillAmount = Mathf.Lerp(DamageSlider.fillAmount, HealthSlider.fillAmount, t / damageLerpDuration);

                t += Time.deltaTime;
                yield return null;
            }
        }

        public void DisableUI()
        {
            List<CanvasGroup> cg = new List<CanvasGroup>();

            CanvasGroup HUD = GameObject.Find("HUD").GetComponent<CanvasGroup>();
            cg.Add(HUD);

            CanvasGroup Crosshair = GameObject.Find("Crosshair").GetComponent<CanvasGroup>();
            cg.Add(Crosshair);

            CanvasGroup ScreenVignett = GameObject.Find("ScreenVignett").GetComponent<CanvasGroup>();
            cg.Add(ScreenVignett);

            StartCoroutine(hideUI(cg));

            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        IEnumerator hideUI(List<CanvasGroup> cg)
        {
            float t = 0;
            while (t < 1f)
            {
                foreach(CanvasGroup c in cg)
                {
                    c.alpha = Mathf.Lerp(c.alpha, 0, t);
                    t += Time.deltaTime;
                    yield return null;
                }
                
            }
        }
    }
}