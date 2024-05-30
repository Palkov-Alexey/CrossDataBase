import ReactDOM from 'react-dom/client'
import App from './App.js'
// import './index.css'

const rootElement = document.getElementById('reactroot');

if (!rootElement) throw new Error('Failed to find the root element');

const root = ReactDOM.createRoot(rootElement);
root.render(
  <App />
);