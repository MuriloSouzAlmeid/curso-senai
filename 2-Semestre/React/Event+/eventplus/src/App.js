// import logo from "./logo.svg";
import Rotas from "./Routes/routes";
import { UserContext } from "./context/AuthContext";
import { useState, useEffect } from "react";

function App() {
  const [userData, setUserData] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("token");

    //passa um parâmetro que está em json para um objeto javascript
    setUserData(token === null ? {} : JSON.parse(token))
    
    // if (token !== null) { setUserData(JSON.parse(token)) }

  }, []);

  return (
    <UserContext.Provider value={{ userData, setUserData }}>
      <Rotas />
    </UserContext.Provider>
  );
}

export default App;
