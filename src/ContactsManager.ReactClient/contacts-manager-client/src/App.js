import { Route, Routes, Navigate } from 'react-router-dom';

import Header from './components/Header';
import Login from './components/Login';
import Register from './components/Register';

function App() {
  return (
    <div id="box">
      <Header />

      <main id="main-content">
        <Routes>          
          <Route path="/login" element={<Login/>} />
          <Route path="/register" element={<Register/>} />
          <Route path="/logout" render={(props) => {
            console.log('Logged Out!!!');

            return <Navigate to="/" />
          }} />
        </Routes>
      </main>

    </div>
  );
}

export default App;
