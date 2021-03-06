import React from "react";
import Api from "../Api/Api";
import useAuth from "./useAuth";

const useRefreshToken = () => {
  const { auth, setAuth } = useAuth();

  const refresh = async () => {
    // console.log("in useRefresh()");
    // console.log(auth);
    const response = await Api.post("Users/refresh-token");
    // console.log("got response from useRefresh()");
    setAuth((prev) => {
      // console.log(JSON.stringify(prev));
      // console.log(response.data.accessToken);
      // console.log('Refresh token.');
      return {
        ...prev,
        accessToken: response.data.accessToken,
        // refreshToken: response.data.refreshToken,
        roles: [response?.data?.role],
      };
    });
    return response.data.accessToken;
  }
  return refresh;
}

export default useRefreshToken;
