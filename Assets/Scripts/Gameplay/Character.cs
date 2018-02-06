using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Image))]
    public class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Transform _labelPoint;
        public int Health { get; set; }
        private int MaxHealth { get; set; }

        private Animator _animator;

        private Animator Animator
        {
            get
            {
                if (_animator == null)
                {
                    _animator = GetComponent<Animator>();
                }

                return _animator;
            }
        }

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }


        public Image Icon
        {
            get { return _icon; }
        }

        public GameObject GameObject
        {
            get { return gameObject; }
        }

        public virtual void Hit()
        {
            Animator.SetTrigger("Hit");
        }

        public ICharacter Instantiate(Transform holder, bool active = true)
        {
            var item = GameObject.Instantiate(this, holder);
            item.GameObject.SetActive(active);
            return item;
        }

        public T Instantiate<T>(Transform holder, bool active = true) where T : class, ICharacter
        {
            var item = GameObject.Instantiate(this, holder) as T;
            item.GameObject.SetActive(active);
            return item;
        }


        public void InitStats(int maxHealth)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;
        }


        void OnGUI()
        {
            int len = 100;
            var pos = Camera.main.WorldToScreenPoint(_labelPoint.transform.position);
            GUI.Box(new Rect(pos.x - len / 2, Screen.height - pos.y, len, 20),
                this.Health.ToString() + "/" + this.MaxHealth.ToString());
        }
    }
}