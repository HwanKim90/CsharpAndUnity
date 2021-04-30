using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // 방이름, 최대인원 Input Field 
    public InputField roomNameInput;
    public InputField maxUserInput;

    // Join 버튼
    public Button joinBtn;
    // MaxUser 버튼
    public Button maxUserBtn;
    
    // 방 목록 캐시
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    // Scrollview - content
    public Transform content;
    // RoomInfo버튼 공장
    public GameObject roomInfoFactory;

    void Start()
    {
        roomNameInput.onValueChanged.AddListener(OnChangedRoomName);
        maxUserInput.onValueChanged.AddListener(OnChangedMaxUser);
    }


    
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        // 방옵션
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = byte.Parse(maxUserInput.text);
        // 방 리스트에 보여줄지 말지
        roomOption.IsVisible = true;
        // 목록에는 보이는데 들어갈 수 있는지 없는지 여부
        roomOption.IsOpen = true;
        // 방을 만든다.
        //PhotonNetwork.CreateRoom(roomNameInput.text, roomOption, TypedLobby.Default);
        PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, roomOption, TypedLobby.Default);
        
    }

    // 방 생성 성공
    public override void OnCreatedRoom()
    {
        print("방 생성 성공!@!@");
    }
    // 방 생성 실패
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("방 생성 실패");
    }

    // 방 접속
    public void JoinRoom()
    {
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom(roomNameInput.text);
    }

    // 방 접속 성공
    public override void OnJoinedRoom()
    {
        print("방 접속 성공!@!@");
        print(PhotonNetwork.CurrentRoom.Name);
        // GameScene 으로 이동
        PhotonNetwork.LoadLevel("GameScene");
    }

    // 방 접속 실패
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("방 접속 실패!@!@");
    }

    // 현재 방 정보 갱신
    // 최초에는 전체 방 리스트를 준다.
    // 그 다음은 추가/삭제 된 방 정보만 들어온다.
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
        for (int i = 0; i < roomList.Count; i++)
        {
            print(roomList[i].Name);
            
        }
        // 1.현재 만들어진 UI를 삭제
        DeleteRoomList();
        // 2.roomCache 정보 갱신
        UpdateRoomCache(roomList);
        // 3.UI 새롭게 만든다.
        CreateRoomList();

    }
    
    // RoomCache 갱신
    void UpdateRoomCache(List<RoomInfo> roomList) 
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            // 만약에 변경 또는 추가 된 방이 roomCache에 있으면
            if (roomCache.ContainsKey(roomList[i].Name))
            {
                // 만약에 그 방을 지워야 한다면
                if (roomList[i].RemovedFromList)
                {
                    roomCache.Remove(roomList[i].Name);
                    continue;
                }
            }
            // 방을 roomCache에 변경 또는 추가
            roomCache[roomList[i].Name] = roomList[i];
        }
    }

    // 방정보 삭제
    void DeleteRoomList()
    {
        foreach (Transform tr in content)
        {
            Destroy(tr.gameObject);
        }
    }

    // 방정보 생성
    void CreateRoomList()
    {
        foreach (RoomInfo info in roomCache.Values)
        {
            // 1.roomInfo 버튼 공장에서 roomInfo 버튼 생성
            GameObject room = Instantiate(roomInfoFactory);
            // 2.만들어진 roomInfo 버튼을 content에 자식으로 세팅
            room.transform.SetParent(content);
            // 3.만들어진 roomInfo 버튼에서 roomInfoBtn 컴포넌트 가져온다.
            RoomInfoBtn btn = room.GetComponent<RoomInfoBtn>();
            // 4.가져온 컴포넌트의 SetInfo 함수 호출
            btn.SetInfo(info.Name, info.PlayerCount, info.MaxPlayers);
            // 5.클릭 되었을 때 함수를 등록
            btn.clickAction = OnClickRoomInfo;
        }
    }

    void OnClickRoomInfo(string roomName)
    {
        roomNameInput.text = roomName;
    }

    void OnChangedRoomName(string roomName)
    {
        joinBtn.interactable = roomName.Length > 0;
        OnChangedMaxUser(maxUserInput.text);
        #region 다른방법!!
        //// 만약에 roomName 길이가 0보다 크면
        //if (roomName.Length > 0)
        //{
        //    // Join버튼의 interactable 활성화
        //    joinBtn.interactable = true;
        //}
        //else
        //{
        //    // Join버튼의 interactable 비활성화
        //    joinBtn.interactable = false;
        //}
        #endregion
    }

    void OnChangedMaxUser(string maxUser)
    {
        maxUserBtn.interactable = (maxUser.Length > 0 && roomNameInput.text.Length > 0);
    }
}
