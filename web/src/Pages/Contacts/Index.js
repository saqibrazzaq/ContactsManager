import React, { useEffect, useState } from "react";
import useRefreshToken from "../../Hooks/useRefreshToken";
import useAxiosPrivate from "../../Hooks/useAxiosPrivate";
import { Navigate, useLocation, useNavigate } from "react-router-dom";

const ContactsIndex = () => {
  const [contacts, setContacts] = useState([]);
  const refresh = useRefreshToken();
  const axiosPrivate = useAxiosPrivate();
  const location = useLocation();
  const navigate = useNavigate();

  useEffect(() => {
    axiosPrivate
      .get("Persons")
      .then((res) => {
        console.log(res.data);
      })
      .catch((err) => {
        console.log(err);
        navigate("/login", {
          state: { from: location },
          replace: true,
        });
      });
  }, []);

  return (
    <>
      <h2>Users List</h2>

      <button onClick={() => refresh()}>Refresh</button>
    </>
  );
};

export default ContactsIndex;
