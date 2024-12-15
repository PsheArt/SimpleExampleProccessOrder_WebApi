import React, { useState } from 'react';
import axios, { AxiosResponse } from 'axios';
import { Order } from '../Model/Order';

const GetOrder: React.FC = () => {
    const [orderId, setOrderId] = useState<string>('');
    const [order, setOrder] = useState<Order>();
    const [errorMessage, setErrorMessage] = useState<string>('');

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setOrderId(e.target.value);
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response:AxiosResponse<Order> = await axios.get<Order>('https://localhost:5000/api/Orders');
            setOrder(response.data);
            setErrorMessage('');
        } catch (error) {
            setErrorMessage('����� �� ������.' + error);
            setOrder(order);
        }
    };

    return (
        <div>
            <h2>�������� �����</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Order ID:</label>
                    <input type="text" value={orderId} onChange={handleChange} required />
                </div>
                <button type="submit">�������� �����</button>
            </form>
            {errorMessage && <p>{errorMessage}</p>}
            {order && (
                <div>
                    <h3>������ ������:</h3>
                    <p>ID: {order.Id}</p>
                    <p>�����: {order.Product}</p>
                    <p>����������: {order.Quantity}</p>
                </div>
            )}
        </div>
    );
};

export default GetOrder;