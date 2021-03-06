import { useLocation, Navigate, Outlet } from "react-router-dom";
import useAuth from "../../Hooks/useAuth";

const RequireAuth = ({ allowedRoles }) => {
  const { auth } = useAuth();
  const location = useLocation();

  // console.log(auth);

  if (auth?.roles?.find((role) => allowedRoles?.includes(role))) {
    // console.log("User logged in.");
    return <Outlet />;
  } else {
    if (auth?.user) {
      // console.log("User logged in, but unauthorized.");
      return <Navigate to="/unauthorized" state={{ from: location }} replace />;
    } else {
      // console.log("User not logged in.");
      return <Navigate to="/login" state={{ from: location }} replace />;
    }
  }
};

export default RequireAuth;
