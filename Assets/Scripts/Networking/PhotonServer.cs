using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Networking.Common;
using UnityEngine;

namespace Networking
{
    public class PhotonServer : MonoBehaviour, IPhotonPeerListener
    {
        [SerializeField] private string _connectionString = "";

        [SerializeField] private string _appName = "BattleServer";

        //[Inject] private IGame Game;
        private User _user;
        private string userId;

        private static PhotonServer _instance;
        private PhotonPeer Peer;

        public static PhotonServer Instance
        {
            get { return _instance; }
            set
            {
                if (!_instance) _instance = value;
            }
        }


        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                //Application.runInBackground = true;
            }
            else if (this != _instance)
            {
                Destroy(gameObject);
            }

            _user = User.Init();
        }

        // Use this for initialization
        public void Init()
        {
            Peer = new PhotonPeer(this, ConnectionProtocol.Tcp);
            Connect();
        }

        void Start()
        {
            //Game.BattleController.BattleStartEvent += SendStatsInitRequest;
        }

        // Update is called once per frame
        void Update()
        {
            if (Peer != null)
            {
                Peer.Service();
            }
        }

        private void Connect()
        {
            if (Peer != null)
            {
                Peer.Connect(_connectionString, _appName);
            }
        }

        private void Disconnect()
        {
            if (Peer != null) Peer.Disconnect();
        }

        private void OnApplicationQuit()
        {
            Disconnect();
        }

        public void DebugReturn(DebugLevel level, string message)
        {
            Debug.Log(message);
        }


        public void OnOperationResponse(OperationResponse operationResponse)
        {
        }


        public void OnStatusChanged(StatusCode statusCode)
        {
            switch (statusCode)
            {
                case StatusCode.Connect:
                    SendInitRequest();
                    break;

                case StatusCode.Disconnect:
                    break;
                case StatusCode.TimeoutDisconnect:
                    break;
                case StatusCode.DisconnectByServer:
                    break;
                default:
                    break;
            }
        }

        public event Action<int, int> UpdateScore;
        public event Action<int, int> InitStats;
        public event Action EnemyHit;
        public event Action PlayerHit;
        public event Action Win;
        public event Action Lose;
        public event Action<int, int> UpdateStats;

        public void OnEvent(EventData eventData)
        {
            Dictionary<byte, object> Parameters = eventData.Parameters;

            switch (eventData.Code)
            {
                case (byte) EventCodes.InitEvent:
                    OnInit(eventData);
                    break;
                case (byte) EventCodes.StatsInit:
                    if (InitStats != null)
                        InitStats(
                            (int) Parameters[(byte) BattleEvent.Params.PlayerHealth],
                            (int) Parameters[(byte) BattleEvent.Params.EnemyHealth]
                        );
                    break;
                case (byte) EventCodes.EnemyHit:
                    if (UpdateStats != null)
                        UpdateStats(
                            (int) Parameters[(byte) BattleEvent.Params.PlayerHealth],
                            (int) Parameters[(byte) BattleEvent.Params.EnemyHealth]
                        );
                    if (EnemyHit != null) EnemyHit();
                    break;
                case (byte) EventCodes.PlayerHit:
                    if (UpdateStats != null)
                        UpdateStats(
                            (int) Parameters[(byte) BattleEvent.Params.PlayerHealth],
                            (int) Parameters[(byte) BattleEvent.Params.EnemyHealth]
                        );
                    if (PlayerHit != null) PlayerHit();
                    break;
                case (byte) EventCodes.EnemyDie:
                    OnEnemyDie();
                    break;

                case (byte) EventCodes.PlayerDie:
                    OnPlayerDie();
                    break;
            }
        }

        private void OnEnemyDie()
        {
            if (Win != null) Win();
        }

        private void OnPlayerDie()
        {
            if (Lose != null) Lose();
        }

        private void OnInit(EventData eventData)
        {
            Dictionary<byte, object> Parameters = eventData.Parameters;
            _user.Id = (string) Parameters[(byte) InitEvent.Params.Id];
            _user.Wins = (int) Parameters[(byte) InitEvent.Params.Wins];
            _user.Loses = (int) Parameters[(byte) InitEvent.Params.Loses];
            if (UpdateScore != null) UpdateScore(_user.Wins, _user.Loses);
        }

        public void SendStatsInitRequest()
        {
            Peer.OpCustom((byte) RequestCodes.StatsInitRequest,
                new Dictionary<byte, object> { }, false);
        }


        public void SendInitRequest()
        {
            Peer.OpCustom((byte) RequestCodes.InitRequest,
                new Dictionary<byte, object> {{(byte) InitEvent.Params.Id, _user.Id}}, false);
        }


        public void SendHitRequest()
        {
            Peer.OpCustom((byte) RequestCodes.PlayerHitRequest, new Dictionary<byte, object> { }, false);
        }
    }
}