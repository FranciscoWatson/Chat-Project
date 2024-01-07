import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

const Input = () => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
      };
    
      const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
      };
    
      const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
          const response = await fetch(
            "http://localhost:5189/api/AuthService/Login",
            {
              method: "POST",
              headers: {
                "Content-Type": "application/json",
              },
              body: JSON.stringify({ email, password }),
            }
          );
    
          if (!response.ok) {
            throw new Error("Sign In Error");
          }
    
          const userData = await response.json();
    
          localStorage.setItem("userData", JSON.stringify(userData));
          navigate("/homePage");
    
          console.log("Respuesta de la API:", userData);
        } catch (error) {
          console.error("Error al iniciar sesión:", error);
        }
      };

    return(
        <div>
        <form onSubmit={handleSubmit}>
          <div>
            <label htmlFor="email">User:</label>
            <input
              type="text"
              id="email"
              value={email}
              onChange={handleUsernameChange}
            />
          </div>
          <div>
            <label htmlFor="password">Password:</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={handlePasswordChange}
            />
          </div>
          <button type="submit">Log in</button>
        </form>
      </div>
    );
};

export default Input;