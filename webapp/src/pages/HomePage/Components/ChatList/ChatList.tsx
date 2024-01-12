import React, { useState, useEffect } from "react";
import Chat from "../Chat/Chat";
import "./ChatListStyle.scss";
import { Button, Form } from "react-bootstrap";

const ChatList: React.FC<{ onSelectedChat: (chat: Chat) => void }> = ({
  onSelectedChat,
}) => {
  const [chats, setChats] = useState<Chat[]>([]);
  const [newChatName, setNewChatName] = useState("");
  const [selectedUsers, setSelectedUsers] = useState<number[]>([]);
  const [availableUsers, setAvailableUsers] = useState<any[]>([]);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchChats = async () => {
      try {
        // Fetch available users (adjust the endpoint as needed)
        const response = await fetch("http://localhost:5189/api/User/GetUsers");
        const users = await response.json();
        setAvailableUsers(users);

        const storedUserData = localStorage.getItem("userData");

        if (!storedUserData) {
          throw new Error("User data not found");
        }

        const userData = JSON.parse(storedUserData);
        const userId = userData.userId;

        const chatsResponse = await fetch(
          `http://localhost:5189/api/Chat/GetChatByUserId?userId=${userId}`
        );

        const fetchedChats = await chatsResponse.json();
        setChats(fetchedChats);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchChats();
  }, []);

  const handleClick = (chat: Chat) => {
    onSelectedChat(chat);
  };

  const handleCreateChat = async () => {
    try {
      const storedUserData = localStorage.getItem("userData");

      if (!storedUserData) {
        throw new Error("User data not found");
      }

      const userData = JSON.parse(storedUserData);
      const userId = userData.userId;

      const response = await fetch(
        "http://localhost:5189/api/Chat/CreateChat",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            participantsId: selectedUsers,
            name: newChatName,
          }),
        }
      );

      if (!response.ok) {
        throw new Error("Error creating chat");
      }

      const createdChat = await response.json();
      setChats((prevChats) => [...prevChats, createdChat]);
      setNewChatName("");
      setSelectedUsers([]);
    } catch (error) {
      console.error("Error creating chat:", error);
      setError("Error creating chat");
    }
  };

  const handleUserSelection = (userId: number) => {
    if (selectedUsers.includes(userId)) {
      setSelectedUsers((prevSelectedUsers) =>
        prevSelectedUsers.filter((id) => id !== userId)
      );
    } else {
      setSelectedUsers((prevSelectedUsers) => [...prevSelectedUsers, userId]);
    }
  };

  return (
    <div>
      <h2 className="header">Chat List</h2>
      {error && <div className="error-msg">Error: {error}</div>}
      <div className="chat-list">
        <div className="create-chat">
          <Form.Group controlId="chatName">
            <Form.Label>Enter chat name</Form.Label>
            <Form.Control
              type="text"
              placeholder="Enter chat name"
              value={newChatName}
              onChange={(e) => setNewChatName(e.target.value)}
            />
          </Form.Group>
          <Form.Group controlId="participants">
            <Form.Label>Select participants</Form.Label>
            {availableUsers.map((user) => (
              <Form.Check
                key={user.userId}
                type="checkbox"
                label={user.name}
                checked={selectedUsers.includes(user.userId)}
                onChange={() => handleUserSelection(user.userId)}
              />
            ))}
          </Form.Group>
          <Button onClick={handleCreateChat} className="create-chat-btn">
            Create Chat
          </Button>
        </div>
        {chats.map((chat) => (
          <Button
            key={chat.chatId}
            onClick={() => handleClick(chat)}
            className="chat-btn"
          >
            {chat.chatName}
          </Button>
        ))}
      </div>
    </div>
  );
};

export default ChatList;
