import React from 'react';
import ReactDOM, { createRoot } from 'react-dom/client';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import App from './App';
import Login from './Pages/Login/Login';

const container = document.getElementById("app");
const root = createRoot(container); // createRoot(container!) if you use TypeScript
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        
        <Route path='login' element={<Login />} />

      </Route>
    </Routes>
  </BrowserRouter>
);
