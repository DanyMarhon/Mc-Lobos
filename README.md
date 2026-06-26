# 🍔 Mc Lobos - Sistema de Gestión de Pedidos de Comida Rápida

**Mc Lobos** es una aplicación web desarrollada para gestionar de forma eficiente los pedidos en un local de comida rápida. 
Ofrece una experiencia moderna tanto para usuarios como para administradores, permitiendo tomar pedidos, administrar el menú, 
procesar múltiples formas de pago y analizar estadísticas detalladas.

## 🚀 Funcionalidades Principales

- 🛒 **Toma de Pedidos Online:** Carga de pedidos por tipo (en local, para llevar o delivery).
- 🧍‍♂️ **Gestión de Clientes:** Registro de datos y seguimiento de historial.
- 💳 **Múltiples Formas de Pago:** Efectivo, tarjetas y billeteras virtuales.
- 📊 **Estadísticas Detalladas:** Reportes por producto, pago, tiempo, tipo de pedido, etc.
- 🚚 **Seguimiento de Pedidos:** Estados visibles (Recibido, En preparación, Listo, Entregado).
- 🍟 **Gestión de Menú:** Alta, baja y modificación de productos, combos y precios.

## 🛠️ Tecnologías Utilizadas

- **Frontend:** Blazor Server (UI interactiva en tiempo real)
- **Backend:** ASP.NET Core MVC
- **ORM:** Entity Framework Core + Patrón Unit of Work
- **Base de Datos:** SQL Server (Code First)
- **Arquitectura:** N-capas (Presentación, Aplicación, Dominio, Persistencia)

## 🧱 Arquitectura

- **Presentación:** Interfaz web Blazor
- **Aplicación:** Servicios de lógica y controladores
- **Dominio:** Entidades y reglas de negocio
- **Persistencia:** EF Core, Repositorios y Unit of Work

## 📦 Instalación

1. Cloná el repositorio:
   ```bash
   git clone https://github.com/DanyMarhon/TPInvOp2025.git
