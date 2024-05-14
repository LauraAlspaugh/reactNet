import 'bootstrap'
import React from 'react'
import ReactDOM from 'react-dom/client'
import { RouterProvider } from 'react-router-dom'
import './assets/scss/main.scss'
import { router } from './Router.jsx'
import "@mdi/font/css/materialdesignicons.css";


ReactDOM.createRoot(document.getElementById('root')).render(
  <RouterProvider router={router} />
)