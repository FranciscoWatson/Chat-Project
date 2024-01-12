import "./Homepage.scss";
import ChatList from "./Components/ChatList/ChatList";
import Chat from "./Components/Chat/Chat";
import React, { useState } from "react";

const Homepage = () => {
  const [selectedChat, setSelectedChat] = useState<Chat | null>(null);
  const handleSelectChat = (chat: Chat) => {
    setSelectedChat(chat);
  };

  return (
    <div style={{ display: "flex" }}>
      <div style={{ flex: "1", marginRight: "20px" }}>
        <ChatList onSelectedChat={handleSelectChat} />
      </div>
      <div style={{ flex: "2" }}>
        <Chat selectedChat={selectedChat} />
      </div>
    </div>
  );
};

export default Homepage;
