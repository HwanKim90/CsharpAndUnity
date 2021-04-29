using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    // ���̸�, �ִ��ο� Input Field 
    public InputField roomNameInput;
    public InputField maxUserInput;

    // Join ��ư
    public Button joinBtn;
    // MaxUser ��ư
    public Button maxUserBtn;
    
    // �� ��� ĳ��
    Dictionary<string, RoomInfo> roomCache = new Dictionary<string, RoomInfo>();

    // Scrollview - content
    public Transform content;
    // RoomInfo��ư ����
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
        // ��ɼ�
        RoomOptions roomOption = new RoomOptions();
        roomOption.MaxPlayers = byte.Parse(maxUserInput.text);
        // �� ����Ʈ�� �������� ����
        roomOption.IsVisible = true;
        // ��Ͽ��� ���̴µ� �� �� �ִ��� ������ ����
        roomOption.IsOpen = true;
        // ���� �����.
        PhotonNetwork.CreateRoom(roomNameInput.text, roomOption, TypedLobby.Default);
        //PhotonNetwork.JoinOrCreateRoom(roomNameInput.text, roomOption, TypedLobby.Default);
        
    }

    // �� ���� ����
    public override void OnCreatedRoom()
    {
        print("�� ���� ����!@!@");
    }
    // �� ���� ����
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("�� ���� ����");
    }

    // �� ����
    public void JoinRoom()
    {
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom(roomNameInput.text);
    }

    // �� ���� ����
    public override void OnJoinedRoom()
    {
        print("�� ���� ����!@!@");
        print(PhotonNetwork.CurrentRoom.Name);
        // GameScene ���� �̵�
        PhotonNetwork.LoadLevel("GameScene");
    }

    // �� ���� ����
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning("�� ���� ����!@!@");
    }

    // ���� �� ���� ����
    // ���ʿ��� ��ü �� ����Ʈ�� �ش�.
    // �� ������ �߰�/���� �� �� ������ ���´�.
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
        for (int i = 0; i < roomList.Count; i++)
        {
            print(roomList[i].Name);
            
        }
        // 1.���� ������� UI�� ����
        DeleteRoomList();
        // 2.roomCache ���� ����
        UpdateRoomCache(roomList);
        // 3.UI ���Ӱ� �����.
        CreateRoomList();

    }
    
    // RoomCache ����
    void UpdateRoomCache(List<RoomInfo> roomList) 
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            // ���࿡ ���� �Ǵ� �߰� �� ���� roomCache�� ������
            if (roomCache.ContainsKey(roomList[i].Name))
            {
                // ���࿡ �� ���� ������ �Ѵٸ�
                if (roomList[i].RemovedFromList)
                {
                    roomCache.Remove(roomList[i].Name);
                    continue;
                }
            }
            // ���� roomCache�� ���� �Ǵ� �߰�
            roomCache[roomList[i].Name] = roomList[i];
        }
    }

    // ������ ����
    void DeleteRoomList()
    {
        foreach (Transform tr in content)
        {
            Destroy(tr.gameObject);
        }
    }

    // ������ ����
    void CreateRoomList()
    {
        foreach (RoomInfo info in roomCache.Values)
        {
            // 1.roomInfo ��ư ���忡�� roomInfo ��ư ����
            GameObject room = Instantiate(roomInfoFactory);
            // 2.������� roomInfo ��ư�� content�� �ڽ����� ����
            room.transform.SetParent(content);
            // 3.������� roomInfo ��ư���� roomInfoBtn ������Ʈ �����´�.
            RoomInfoBtn btn = room.GetComponent<RoomInfoBtn>();
            // 4.������ ������Ʈ�� SetInfo �Լ� ȣ��
            btn.SetInfo(info.Name, info.PlayerCount, info.MaxPlayers);
            // 5.Ŭ�� �Ǿ��� �� �Լ��� ���
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
        #region �ٸ����!!
        //// ���࿡ roomName ���̰� 0���� ũ��
        //if (roomName.Length > 0)
        //{
        //    // Join��ư�� interactable Ȱ��ȭ
        //    joinBtn.interactable = true;
        //}
        //else
        //{
        //    // Join��ư�� interactable ��Ȱ��ȭ
        //    joinBtn.interactable = false;
        //}
        #endregion
    }

    void OnChangedMaxUser(string maxUser)
    {
        maxUserBtn.interactable = (maxUser.Length > 0 && roomNameInput.text.Length > 0);
    }
}
