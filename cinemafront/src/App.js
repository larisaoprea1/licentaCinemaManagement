import Header from "./components/Header/Header";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import AppRouter from "./pages/Router/AppRouter";



function App() {

  const theme = createTheme({
    palette: {
      primary: {
        // light: will be calculated from palette.primary.main,
        main: "#A899EB",
        // dark: will be calculated from palette.primary.main,
        // contrastText: will be calculated to contrast with palette.primary.main
      },
      secondary: {
        light: "#0066ff",
        main: "#0044ff",
        // dark: will be calculated from palette.secondary.main,
        contrastText: "#ffcc00",
      },
    },
  });
  
  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <AppRouter/>
      </div>
    </ThemeProvider>
  );
}

export default App;
