import React, { useState, useEffect } from "react";
import { Card, ListGroup, Form, Button } from "react-bootstrap";
import "./ChatStyle.scss";

interface ChatProps {
  selectedChat: Chat | null;
}

const Chat: React.FC<ChatProps> = ({ selectedChat }) => {
  // Load previous messages.
  const [messages, setMessages] = useState<Message[]>([]);
  useEffect(() => {
    const fetchMessages = async () => {
      try {
        if (selectedChat && selectedChat.chatId) {
          const response = await fetch(
            `http://localhost:5189/api/Message/GetMessagesByChatId?chatId=${selectedChat.chatId}`
          );

          const fetchedMessages: Message[] = await response.json();
          setMessages(fetchedMessages);
        }
      } catch (error) {
        console.error("Error fetching chats:", error);
      }
    };

    fetchMessages();
  }, [selectedChat]);
  const storedUserData = localStorage.getItem("userData");
  const userIdFromStorage = storedUserData
    ? JSON.parse(storedUserData).userId
    : null;

  // Send new message
  const [newMessage, setNewMessage] = useState("");
  const sendMessage = async () => {
    try {
      if (selectedChat && selectedChat.chatId && newMessage) {
        const response = await fetch(
          `http://localhost:5189/api/Message/CreateMessage`,
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({
              chatId: selectedChat.chatId,
              userId: userIdFromStorage,
              content: newMessage,
              sentDate: new Date().toISOString(), // Agregar la fecha de envío
              receivedDate: new Date().toISOString(), // Agregar la fecha de recepción
            }),
          }
        );
        if (response.ok) {
          const sentMessage = await response.json();
          setMessages([...messages, sentMessage]);
          setNewMessage("");
        }
      }
    } catch (error) {
      console.error("Error sending message:", error);
    }
  };
  const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
    if (event.key === "Enter") {
      event.preventDefault(); // Previene el comportamiento por defecto del formulario
      sendMessage(); // Llama a la función de enviar mensaje cuando se presiona Enter
    }
  };

  return (
    <div className="container mt-4">
      <h2 className="chat-header">{selectedChat?.chatName}</h2>
      <Card className="chat-card">
        <ListGroup variant="flush">
          {messages.map((message, index) => (
            <div
              key={index}
              className={`message-wrapper ${
                message.userId === userIdFromStorage ? "sent" : "received"
              }`}
            >
              <div
                className={`message-bubble ${
                  message.userId === userIdFromStorage ? "sent" : "received"
                }`}
              >
                {message.content}
              </div>
            </div>
          ))}
        </ListGroup>
      </Card>
      <Form className="custom-form mt-3" onSubmit={(e) => e.preventDefault()}>
        <Form.Group className="mb-3">
          <Form.Control
            type="text"
            placeholder="Type a message..."
            className="custom-input"
            value={newMessage} // Valor del campo de entrada controlado por el estado
            onChange={(e) => setNewMessage(e.target.value)} // Actualiza el estado del mensaje mientras se escribe
            onKeyDown={(e: React.KeyboardEvent<HTMLInputElement>) =>
              handleKeyPress(e)
            }
          />
        </Form.Group>
        <Button
          variant="primary"
          className="custom-button"
          onClick={sendMessage}
        >
          Send
        </Button>
      </Form>
    </div>
  );
};

export default Chat;
