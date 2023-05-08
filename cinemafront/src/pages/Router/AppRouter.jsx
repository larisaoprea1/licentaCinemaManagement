import { BrowserRouter, Routes, Route } from "react-router-dom";
import ActorList from "../AdminPanel/Actors/ActorList";
import CreateActor from "../AdminPanel/Actors/CreateActor";
import AdminPanel from "../AdminPanel/AdminPanel";
import CreateGenre from "../AdminPanel/Genres/CreateGenre";
import GenreList from "../AdminPanel/Genres/GenreList";
import CreateMovie from "../AdminPanel/Movies/CreateMovie";
import CreateProduction from "../AdminPanel/Productions/CreateProduction";
import ProductionList from "../AdminPanel/Productions/ProductionList";
import LoginPage from "../Authentication/LoginPage";
import RegisterPage from "../Authentication/RegisterPage";
import HomePage from "../HomePage/HomePage";
import ProtectedRoute from "./ProtectedRoute";
import Movies from "../Movies/Movies";
import MoviePage from "../MoviePage/MoviePage";

const AppRouter = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<ProtectedRoute />}>
          <Route path="/" element={<HomePage />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/movies" element={<Movies />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/login" element={<LoginPage />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/register" element={<RegisterPage />} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/movie/:movieId" element={<MoviePage/>} />
        </Route>
        <Route element={<ProtectedRoute />}>
          <Route path="/admin-panel" element={<AdminPanel />}>
            <Route path="create-movie" element={<CreateMovie />} />
            <Route path="create-genre" element={<CreateGenre />} />
            <Route path="genres-list" element={<GenreList />} />
            <Route path="create-production" element={<CreateProduction />} />
            <Route path="productions-list" element={<ProductionList />} />
            <Route path="create-actor" element={<CreateActor />} />
            <Route path="actors-list" element={<ActorList />} />
          </Route>
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

export default AppRouter;
