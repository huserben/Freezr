import React from 'react';
import './App.css';

const App = () => {
  const apiUrl = 'http://localhost:32777/test'
  
  const [state, setState] = React.useState({ fridge: {}, loading: true });

  React.useEffect(() => {
    async function fetchData() {
      const response = await fetch(apiUrl, { crossDomain: true, method: 'GET', headers: { 'Content-Type': 'application/json' }, mode: 'cors' });
      const data = await response.json();
      setState({ fridge: data[0], loading: false });
    }

    if (state.loading){
      fetchData();
    }
  });

  return (
    <div className="App">
      <header className="App-header">
        <h1>Freezr</h1>
        <h2>Available Fridges:</h2>

        {state.fridge.name}

      </header>
    </div>
  );
}

export default App;
