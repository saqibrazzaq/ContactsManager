import Api from "../Api/Api";
import useAuth from "./useAuth";

const useLogout = () => {
  const {setAuth} = useAuth();

  const logout = async() => {
    setAuth({});

    // try {
    //   // const response = await Api.get('logout')
    // }
  }

  return logout;
}

export default useLogout;
