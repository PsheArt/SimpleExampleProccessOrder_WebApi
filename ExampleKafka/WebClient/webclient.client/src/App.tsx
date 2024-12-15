// src/App.tsx
import React from 'react';
import CreateOrder from './OrderApp/Component/CreateOrder';
import GetOrder from './OrderApp/Component/GetOrder';

const App: React.FC = () => {
    return (
        <div style={{ padding: '20px' }}>
            <h1>Управление заказами</h1>
            <CreateOrder />
            <GetOrder />
        </div>
    );
};

export default App;

