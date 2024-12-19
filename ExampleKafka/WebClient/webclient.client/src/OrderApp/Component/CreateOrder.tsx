import React, { useState } from 'react';
import axios from 'axios';
import { CreateOrderRequest } from '../Model/CreateOrderRequest';

   const CreateOrder: React.FC = () => {
       const [orderDetails, setOrderDetails] = useState<CreateOrderRequest>({ productId: '', quantity: 0 });
       const [message, setMessage] = useState<string>('');

       const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
           const { name, value } = e.target;
           setOrderDetails({ ...orderDetails, [name]: name === 'quantity' ? Number(value) : value });
       };

       const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
           e.preventDefault();
           try {
               const response = await axios.post('http://localhost:5000/api/Orders/create', orderDetails);
               setMessage('Заказ создан! ID: ' + response.data.id);
           } catch (error) {
               setMessage('Ошибка при создании заказа. ' + error);
           }
       };

       return (
           <div>
               <h2>Создать заказ</h2>
               <form onSubmit={handleSubmit}>
                   <div>
                       <label>Product ID:</label>
                       <input type="text" name="productId" value={orderDetails.productId} onChange={handleChange} required />
                   </div>
                   <div>
                       <label>Quantity:</label>
                       <input type="number" name="quantity" value={orderDetails.quantity} onChange={handleChange} required />
                   </div>
                   <button type="submit">Создать</button>
               </form>
               {message && <p>{message}</p>}
           </div>
       );
   };

   export default CreateOrder;