import * as AuthenticationService from "../Services/AuthenticationService";
import useAuth from "./useAuth";

const useLogout = () => {
  const { setAuth } = useAuth();

  const logout = async () => {
    setAuth({});

    AuthenticationService.logout()
      .then((res) => {
        console.log("logout successful");
      })
      .catch((err) => console.log("Cannot logout successfully"));
  };

  return logout;
};

export default useLogout;
