import { createContext, useContext, useState, useEffect } from "react";
import jwt_decode from "jwt-decode";

const UserContext = createContext();

export function useUser() {
  return useContext(UserContext);
}

export function UserContextProvider({ children }) {
  const [user, setUser] = useState({});
  const [loadingUser, setLoadingUser] = useState(true);
  const [token, setToken] = useState([]);

  const value = {
    user,
    loadingUser,
    setLoadingUser,
    setUser,
    setToken,
  };

  useEffect(() => {
    if (localStorage.getItem("jwt")) {
      setUser(jwt_decode(localStorage.getItem("jwt")));
      setLoadingUser(false);
    }

    if (!localStorage.getItem("jwt")) {
      setLoadingUser(false);
    }
  }, [loadingUser]);

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
}
