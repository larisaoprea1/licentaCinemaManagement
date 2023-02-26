import { Outlet } from "react-router-dom";
import Header from "../../components/Header/Header";

const ProtectedRoute = () => {
  return (
    <div>
      <Header />
      <Outlet />
    </div>
  );
};

export default ProtectedRoute;