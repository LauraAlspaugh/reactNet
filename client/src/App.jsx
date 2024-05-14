import React from 'react'
import { Outlet } from 'react-router-dom'
import { Navbar } from './components/Navbar.jsx'


export function App() {

  return (
    <div className="App" id="app">
      <header>
        <Navbar />
      </header>

      <main>
        <Outlet />
      </main>

      <footer className=" text-light text-center p-3 ">
        <p className='fs-5'>
        <i className='mdi mdi-copyright fs-5'></i>
by Laura Alspaugh 2024
        </p>
      </footer>

    </div>
  )
}
