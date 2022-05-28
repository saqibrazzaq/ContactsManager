import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { Outlet, Routes, Route } from "react-router-dom";
import Layout from "./Components/Layout/Layout";
import PublicMenu from "./Components/PublicMenu/PublicMenu";
import AdminHome from "./Pages/Admin/Home/AdminHome";
import Blog from "./Pages/Blog/Blog";
import Home from "./Pages/Home/Home";
import Unauthorized from "./Pages/Unauthorized/Unauthorized";
import Login from "./Pages/Login/Login";
import Register from "./Pages/Register/Register";
import RequireAuth from "./Components/RequireAuth/RequireAuth";
import ContactsIndex from "./Pages/Contacts/Index";

function App() {
  const Roles = {
    Administrator: "Administrator",
    Manager: "Manager",
    User: "User",
  };

  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        {/* Public routes */}
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="home" element={<Home />} />
        <Route path="blog" element={<Blog />} />
        <Route path="unauthorized" element={<Unauthorized />} />

        {/* Admin routes */}
        <Route
          element={
            <RequireAuth allowedRoles={[Roles.Administrator, Roles.Manager]} />
          }
        >
          <Route path="admin" element={<AdminHome />} />
        </Route>

        {/* User routes */}
        <Route element={<RequireAuth allowedRoles={[Roles.User]} />}>
          <Route path="contacts">
            <Route index element={<ContactsIndex />} />
          </Route>
        </Route>
      </Route>
    </Routes>
  );
}

export default App;
