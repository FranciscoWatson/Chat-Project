import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import Chat from '../HomePage/Chat';
import Login from '../Login/Login';
import Register from '../Register/Register'

import "./App.scss";

const App = () =>{
    return (
        <Router>
          <Routes>
            <Route path="/homePage" element={<Chat />} />
            <Route path="/" element={<Login />} />
            <Route path="/Register" element={<Register />}/>
          </Routes>
        </Router>
      );
};

export default App;