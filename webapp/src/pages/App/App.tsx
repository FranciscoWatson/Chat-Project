import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import Chat from '../Chat/Chat';
import Login from '../Login/Login';
import "./App.scss";

const App = () =>{
    return (
        <Router>
          <Routes>
            <Route path="/chat" element={<Chat />} />
            <Route path="/login" element={<Login />} />
          </Routes>
          <div> Escribi en la url /Chat si queres ir al chat o /Login si queres ir al Login</div>
        </Router>
      );
};

export default App;