using UnityEngine;

namespace Networking
{
    public class User
    {
        public string Id
        {
            get { return PlayerPrefs.HasKey("UserId") ? PlayerPrefs.GetString("UserId") : null; }
            set { PlayerPrefs.SetString("UserId", value); }
        }

        public int Wins { get; set; }
        public int Loses { get; set; }

        public static User Init()
        {
            return new User();
        }
    }
}