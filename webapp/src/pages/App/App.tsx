import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import Chat from '../HomePage/Chat';
import Login from '../Login/Login';
import "./App.scss";

const App = () =>{
    return (
        <Router>
          <Routes>
            <Route path="/homePage" element={<Chat />} />
            <Route path="/" element={<Login />} />
          </Routes>
        </Router>
      );
};

export default App;