import React, { useEffect, useState } from "react";
import useRefreshToken from "../../Hooks/useRefreshToken";
import useAxiosPrivate from "../../Hooks/useAxiosPrivate";
import { Navigate, useLocation, useNavigate } from "react-router-dom";
import { Box } from "@mui/system";
import { Link } from "react-router-dom";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import {
  IconButton,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Typography,
} from "@mui/material";

const ContactsIndex = () => {
  const [contacts, setContacts] = useState([]);
  const refresh = useRefreshToken();
  const axiosPrivate = useAxiosPrivate();
  const location = useLocation();
  const navigate = useNavigate();

  const [users, setUsers] = useState([]);
  // Loading state
  const [loading, setLoading] = useState(true);

  // Items list
  const itemList = users.map((item) => {
    return (
      <ListItem
        sx={{ padding: "0" }}
        key={item.userId}
        secondaryAction={
          <Box>
            <IconButton
              component={Link}
              to={`/admin/battery/type/edit/${item.id}`}
            >
              <EditIcon />
            </IconButton>
            <IconButton
              component={Link}
              to={`/admin/battery/type/delete/${item.id}`}
            >
              <DeleteIcon color="error" />
            </IconButton>
          </Box>
        }
      >
        <ListItemButton>
          <ListItemText primary={item.firstName + " " + item.lastName}></ListItemText>
        </ListItemButton>
      </ListItem>
    );
  });

  useEffect(() => {
    axiosPrivate
      .get("Users/all")
      .then((res) => {
        console.log(res.data.data);
        setUsers(res.data.data);
        setLoading(false);
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
      <Typography variant="h4">All Users</Typography>

      {loading && <Typography>Loading...</Typography>}

      <List>{!loading && itemList}</List>

      <button onClick={() => refresh()}>Refresh</button>
    </>
  );
};

export default ContactsIndex;
