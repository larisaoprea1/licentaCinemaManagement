import { BrowserRouter, Routes, Route } from "react-router-dom";
import AdminPanel from "../AdminPanel/AdminPanel";
import CreateGenre from "../AdminPanel/Genres/CreateGenre";
import GenreList from "../AdminPanel/Genres/GenreList";
import LoginPage from "../Authentication/LoginPage";
import RegisterPage from "../Authentication/RegisterPage";
import HomePage from "../HomePage/HomePage";
import ProtectedRoute from "./ProtectedRoute";

const AppRouter = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<ProtectedRoute />}>
          <Route path="/" element={<HomePage />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/login" element={<LoginPage />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/register" element={<RegisterPage />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/admin-panel" element={<AdminPanel />}>
            <Route path="create-genre" element={<CreateGenre />} />
            <Route path="genres-list" element={<GenreList />} />
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default AppRouter;
