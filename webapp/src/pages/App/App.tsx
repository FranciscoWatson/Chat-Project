import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Login from "../Login/Login";
import "./App.scss";
import Homepage from "../Homepage/Homepage";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/homePage" element={<Homepage />} />
        <Route path="/" element={<Login />} />
      </Routes>
    </Router>
  );
};

export default App;
