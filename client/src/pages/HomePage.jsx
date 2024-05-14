import React, { useState } from "react";

export default function HomePage() {
  const [count, setCount] = useState(0)

  return (
    <div>
    <div className="home-page">
      <h1 className="p-4 text-center dream-heading">Where Dreams Meet Reality.</h1>
    </div>
    <div className="home-page">
      <img className="img-main" alt="main image" src="https://images.unsplash.com/photo-1715390321213-c8d88b3e024a?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHw3Nnx8fGVufDB8fHx8fA%3D%3D"></img>
    </div>
    </div>
  )
}