import React from 'react';
import { useState } from 'react';

const TestePage = () => {
  const [count, setCount] =useState(10);
  // const [calculadora, setCalculadora] = useState(10);

  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount((c) => c + 1)}>+</button>
      {/* <p>Calculation: {calculadora}</p>     */}
    </div>
  );
};

export default TestePage;
