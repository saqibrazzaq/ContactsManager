import { Box, Container } from "@mui/system";
import { Outlet } from "react-router-dom";
import PublicMenu from "../PublicMenu/PublicMenu";

const Layout = () => {
  return (
    <Container>
      <PublicMenu />
      <Box sx={{mt: 1}}>
        <Outlet />
      </Box>
    </Container>
  );
}

export default Layout;
